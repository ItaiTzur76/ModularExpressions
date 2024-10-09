using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModularExpressions.Generators.Model;
using System;
using System.Linq;
using System.Text;

namespace ModularExpressions.Generators;

internal sealed class Parser(IModexEventHandler modexEventHandler)
{
    private readonly IModexEventHandler _modexEventHandler = modexEventHandler;

    private static readonly HashSet<int> _firstCharacterPeriphery = [0];
    private static readonly string[] _escapeCharacters = [".", "+", "*", "?", "^", "$", "(", ")", "[", "]", "{", "}", "|"];
    private static readonly Dictionary<string, string> _specialEscapes = new()
    {
        [@"\"] = @"\\\\",
        ["\""] = "\\\""
    };

    internal ParsedNode? RunForMethodWithModexAttribute(
        List<AttributeData> existingGenerateModexAttributes,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        ISymbol decoratedMethodSymbol)
    {
        return NoParametersCheckPassed(decoratedMethodSymbol) &&
            TryGetGenerateModexAttributeConstructorArgument(existingGenerateModexAttributes, out var modexPropertyName)
            ? modexPropertyName is null
                ? new(Tokens: null, Precedence: RegexPrecedence.AtomicElement)
                : RunForModexProperty(
                    compilation: compilation,
                    classSymbol: classSymbol,
                    modexPropertyName: modexPropertyName,
                    symbolsEncountered: [],
                    symbolCrumbTrail: [])
            : null;

        bool NoParametersCheckPassed(ISymbol decoratedMethodSymbol)
        {
            var methodSymbol = (IMethodSymbol)decoratedMethodSymbol;
            var parameters = methodSymbol.Parameters.Length;
            if (parameters == 0)
            {
                return true;
            }

            _modexEventHandler.HandleDecoratedMethodWithParameters(methodSymbol, parameters);
            return !_modexEventHandler.BreaksOnFailures;
        }

        static bool TryGetGenerateModexAttributeConstructorArgument(List<AttributeData> existingGenerateModexAttributes, out string? argument)
        {
            if (existingGenerateModexAttributes.Count != 1)
            {
                argument = null;
                return false;
            }

            var generateModexAttributeArguments = existingGenerateModexAttributes[0].ConstructorArguments;
            if (!generateModexAttributeArguments.Any())
            {
                argument = null;
                return false;
            }

            var generateModexAttributeArgumentValue = generateModexAttributeArguments.Single().Value;
            if (generateModexAttributeArgumentValue is null)
            {
                argument = null;
                return true;
            }

            argument = (string)generateModexAttributeArgumentValue;
            return true;
        }
    }

    private ParsedNode? RunForModexProperty(
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
    {
        var modexPropertyMemberDeclarationSyntax = GetPropertyMemberDeclarationSyntax(classSymbol, modexPropertyName);
        if (modexPropertyMemberDeclarationSyntax is null)
        {
            _modexEventHandler.HandleMissingModexProperty(classSymbol, modexPropertyName);
            return null;
        }

        return RunForArrowExpression(
            compilation,
            arrowExpressionClauseSyntax: ((PropertyDeclarationSyntax)modexPropertyMemberDeclarationSyntax).ExpressionBody,
            classSymbol,
            modexPropertyName,
            symbolsEncountered,
            symbolCrumbTrail);

        static MemberDeclarationSyntax GetPropertyMemberDeclarationSyntax(
            ISymbol containingTypeSymbol, string modexPropertyName)
            => containingTypeSymbol.GetSyntaxNodes<ClassDeclarationSyntax>()
                .SelectMany(static classDeclarationSyntax => classDeclarationSyntax.Members)
                .OfType<PropertyDeclarationSyntax>()
                .SingleOrDefault(
                    propertyDeclarationSyntax => propertyDeclarationSyntax.Identifier.Text == modexPropertyName);

        ParsedNode? RunForArrowExpression(
            Compilation compilation,
            ArrowExpressionClauseSyntax? arrowExpressionClauseSyntax,
            INamedTypeSymbol classSymbol,
            string modexPropertyName,
            HashSet<ISymbol> symbolsEncountered,
            Stack<ISymbol> symbolCrumbTrail)
        {
            if (arrowExpressionClauseSyntax is null)
            {
                _modexEventHandler.HandleNonArrowModexProperty(classSymbol, modexPropertyName);
                return null;
            }

            return RunForExpression(
                compilation,
                expressionSyntax: arrowExpressionClauseSyntax.Expression,
                classSymbol,
                modexPropertyName,
                symbolsEncountered,
                symbolCrumbTrail);
        }

        ParsedNode? RunForExpression(
            Compilation compilation,
            ExpressionSyntax expressionSyntax,
            INamedTypeSymbol classSymbol,
            string modexPropertyName,
            HashSet<ISymbol> symbolsEncountered,
            Stack<ISymbol> symbolCrumbTrail)
        {
            AddLastSymbolEncountered(classSymbol, modexPropertyName, symbolsEncountered, symbolCrumbTrail);
            var result = Parse(
                expressionSyntax: expressionSyntax,
                modexTypeSymbol: compilation
                    .GetTypeByMetadataName($"{Constants.ModularExpressionsNamespace}.{Constants.ModexClassName}")!,
                compilation: compilation,
                classSymbol: classSymbol,
                modexPropertyName: modexPropertyName,
                symbolsEncountered: symbolsEncountered,
                symbolCrumbTrail: symbolCrumbTrail);
            RemoveLastSymbolEncountered(symbolsEncountered, symbolCrumbTrail);
            return result;

            static void AddLastSymbolEncountered(
                INamedTypeSymbol classSymbol,
                string modexPropertyName,
                HashSet<ISymbol> symbolsEncountered,
                Stack<ISymbol> symbolCrumbTrail)
            {
                var modexPropertySymbol = classSymbol.GetMembers()
                    .OfType<IPropertySymbol>()
                    .Where(propertySymbol => propertySymbol.Name == modexPropertyName)
                    .Single();
                symbolsEncountered.Add(modexPropertySymbol);
                symbolCrumbTrail.Push(modexPropertySymbol);
            }

            static void RemoveLastSymbolEncountered(
                HashSet<ISymbol> symbolsEncountered, Stack<ISymbol> symbolCrumbTrail)
            {
                symbolsEncountered.Remove(symbolCrumbTrail.Pop());
            }
        }
    }

    private ParsedNode? Parse(
        ExpressionSyntax expressionSyntax,
        INamedTypeSymbol modexTypeSymbol,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
    {
        if (IsNullLiteralExpression(expressionSyntax)
            || expressionSyntax is PostfixUnaryExpressionSyntax postfixUnaryExpressionSyntax
            && postfixUnaryExpressionSyntax.IsKind(SyntaxKind.SuppressNullableWarningExpression)
            && IsNullLiteralExpression(postfixUnaryExpressionSyntax.Operand))
        {
            return new(Tokens: null, Precedence: RegexPrecedence.AtomicElement);
        }

        var semanticModel = compilation.GetSemanticModel(expressionSyntax.SyntaxTree);
        if (expressionSyntax is ParenthesizedExpressionSyntax parenthesizedExpressionSyntax)
        {
            return Parse(
                expressionSyntax: parenthesizedExpressionSyntax.Expression,
                modexTypeSymbol: modexTypeSymbol,
                compilation: compilation,
                classSymbol: classSymbol,
                modexPropertyName: modexPropertyName,
                symbolsEncountered: symbolsEncountered,
                symbolCrumbTrail: symbolCrumbTrail);
        }

        var symbol = semanticModel.GetSymbolInfo(expressionSyntax).Symbol;
        if (symbol is null)
        {
            return null;
        }

        var methodSymbolName = symbol.Name;
        var methodSymbolContainingType = symbol.ContainingType;
        return methodSymbolContainingType.EqualsSymbol(modexTypeSymbol)
            ? ParseModex(
                expressionSyntax,
                modexTypeSymbol,
                compilation,
                classSymbol,
                modexPropertyName,
                methodSymbolName,
                symbolsEncountered,
                symbolCrumbTrail)
            : symbol is IFieldSymbol fieldSymbol && fieldSymbol.IsConst && fieldSymbol.Type.IsStringIn(compilation)
                ? ParseImplicit((string?)fieldSymbol.ConstantValue)
                : ParseNonModexMember(symbol, methodSymbolContainingType, methodSymbolName, compilation, symbolsEncountered, symbolCrumbTrail);

        ParsedNode? ParseModex(
            ExpressionSyntax expressionSyntax,
            INamedTypeSymbol modexTypeSymbol,
            Compilation compilation,
            INamedTypeSymbol classSymbol,
            string modexPropertyName,
            string methodSymbolName,
            HashSet<ISymbol> symbolsEncountered,
            Stack<ISymbol> symbolCrumbTrail)
            => methodSymbolName switch
            { // https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
                #region Character Escapes
                Constants.ModexMembers.Tab => AtomicParsedNode(@"\\t"),
                Constants.ModexMembers.CarriageReturn => AtomicParsedNode(@"\\r"),
                Constants.ModexMembers.NewLine => AtomicParsedNode(@"\\n"),
                #endregion

                #region Character Classes
                Constants.ModexMembers.AnyCharacterIn => ParseCharacterClass(expressionSyntax, positiveCharacterGroup: true, semanticModel, classSymbol, modexPropertyName, modexTypeSymbol),
                Constants.ModexMembers.AnyCharacterNotIn => ParseCharacterClass(expressionSyntax, positiveCharacterGroup: false, semanticModel, classSymbol, modexPropertyName, modexTypeSymbol),
                Constants.ModexMembers.NonNewLineCharacter => AtomicParsedNode("."),
                Constants.ModexMembers.WordCharacter => AtomicParsedNode(Constants.CharacterClasses.WordCharacter),
                Constants.ModexMembers.NonWordCharacter => AtomicParsedNode(Constants.CharacterClasses.NonWordCharacter),
                Constants.ModexMembers.WhitespaceCharacter => AtomicParsedNode(Constants.CharacterClasses.WhitespaceCharacter),
                Constants.ModexMembers.NonWhitespaceCharacter => AtomicParsedNode(Constants.CharacterClasses.NonWhitespaceCharacter),
                Constants.ModexMembers.Digit => AtomicParsedNode(Constants.CharacterClasses.Digit),
                Constants.ModexMembers.NonDigit => AtomicParsedNode(Constants.CharacterClasses.NonDigit),
                #endregion

                #region Anchors
                Constants.ModexMembers.Beginning => AtomicParsedNode("^"),
                Constants.ModexMembers.End => AtomicParsedNode("$"),
                Constants.ModexMembers.WordBoundary => AtomicParsedNode(@"\\b"),
                Constants.ModexMembers.WordNonBoundary => AtomicParsedNode(@"\\B"),
                #endregion

                #region Grouping Constructs
                Constants.ModexMembers.NamedGroup => ParseNamedGroup(expressionSyntax, semanticModel, modexTypeSymbol, compilation, classSymbol, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                #endregion

                #region Quantifiers
                Constants.ModexMembers.ZeroOrMoreOf => Parse1ParameterQuantifier(expressionSyntax, modexTypeSymbol, '*', compilation, classSymbol, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                Constants.ModexMembers.OneOrMoreOf => Parse1ParameterQuantifier(expressionSyntax, modexTypeSymbol, '+', compilation, classSymbol, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                Constants.ModexMembers.ZeroOrOneOf => Parse1ParameterQuantifier(expressionSyntax, modexTypeSymbol, '?', compilation, classSymbol, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                Constants.ModexMembers.Times => Parse2ParameterQuantifier(expressionSyntax, semanticModel, modexTypeSymbol, null, compilation, classSymbol, methodSymbolName, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                Constants.ModexMembers.TimesAtLeast => Parse2ParameterQuantifier(expressionSyntax, semanticModel, modexTypeSymbol, ',', compilation, classSymbol, methodSymbolName, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                Constants.ModexMembers.TimesBetween => ParseTimesBetween(expressionSyntax, semanticModel, modexTypeSymbol, compilation, classSymbol, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                #endregion

                #region Alternation Constructs
                "op_BitwiseOr" => ParseOr(expressionSyntax, modexTypeSymbol, compilation, classSymbol, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                #endregion

                "op_Addition" => ParseAddition(expressionSyntax, modexTypeSymbol, compilation, classSymbol, modexPropertyName, symbolsEncountered, symbolCrumbTrail),
                "op_Implicit" => ParseImplicit(expressionSyntax),
                _ => null
            };
    }

    private ParsedNode? ParseNonModexMember(
        ISymbol symbol,
        INamedTypeSymbol methodSymbolContainingType,
        string methodSymbolName,
        Compilation compilation,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
    {
        if (symbol is not IPropertySymbol)
        {
            _modexEventHandler.HandleReferenceToNonPropertySymbol(methodSymbolContainingType, methodSymbolName);
            return null;
        }

        if (symbolsEncountered.Contains(symbol))
        {
            _modexEventHandler.HandleParsedPropertyCycle(
                methodSymbolContainingType, symbolCrumbTrail, methodSymbolName);
            return null;
        }

        return RunForModexProperty(
            compilation: compilation,
            classSymbol: methodSymbolContainingType,
            modexPropertyName: symbol.Name,
            symbolsEncountered: symbolsEncountered,
            symbolCrumbTrail: symbolCrumbTrail);
    }

    private static ParsedNode AtomicParsedNode(string text)
        => new(Tokens: new(text), Precedence: RegexPrecedence.AtomicElement);

    private ParsedNode? ParseCharacterClass(
        ExpressionSyntax expressionSyntax,
        bool positiveCharacterGroup,
        SemanticModel semanticModel,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        INamedTypeSymbol modexTypeSymbol)
    {
        StringBuilder tokens = new($"[{(positiveCharacterGroup ? null : '^')}");
        var argumentSyntaxes = GetInvocationExpressionArguments(expressionSyntax);
        var count = argumentSyntaxes.Count;
        ICollection<int> firstAndLastCharacters = count == 1 ? _firstCharacterPeriphery : [0, count - 1];
        List<int> lastCharacter = [count - 1];
        foreach (var (argumentSyntax, i) in argumentSyntaxes.Select(static (argumentSyntax, i) => (argumentSyntax, i)))
        {
            var argumentExpressionSyntax = argumentSyntax.Expression;
            if (!IsNullLiteralExpression(argumentExpressionSyntax))
            {
                if (argumentExpressionSyntax is LiteralExpressionSyntax literalExpressionSyntax)
                {
                    tokens.Append(EscapeIfNecessaryIncludingCaret(
                        literalExpressionSyntax, i, firstAndLastCharacters, positiveCharacterGroup));
                }
                else
                {
                    var symbol = semanticModel.GetSymbolInfo(argumentExpressionSyntax).Symbol;
                    if (symbol!.ContainingType.EqualsSymbol(modexTypeSymbol))
                    {
                        switch (symbol.Name)
                        {
                            case Constants.ModexMembers.WordCharacter:
                                tokens.Append(Constants.CharacterClasses.WordCharacter);
                                break;
                            case Constants.ModexMembers.NonWordCharacter:
                                tokens.Append(Constants.CharacterClasses.NonWordCharacter);
                                break;
                            case Constants.ModexMembers.WhitespaceCharacter:
                                tokens.Append(Constants.CharacterClasses.WhitespaceCharacter);
                                break;
                            case Constants.ModexMembers.NonWhitespaceCharacter:
                                tokens.Append(Constants.CharacterClasses.NonWhitespaceCharacter);
                                break;
                            case Constants.ModexMembers.Digit:
                                tokens.Append(Constants.CharacterClasses.Digit);
                                break;
                            case Constants.ModexMembers.NonDigit:
                                tokens.Append(Constants.CharacterClasses.NonDigit);
                                break;
                            case Constants.ModexMembers.CharacterRange:
                                var token = BuildCharacterRangeToken(
                                    argumentExpressionSyntax,
                                    positiveCharacterGroup,
                                    semanticModel,
                                    modexPropertyName,
                                    i);
                                if (token is null && _modexEventHandler.BreaksOnFailures)
                                {
                                    return null;
                                }

                                tokens.Append(token);
                                break;
                        }
                    }
                    else
                    {
                        var token = BuildNonLiteralNonBuiltInTokenIncludingCaret(
                            argumentExpressionSyntax,
                            positiveCharacterGroup,
                            semanticModel,
                            classSymbol,
                            modexMethodName: positiveCharacterGroup ? Constants.ModexMembers.AnyCharacterIn : Constants.ModexMembers.AnyCharacterNotIn,
                            modexPropertyName: modexPropertyName,
                            i,
                            firstAndLastCharacters);
                        if (token is null)
                        {
                            if (_modexEventHandler.BreaksOnFailures)
                            {
                                return null;
                            }
                        }
                        else
                        {
                            tokens.Append(token);
                        }
                    }
                }
            }
        }

        return new(Tokens: tokens.Append(']'), Precedence: RegexPrecedence.AtomicElement);

        string? BuildCharacterRangeToken(
            ExpressionSyntax argumentExpressionSyntax,
            bool positiveCharacterGroup,
            SemanticModel semanticModel,
            string modexPropertyName,
            int i)
        {
            var characterRangeArgumentSyntaxes = GetInvocationExpressionArguments(argumentExpressionSyntax);
            var fromToken = BuildFromCharacterToken(
                characterRangeArgumentSyntaxes[0].Expression, positiveCharacterGroup, semanticModel, i, _firstCharacterPeriphery);
            if (fromToken is null && _modexEventHandler.BreaksOnFailures)
            {
                return null;
            }

            var toToken = BuildToCharacterToken(
                characterRangeArgumentSyntaxes[1].Expression, semanticModel, i, lastCharacter, modexPropertyName);
            return fromToken is null || toToken is null ? null : $"{fromToken}-{toToken}";
        }

        string BuildFromCharacterToken(
            ExpressionSyntax expressionSyntax,
            bool positiveCharacterGroup,
            SemanticModel semanticModel,
            int i,
            ICollection<int> periphery)
            => expressionSyntax is LiteralExpressionSyntax literalExpressionSyntax
                ? EscapeIfNecessaryIncludingCaret(
                    literalExpressionSyntax, i, periphery, positiveCharacterGroup)
                : BuildNonLiteralNonBuiltInTokenIncludingCaret(
                    expressionSyntax,
                    positiveCharacterGroup,
                    semanticModel,
                    classSymbol,
                    modexMethodName: Constants.ModexMembers.CharacterRange,
                    modexPropertyName: modexPropertyName,
                    i,
                    periphery)!;

        static string EscapeIfNecessaryIncludingCaret(
            LiteralExpressionSyntax literalExpressionSyntax,
            int i,
            ICollection<int> periphery,
            bool positiveCharacterGroup)
            => EscapeCharRangeTokenIfNecessaryIncludingCaret(
                literalExpressionSyntax.Token.ValueText, i, periphery, positiveCharacterGroup);

        string BuildToCharacterToken(
            ExpressionSyntax expressionSyntax,
            SemanticModel semanticModel,
            int i,
            ICollection<int> periphery,
            string modexPropertyName)
            => expressionSyntax is LiteralExpressionSyntax literalExpressionSyntax
                ? EscapeCharRangeTokenIfNecessary(
                    literalExpressionSyntax.Token.ValueText, i, periphery)
                : BuildNonLiteralNonBuiltInToken(
                    expressionSyntax,
                    semanticModel,
                    classSymbol,
                    modexMethodName: Constants.ModexMembers.CharacterRange,
                    modexPropertyName,
                    buildFromConstantValue:
                        constantValue => EscapeCharRangeTokenIfNecessary(constantValue, i, periphery))!;
    }

    private static bool IsNullLiteralExpression(SyntaxNode? syntaxNode)
        => syntaxNode.IsKind(SyntaxKind.NullLiteralExpression);

    private ParsedNode? ParseNamedGroup(
        ExpressionSyntax expressionSyntax,
        SemanticModel semanticModel,
        INamedTypeSymbol modexTypeSymbol,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
    {
        var argumentSyntaxes = GetInvocationExpressionArguments(expressionSyntax);

        var parseResult = ParseAndGetTokens(
            expressionSyntax: argumentSyntaxes[1].Expression,
            modexTypeSymbol,
            compilation,
            classSymbol,
            modexPropertyName: Constants.ModexMembers.NamedGroup,
            symbolsEncountered,
            symbolCrumbTrail);
        if (parseResult is null && _modexEventHandler.BreaksOnFailures)
        {
            return null;
        }

        var groupName = BuildArgumentTokenToAdd(
            classSymbol,
            modexMethodName: Constants.ModexMembers.NamedGroup,
            modexPropertyName,
            argumentSyntaxes[0],
            semanticModel);
        return parseResult is null || groupName is null
            ? null
            : new ParsedNode(
                Tokens: parseResult.Value.Tokens.Insert(index: 0, value: $"(?<{groupName}>").Append(')'),
                Precedence: RegexPrecedence.AtomicElement);
    }

    private ParsedNode? Parse1ParameterQuantifier(
        ExpressionSyntax expressionSyntax,
        INamedTypeSymbol modexTypeSymbol,
        char suffix,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
    {
        var parseResult = ParseAndGetTokens(
            expressionSyntax: GetInvocationExpressionArguments(expressionSyntax).Single().Expression,
            modexTypeSymbol,
            compilation,
            classSymbol,
            modexPropertyName,
            symbolsEncountered,
            symbolCrumbTrail);
        if (parseResult is null)
        {
            return null;
        }

        var (subexpression, tokens) = parseResult.Value;
        SurroundWithParenthesesIfOfLowerPrecedence(subexpression, RegexPrecedence.Quantifier, tokens);
        return new(Tokens: tokens.Append($"{suffix}"), Precedence: RegexPrecedence.Quantifier);
    }

    private static SeparatedSyntaxList<ArgumentSyntax> GetInvocationExpressionArguments(
        ExpressionSyntax expressionSyntax)
        => ((InvocationExpressionSyntax)expressionSyntax).ArgumentList.Arguments;

    private ParsedNode? Parse2ParameterQuantifier(
        ExpressionSyntax expressionSyntax,
        SemanticModel semanticModel,
        INamedTypeSymbol modexTypeSymbol,
        char? suffix,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexMethodName,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
    {
        var invocationExpressionSyntax = (InvocationExpressionSyntax)expressionSyntax;
        var parseResult = ParseAndGetTokens(
            expressionSyntax: GetMemberAccessExpression(invocationExpressionSyntax),
            modexTypeSymbol,
            compilation,
            classSymbol,
            modexMethodName,
            symbolsEncountered,
            symbolCrumbTrail);
        if (parseResult is null && _modexEventHandler.BreaksOnFailures)
        {
            return null;
        }

        var argumentToken = BuildArgumentTokenToAdd(classSymbol, modexMethodName, modexPropertyName, invocationExpressionSyntax.ArgumentList.Arguments[0], semanticModel);
        if (parseResult is null || argumentToken is null)
        {
            return null;
        }

        var (subexpression, tokens) = parseResult.Value;
        SurroundWithParenthesesIfOfLowerPrecedence(subexpression, RegexPrecedence.Quantifier, tokens);
        return new(Tokens: tokens.Append($"{{{argumentToken}{suffix}}}"), Precedence: RegexPrecedence.Quantifier);
    }

    private ParsedNode? ParseTimesBetween(
        ExpressionSyntax expressionSyntax,
        SemanticModel semanticModel,
        INamedTypeSymbol modexTypeSymbol,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
    {
        var invocationExpressionSyntax = (InvocationExpressionSyntax)expressionSyntax;
        var parseResult = ParseAndGetTokens(
            expressionSyntax: GetMemberAccessExpression(invocationExpressionSyntax),
            modexTypeSymbol,
            compilation,
            classSymbol,
            modexPropertyName: Constants.ModexMembers.TimesBetween,
            symbolsEncountered,
            symbolCrumbTrail);
        if (parseResult is null && _modexEventHandler.BreaksOnFailures)
        {
            return null;
        }

        var argumentSyntaxes = invocationExpressionSyntax.ArgumentList.Arguments;
        var argument0Token = BuildArgumentTokenToAdd(
            classSymbol,
            modexMethodName: Constants.ModexMembers.TimesBetween,
            modexPropertyName,
            argumentSyntaxes[0],
            semanticModel);
        if (argument0Token is null && _modexEventHandler.BreaksOnFailures)
        {
            return null;
        }

        var argument1Token = BuildArgumentTokenToAdd(
            classSymbol,
            modexMethodName: Constants.ModexMembers.TimesBetween,
            modexPropertyName,
            argumentSyntaxes[1],
            semanticModel);
        if (parseResult is null || argument0Token is null || argument1Token is null)
        {
            return null;
        }

        var (subexpression, tokens) = parseResult.Value;
        SurroundWithParenthesesIfOfLowerPrecedence(subexpression, RegexPrecedence.Quantifier, tokens);
        return new(
            Tokens: tokens.Append($"{{{argument0Token},{argument1Token}}}"), Precedence: RegexPrecedence.Quantifier);
    }

    private static ExpressionSyntax GetMemberAccessExpression(InvocationExpressionSyntax invocationExpressionSyntax)
        => ((MemberAccessExpressionSyntax)invocationExpressionSyntax.Expression).Expression;

    private (ParsedNode, StringBuilder Tokens)? ParseAndGetTokens(
        ExpressionSyntax expressionSyntax,
        INamedTypeSymbol modexTypeSymbol,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
    {
        var parsedNode = Parse(
            expressionSyntax,
            modexTypeSymbol,
            compilation,
            classSymbol,
            modexPropertyName,
            symbolsEncountered,
            symbolCrumbTrail);
        if (parsedNode is null)
        {
            return null;
        }

        var tokens = parsedNode.Tokens;
        return tokens is null ? null : (parsedNode, tokens);
    }

    private ParsedNode? ParseOr(
        ExpressionSyntax expressionSyntax,
        INamedTypeSymbol modexTypeSymbol,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
        => ParseBinary(
            expressionSyntax,
            modexTypeSymbol,
            compilation,
            classSymbol,
            modexPropertyName,
            symbolsEncountered,
            symbolCrumbTrail,
            joinLeftAndRight: (_, _, leftTokens, _) => leftTokens.Append('|'),
            RegexPrecedence.Alternation);

    private ParsedNode? ParseAddition(
        ExpressionSyntax expressionSyntax,
        INamedTypeSymbol modexTypeSymbol,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail)
        => ParseBinary(
            expressionSyntax,
            modexTypeSymbol,
            compilation,
            classSymbol,
            modexPropertyName,
            symbolsEncountered,
            symbolCrumbTrail,
            joinLeftAndRight: (parsedLeft, parsedRight, leftTokens, rightTokens) =>
            {
                SurroundWithParenthesesIfOfLowerPrecedence(parsedLeft, RegexPrecedence.Concatenation, leftTokens);
                SurroundWithParenthesesIfOfLowerPrecedence(parsedRight, RegexPrecedence.Concatenation, rightTokens);
            },
            RegexPrecedence.Concatenation);

    private ParsedNode? ParseBinary(
        ExpressionSyntax expressionSyntax,
        INamedTypeSymbol modexTypeSymbol,
        Compilation compilation,
        INamedTypeSymbol classSymbol,
        string modexPropertyName,
        HashSet<ISymbol> symbolsEncountered,
        Stack<ISymbol> symbolCrumbTrail,
        Action<ParsedNode, ParsedNode, StringBuilder, StringBuilder> joinLeftAndRight,
        RegexPrecedence regexPrecedence)
    {
        var binaryExpressionSyntax = (BinaryExpressionSyntax)expressionSyntax;
        var parsedLeft = Parse(
            binaryExpressionSyntax.Left,
            modexTypeSymbol,
            compilation,
            classSymbol,
            modexPropertyName,
            symbolsEncountered,
            symbolCrumbTrail);
        return parsedLeft is null && _modexEventHandler.BreaksOnFailures
            ? null
            : ParseRight(
                binaryExpressionSyntax,
                parsedLeft,
                modexTypeSymbol,
                compilation,
                symbolsEncountered,
                symbolCrumbTrail,
                joinLeftAndRight,
                regexPrecedence);

        ParsedNode? ParseRight(
            BinaryExpressionSyntax binaryExpressionSyntax,
            ParsedNode? parsedLeft,
            INamedTypeSymbol modexTypeSymbol,
            Compilation compilation,
            HashSet<ISymbol> symbolsEncountered,
            Stack<ISymbol> symbolCrumbTrail,
            Action<ParsedNode, ParsedNode, StringBuilder, StringBuilder> joinLeftAndRight,
            RegexPrecedence regexPrecedence)
        {
            var parsedRight = Parse(
                binaryExpressionSyntax.Right,
                modexTypeSymbol,
                compilation,
                classSymbol,
                modexPropertyName,
                symbolsEncountered,
                symbolCrumbTrail);
            return parsedLeft is null || parsedRight is null
                ? null
                : MergeLeftAndRight(parsedLeft, parsedRight, joinLeftAndRight, regexPrecedence);
        }

        ParsedNode? MergeLeftAndRight(
            ParsedNode parsedLeft,
            ParsedNode parsedRight,
            Action<ParsedNode, ParsedNode, StringBuilder, StringBuilder> joinLeftAndRight,
            RegexPrecedence regexPrecedence)
        {
            var leftTokens = parsedLeft.Tokens;
            return leftTokens is null
                ? parsedRight
                : MergeNonNullLeftAndRight(parsedLeft, parsedRight, leftTokens, joinLeftAndRight, regexPrecedence);
        }

        ParsedNode? MergeNonNullLeftAndRight(
            ParsedNode parsedLeft,
            ParsedNode parsedRight,
            StringBuilder leftTokens,
            Action<ParsedNode, ParsedNode, StringBuilder, StringBuilder> joinLeftAndRight,
            RegexPrecedence regexPrecedence)
        {
            var rightTokens = parsedRight.Tokens;
            return rightTokens is null
                ? parsedLeft
                : MergeNonNullLeftAndNonNullRight(
                    parsedLeft, parsedRight, leftTokens, rightTokens, joinLeftAndRight, regexPrecedence);
        }

        ParsedNode MergeNonNullLeftAndNonNullRight(
            ParsedNode parsedLeft,
            ParsedNode parsedRight,
            StringBuilder leftTokens,
            StringBuilder rightTokens,
            Action<ParsedNode, ParsedNode, StringBuilder, StringBuilder> joinLeftAndRight,
            RegexPrecedence regexPrecedence)
        {
            joinLeftAndRight(parsedLeft, parsedRight, leftTokens, rightTokens);
            leftTokens.Append(rightTokens.ToString());
            return new(Tokens: leftTokens, Precedence: regexPrecedence);
        }
    }

    private static ParsedNode? ParseImplicit(ExpressionSyntax expressionSyntax)
        => ParseImplicit(((LiteralExpressionSyntax)expressionSyntax).Token.ValueText);

    private static ParsedNode? ParseImplicit(string? syntaxTokenValueText)
    {
        return syntaxTokenValueText is null
            ? new(Tokens: new(), Precedence: RegexPrecedence.AtomicElement)
            : new(
                Tokens: new(BuildResultingText(syntaxTokenValueText)),
                Precedence: syntaxTokenValueText.Length == 1 ? RegexPrecedence.AtomicElement : RegexPrecedence.Concatenation);

        static string BuildResultingText(string syntaxTokenValueText)
        {
            foreach (var specialEscape in _specialEscapes)
            {
                syntaxTokenValueText = syntaxTokenValueText.Replace(specialEscape.Key, specialEscape.Value);
            }

            foreach (var escapeCharacter in _escapeCharacters)
            {
                syntaxTokenValueText = syntaxTokenValueText.Replace(escapeCharacter, $@"\\{escapeCharacter}");
            }

            return syntaxTokenValueText;
        }
    }

    private static void SurroundWithParenthesesIfOfLowerPrecedence(
        ParsedNode parsedNode, RegexPrecedence regexPrecedence, StringBuilder tokens)
    {
        if (parsedNode.Precedence < regexPrecedence)
        {
            tokens.Insert(index: 0, value: '(').Append(')');
        }
    }

    private string? BuildArgumentTokenToAdd(
        INamedTypeSymbol classSymbol,
        string modexMethodName,
        string modexPropertyName,
        ArgumentSyntax argumentSyntax,
        SemanticModel semanticModel)
    {
        var expressionSyntax = argumentSyntax.Expression;
        return expressionSyntax is LiteralExpressionSyntax literalExpressionSyntax
            ? literalExpressionSyntax.Token.ValueText
            : BuildNonLiteralNonBuiltInToken(
                expressionSyntax,
                semanticModel,
                classSymbol,
                modexMethodName,
                modexPropertyName,
                buildFromConstantValue: static constantValue => constantValue);
    }

    private string? BuildNonLiteralNonBuiltInTokenIncludingCaret(
        ExpressionSyntax expressionSyntax,
        bool positiveCharacterGroup,
        SemanticModel semanticModel,
        INamedTypeSymbol classSymbol,
        string modexMethodName,
        string modexPropertyName,
        int i,
        ICollection<int> periphery)
        => BuildNonLiteralNonBuiltInToken(
            expressionSyntax,
            semanticModel,
            classSymbol,
            modexMethodName,
            modexPropertyName,
            buildFromConstantValue: constantValue =>
                EscapeCharRangeTokenIfNecessaryIncludingCaret(constantValue, i, periphery, positiveCharacterGroup));

    private string? BuildNonLiteralNonBuiltInToken(
        ExpressionSyntax expressionSyntax,
        SemanticModel semanticModel,
        INamedTypeSymbol classSymbol,
        string modexMethodName,
        string modexPropertyName,
        Func<string, string> buildFromConstantValue)
    {
        var symbol = semanticModel.GetSymbolInfo(expressionSyntax).Symbol;
        if (symbol is IFieldSymbol fieldSymbol && fieldSymbol.IsConst)
        {
            return buildFromConstantValue($"{fieldSymbol.ConstantValue}");
        }

        _modexEventHandler.HandleNonCompileTimeConstantArgumentInModexProperty(
            classSymbol,
            modexPropertyName,
            modexMethodName,
            $"{expressionSyntax}");
        return null;
    }

    private static string EscapeCharRangeTokenIfNecessaryIncludingCaret(
        string text, int i, ICollection<int> periphery, bool positiveCharacterGroup)
        => text == "^" && i == 0 && positiveCharacterGroup
            ? @"\\^"
            : EscapeCharRangeTokenIfNecessary(text, i, periphery);

    private static string EscapeCharRangeTokenIfNecessary(string text, int i, ICollection<int> periphery)
        => _specialEscapes.TryGetValue(text, out var escaped)
            ? escaped
            : text switch
            {
                "]" => @"\\]",
                "-" => periphery.Contains(i) ? text : @"\\-",
                _ => text
            };
}
