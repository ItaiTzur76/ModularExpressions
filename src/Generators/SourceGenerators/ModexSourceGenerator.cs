using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModularExpressions.Generators.Model;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ModularExpressions.Generators.SourceGenerators;

[Generator]
internal sealed class ModexGenerator : IIncrementalGenerator
{
    private const string CharacterClassElementClassName = "CharacterClassElement";
    private const string XmlDocModexElement = "modex";
    private const string GenerateModexAttributeHintName = $"{Constants.GenerateModexAttributeMetadataName}.g.cs";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider.ForAttributeWithMetadataName(
            fullyQualifiedMetadataName: Constants.GenerateModexAttributeMetadataName,
            predicate: static (syntaxNode, _) => IsSyntaxTarget(syntaxNode),
            transform: static (context, _) => GetSemanticTarget(context));
        context.RegisterSourceOutput(classes, Execute);
        context.RegisterPostInitializationOutput(PostInitializationOutput);
    }

    private static bool IsSyntaxTarget(SyntaxNode syntaxNode) => syntaxNode is MethodDeclarationSyntax;

    private static MethodToGenerate? GetSemanticTarget(GeneratorAttributeSyntaxContext context)
    {
        var decoratedMethodSymbol = context.TargetSymbol;
        var classSymbol = decoratedMethodSymbol.ContainingType;
        var parsedNode = new Parser(new ModexSourceGeneratorEventHandler())
            .RunForMethodWithModexAttribute(
                existingGenerateModexAttributes: [.. context.Attributes],
                compilation: context.SemanticModel.Compilation,
                classSymbol: classSymbol,
                decoratedMethodSymbol: decoratedMethodSymbol);
        return parsedNode is null ? null : GetSemanticTarget(context, decoratedMethodSymbol, parsedNode, classSymbol);
    }

    private static MethodToGenerate? GetSemanticTarget(
        GeneratorAttributeSyntaxContext context, ISymbol methodSymbol, ParsedNode parsedNode, ISymbol classSymbol)
    {
        var pattern = GetPattern(parsedNode);
        var namespaceName = GetNamespaceName(classSymbol);
        return new(
            NamespaceName: namespaceName,
            ClassMetadataName: GetMetadataName(classSymbol),
            ClassName: GetName(namespaceName, classSymbol),
            MethodName: methodSymbol.Name,
            LeadingTrivia: GetLeadingTrivia(context, pattern),
            Accessibility: methodSymbol.DeclaredAccessibility,
            IsStatic: methodSymbol.IsStatic,
            Pattern: pattern);

        static string GetPattern(ParsedNode parsedNode)
        {
            var tokens = parsedNode.Tokens;
            return tokens is null ? "null" : $"\"{tokens}\"";
        }

        static string? GetNamespaceName(ISymbol symbol)
        {
            var containingNamespace = symbol.ContainingNamespace;
            return containingNamespace.IsGlobalNamespace ? null : containingNamespace.ToDisplayString();
        }

        static string GetMetadataName(ISymbol symbol)
        {
            Stack<string> metadataNames = [];
            for (var currentSymbol = symbol; currentSymbol is not null; currentSymbol = currentSymbol.ContainingType)
            {
                metadataNames.Push(currentSymbol.MetadataName);
            }

            return string.Join(".", metadataNames);
        }
    }

    private static string GetName(string? namespaceName, ISymbol symbol)
    {
        var symbolDisplayString = symbol.ToDisplayString();
        return namespaceName is null ? symbolDisplayString : symbolDisplayString.Substring(namespaceName.Length + 1);
    }

    private static string? GetLeadingTrivia(GeneratorAttributeSyntaxContext context, string pattern)
    {
        var syntaxTrivia = ((MemberDeclarationSyntax)context.TargetNode).AttributeLists[0]
            .OpenBracketToken
            .LeadingTrivia
            .SingleOrDefault(static syntaxTrivia => syntaxTrivia.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia));
        return syntaxTrivia.IsKind(SyntaxKind.None) ? null : GetNonNoneLeadingTrivia(syntaxTrivia, pattern);
    }

    private static string? GetNonNoneLeadingTrivia(SyntaxTrivia syntaxTrivia, string pattern)
    {
        var xmlDocModexElementRegexPattern = $"(<\\s*{XmlDocModexElement}\\s*/>)";
        var syntaxTriviaString = syntaxTrivia.ToString();
        return Regex.IsMatch(syntaxTriviaString, xmlDocModexElementRegexPattern)
            ? Regex.Replace(syntaxTriviaString, xmlDocModexElementRegexPattern, pattern.Replace("&", "&amp;").Replace("<", "&lt;"), RegexOptions.ExplicitCapture)
                   .Split([@"
    "], StringSplitOptions.RemoveEmptyEntries)
                   .Aggregate("/// ", (aggregate, segment) => $@"{aggregate}{segment.TrimStart()}
        ")
            : null;
    }

    private static void PostInitializationOutput(IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource(hintName: GenerateModexAttributeHintName, source: Source);
    }

    private static string Source
    {
        get
        {
            var generateModexAttributeSummary = new[]
            {
                "/// <summary>",
                $"/// Generates a <see cref=\"string\" /> Regex-pattern that matches a specified <see cref=\"{Constants.ModexClassName}\" /> property.",
                $"/// <para><i>Tip</i>: this attribute also substitutes any instance of \"<b>&lt;{XmlDocModexElement} /></b>\" in the XML-documentation of its method with the resulting pattern.</para>",
                "/// <para><i>Note</i>: to prevent a redundant reference from this project to the <i>ModularExpressions.Generators</i> assembly at runtime, make sure the PackageReference to <i>ModularExpressions.Generators</i> has a <b>ReferenceOutputAssembly=\"false\"</b> attribute in this project's definition file.</para>",
                "/// <para><i>Note</i>: IntelliSense might not suggest using the <see cref=\"ModularExpressions\" /> package as a potential fix when trying to use this attribute. Adding a <b>&lt;Using Include=\"ModularExpressions\" /></b> node in an &lt;ItemGroup> in this project's definition file will solve this.</para>",
                "/// </summary>"
            };
            return $@"namespace {Constants.ModularExpressionsNamespace};

/// <summary>
/// Represents an immutable modular expression.
/// </summary>
internal abstract class {Constants.ModexClassName}
{{
    private {Constants.ModexClassName}() {{ }}

    #region Character Escapes

{GenerateModexProperty(
    name: Constants.ModexMembers.Tab,
    summary: "Matches a tab",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-escapes-in-regular-expressions",
    helpLinkText: "Character Escapes")}
{GenerateModexProperty(
    name: Constants.ModexMembers.CarriageReturn,
    summary: "Matches a carriage return",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-escapes-in-regular-expressions",
    helpLinkText: "Character Escapes")}
{GenerateModexProperty(
    name: Constants.ModexMembers.NewLine,
    summary: "Matches a new line",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-escapes-in-regular-expressions",
    helpLinkText: "Character Escapes")}
    #endregion

    #region Character Classes

{GenerateSummary(
    "Matches any single character in <paramref name=\"characterClassElements\" />",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#positive-character-group--",
    "Positive character group")}
    {GenerateParam("characterClassElements", "The list of elements of which one should match")}
    {GenerateModexMethod($"{Constants.ModexMembers.AnyCharacterIn}(params {CharacterClassElementClassName}[] characterClassElements)", isStatic: true)}
{GenerateSummary(
    "Matches any single character that is not in <paramref name=\"characterClassElements\" />",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#negative-character-group-",
    "Negative character group")}
    {GenerateParam("characterClassElements", "The list of elements of which none should match")}
    {GenerateModexMethod($"{Constants.ModexMembers.AnyCharacterNotIn}(params {CharacterClassElementClassName}[] characterClassElements)", isStatic: true)}
{GenerateSummary(
    $"Specifies a range of characters used in <see cref=\"{Constants.ModexMembers.AnyCharacterIn}\">{Constants.ModexMembers.AnyCharacterIn}</see> or <see cref=\"{Constants.ModexMembers.AnyCharacterNotIn}\">{Constants.ModexMembers.AnyCharacterNotIn}</see>",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions",
    "Character classes in regular expressions")}
    {GenerateParam("first", "The character that begins the range.")}
    {GenerateParam("last", "The character that ends the range.")}
    {GenerateMethod(returnType: CharacterClassElementClassName, $"{Constants.ModexMembers.CharacterRange}(char first, char last)", isStatic: true)}
{GenerateModexProperty(
    name: Constants.ModexMembers.NonNewLineCharacter,
    summary: "Matches any single character except new-line",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#any-character-",
    helpLinkText: "Any character")}
{GenerateCharacterClassElementProperty(
    name: Constants.ModexMembers.WordCharacter,
    summary: "Matches any word character",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#word-character-w",
    helpLinkText: "Word character")}
{GenerateCharacterClassElementProperty(
    name: Constants.ModexMembers.NonWordCharacter,
    summary: "Matches any non-word character",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#non-word-character-w",
    helpLinkText: "Non-word character")}
{GenerateCharacterClassElementProperty(
    name: Constants.ModexMembers.WhitespaceCharacter,
    summary: "Matches any whitespace character",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#whitespace-character-s",
    helpLinkText: "Whitespace character")}
{GenerateCharacterClassElementProperty(
    name: Constants.ModexMembers.NonWhitespaceCharacter,
    summary: "Matches any non-whitespace character",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#non-whitespace-character-s",
    helpLinkText: "Non-whitespace character")}
{GenerateCharacterClassElementProperty(
    name: Constants.ModexMembers.Digit,
    summary: "Matches any decimal digit",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#decimal-digit-character-d",
    helpLinkText: "Decimal digit character")}
{GenerateCharacterClassElementProperty(
    name: Constants.ModexMembers.NonDigit,
    summary: "Matches any character other than a decimal digit",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/character-classes-in-regular-expressions#non-digit-character-d",
    helpLinkText: "Non-digit character")}
    #endregion

    #region Anchors

{GenerateModexProperty(
    name: Constants.ModexMembers.Beginning,
    summary: "The match must start at the beginning of the string",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/anchors-in-regular-expressions#start-of-string-or-line-",
    helpLinkText: "Start of String or Line")}
{GenerateModexProperty(
    name: Constants.ModexMembers.End,
    summary: "The match must occur at the end of the string or before <b>\\n</b> at the end of the string",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/anchors-in-regular-expressions#end-of-string-or-line-",
    helpLinkText: "End of String or Line")}
{GenerateModexProperty(
    name: Constants.ModexMembers.WordBoundary,
    summary: "The match must occur on a boundary between a <see cref=\"WordCharacter\">WordCharacter</see> (alphanumeric) and a <see cref=\"NonWordCharacter\">NonWordCharacter</see> (nonalphanumeric) character",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/anchors-in-regular-expressions#word-boundary-b",
    helpLinkText: "Word Boundary")}
{GenerateModexProperty(
    name: Constants.ModexMembers.WordNonBoundary,
    summary: "The match must not occur on a <see cref=\"WordBoundary\">WordBoundary</see>",
    helpLinkUri: "https://learn.microsoft.com/en-us/dotnet/standard/base-types/anchors-in-regular-expressions#non-word-boundary-b",
    helpLinkText: "Non-Word Boundary")}
    #endregion

    #region Grouping Constructs

{GenerateSummary(
    "Captures the matched subexpression into a named group",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/grouping-constructs-in-regular-expressions#named-matched-subexpressions",
    "Named matched subexpressions")}
    {GenerateParam("name", "The name of the group")}
    {GenerateParam("subexpression", "The expression to be captured")}
    {GenerateModexMethod($"{Constants.ModexMembers.NamedGroup}(string name, {Constants.ModexClassName} subexpression)", isStatic: true)}
    #endregion

    #region Quantifiers

{GenerateSummary(
    "Matches the provided <paramref name=\"subexpression\" /> zero or more times",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/quantifiers-in-regular-expressions#match-zero-or-more-times-",
    "Match Zero or More Times")}
    {GenerateParam("subexpression", "The expression to be matched zero or more times")}
    {GenerateModexMethod($"{Constants.ModexMembers.ZeroOrMoreOf}({Constants.ModexClassName} subexpression)", isStatic: true)}
{GenerateSummary(
    "Matches the provided <paramref name=\"subexpression\" /> one or more times",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/quantifiers-in-regular-expressions#match-one-or-more-times-",
    "Match One or More Times")}
    {GenerateParam("subexpression", "The expression to be matched one or more times")}
    {GenerateModexMethod($"{Constants.ModexMembers.OneOrMoreOf}({Constants.ModexClassName} subexpression)", isStatic: true)}
{GenerateSummary(
    "Matches the provided <paramref name=\"subexpression\" /> zero or one time",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/quantifiers-in-regular-expressions#match-zero-or-one-time-",
    "Match Zero or One Time")}
    {GenerateParam("subexpression", "The expression to be matched zero or one time")}
    {GenerateModexMethod($"{Constants.ModexMembers.ZeroOrOneOf}({Constants.ModexClassName} subexpression)", isStatic: true)}
{GenerateSummary(
    "Matches the expression exactly <paramref name=\"times\" /> times",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/quantifiers-in-regular-expressions#match-exactly-n-times-n",
    "Match Exactly n Times")}
    {GenerateParam("times", "The exact number of times the expression should be matched")}
    {GenerateModexMethod($"{Constants.ModexMembers.Times}(int times)", isStatic: false)}
{GenerateSummary(
    "Matches the expression at least <paramref name=\"times\" /> times",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/quantifiers-in-regular-expressions#match-at-least-n-times-n",
    "Match at Least n Times")}
    {GenerateParam("times", "The minimum number of times the expression should be matched")}
    {GenerateModexMethod($"{Constants.ModexMembers.TimesAtLeast}(int times)", isStatic: false)}
{GenerateSummary(
    "Matches the expression at least <paramref name=\"min\" /> times, but no more than <paramref name=\"max\" /> times",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/quantifiers-in-regular-expressions#match-between-n-and-m-times-nm",
    "Match Between n and m Times")}
    {GenerateParam("min", "The minimum number of times the expression should be matched")}
    {GenerateParam("max", "The maximum number of times the expression should be matched")}
    {GenerateModexMethod($"{Constants.ModexMembers.TimesBetween}(int min, int max)", isStatic: false)}
    #endregion

    #region Alternation Constructs

{GenerateSummary(
    "Matches any one element separated by the vertical bar (<b>|</b>) character",
    "https://learn.microsoft.com/en-us/dotnet/standard/base-types/alternation-constructs-in-regular-expressions#pattern-matching-with-",
    "Pattern Matching with |")}
    public static {Constants.ModexClassName} operator |({Constants.ModexClassName} subexpression1, {Constants.ModexClassName} subexpression2) => null;

    #endregion

    /// <summary>
    /// Concatenates two modular expressions.
    /// </summary>
    public static {Constants.ModexClassName} operator +({Constants.ModexClassName} subexpression1, {Constants.ModexClassName} subexpression2) => null;

    public static implicit operator {Constants.ModexClassName}(string value) => null;

    /// <summary>
    /// Represents a single element in a character class.
    /// </summary>
    internal sealed class {CharacterClassElementClassName} : {Constants.ModexClassName}
    {{
        private {CharacterClassElementClassName}() {{ }}

        /// <summary>
        /// Generates a character-class element from a given character.
        /// </summary>
        public static implicit operator {CharacterClassElementClassName}(char character) => null;
    }}
}}

{string.Join(@"
", generateModexAttributeSummary)}
[AttributeUsage(AttributeTargets.Method)]
internal sealed class {Constants.GenerateModexAttributeClassName} : Attribute
{{
    {string.Join(@"
    ", generateModexAttributeSummary)}
    /// <param name=""modexPropertyName"">
    /// The name of a <see cref=""Modex"" /> property representing the <see cref=""string"" /> Regex-pattern to be generated by this method.
    /// </param>
    public {Constants.GenerateModexAttributeClassName}(string modexPropertyName) {{ }}
}}";

            static string GenerateModexProperty(string name, string summary, string helpLinkUri, string helpLinkText)
                => GenerateProperty(Constants.ModexClassName, name, summary, helpLinkUri, helpLinkText);

            static string GenerateCharacterClassElementProperty(string name, string summary, string helpLinkUri, string helpLinkText)
                => GenerateProperty(CharacterClassElementClassName, name, summary, helpLinkUri, helpLinkText);

            static string GenerateProperty(string type, string name, string summary, string helpLinkUri, string helpLinkText)
                => $"""
                   {GenerateSummary(summary, helpLinkUri, helpLinkText)}
                       internal static {type} {name} => null;

                   """;

            static string GenerateSummary(string summary, string helpLinkUri, string helpLinkText)
                => $"""
                       /// <summary>
                       /// {summary}.
                       /// For more information see <see href="{helpLinkUri}">{helpLinkText}</see>.
                       /// </summary>
                   """;

            static string GenerateParam(string name, string summary)
                => $"""
                   /// <param name="{name}">{summary}.</param>
                   """;

            static string GenerateModexMethod(string signature, bool isStatic)
                => GenerateMethod(returnType: Constants.ModexClassName, signature, isStatic);

            static string GenerateMethod(string returnType, string signature, bool isStatic)
                => $"""
                   internal {(isStatic ? "static " : null)}{returnType} {signature} => null;

                   """;
        }
    }

    private static void Execute(SourceProductionContext context, MethodToGenerate? methodToGenerate)
    {
        if (methodToGenerate is not null)
        {
            ExecuteForNonNull(context, methodToGenerate);
        }
    }

    private static void ExecuteForNonNull(SourceProductionContext context, MethodToGenerate methodToGenerate)
    {
        var namespaceName = methodToGenerate.NamespaceName;
        var methodName = methodToGenerate.MethodName;
        context.AddSource(
            hintName: GetHintName(namespaceName, methodToGenerate, methodName),
            source: GetSource(methodToGenerate, namespaceName, methodName));
    }

    private static string GetHintName(string? namespaceName, MethodToGenerate methodToGenerate, string methodName)
        => $"{namespaceName}.{methodToGenerate.ClassMetadataName}.{methodName}.g.cs";

    private static string GetSource(MethodToGenerate methodToGenerate, string? namespaceName, string methodName)
        => $@"{(namespaceName is null ? null : $@"namespace {namespaceName};

")}{GenerateSource(
    classNames: methodToGenerate.ClassName.Split('.'),
    current: 0,
    signature: $"{methodToGenerate.LeadingTrivia}{methodToGenerate.Accessibility.ToString().ToLowerInvariant()} {(methodToGenerate.IsStatic ? "static " : null)}partial string {methodName}()",
    modexPattern: methodToGenerate.Pattern)}";

    private static string GenerateSource(string[] classNames, int current, string signature, string? modexPattern)
    {
        var indentation = string.Empty.PadRight(current * 4, ' ');
        return current == classNames.Length
            ? $@"{signature.Split([@"
"], StringSplitOptions.RemoveEmptyEntries).Select(static segment => segment.TrimStart()).Aggregate(string.Empty, (aggregated, newOne) => $@"{aggregated}
{indentation}{newOne}")}
{indentation}    => {modexPattern};"
            : $$"""
              {{(current == 0 ? null : @"
")}}{{indentation}}partial class {{classNames[current]}}
              {{indentation}}{{{GenerateSource(classNames, current + 1, signature, modexPattern)}}
              {{indentation}}}
              """;
    }
}
