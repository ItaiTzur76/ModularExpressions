using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;

namespace ModularExpressions.Generators.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
internal sealed class ModexAnalyzer : DiagnosticAnalyzer
{
    internal const string Diagnostic1Id = "Modex1";
    internal const string Diagnostic2Id = "Modex2";

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        => [Descriptor1, Descriptor2, Descriptor3, Descriptor4, Descriptor5, Descriptor6, Descriptor7];

    internal static readonly DiagnosticDescriptor Descriptor1 = new(
        id: Diagnostic1Id,
        title: $"Methods with the {Constants.GenerateModexAttributeUsageName} attribute can only return string",
        messageFormat: $"{Constants.GenerateModexAttributeUsageName} attribute can only be placed on string-returning methods, but method '{{0}}' returns '{{1}}'",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: "https://GitHub.com/ItaiTzur76/ModularExpressions/blob/main/source-generator-messages/modex1.html");

    internal static readonly DiagnosticDescriptor Descriptor2 = new(
        id: Diagnostic2Id,
        title: $"Methods with the {Constants.GenerateModexAttributeUsageName} attribute must be parameterless",
        messageFormat: $"{Constants.GenerateModexAttributeUsageName} attribute can only be placed on parameterless methods, but method '{{0}}' receives {{1}}",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: "https://GitHub.com/ItaiTzur76/ModularExpressions/blob/main/source-generator-messages/modex2.html");

    internal static readonly DiagnosticDescriptor Descriptor3 = new(
        id: "Modex3",
        title: $"Part of calculation of {Constants.GenerateModexAttributeUsageName} attribute is not a property",
        messageFormat: $"\"{{0}}\" does not exist as the name of a property in class '{{1}}' so it cannot be used as part of the calculation of a {Constants.GenerateModexAttributeUsageName} attribute",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: "https://GitHub.com/ItaiTzur76/ModularExpressions/blob/main/source-generator-messages/modex3.html");

    internal static readonly DiagnosticDescriptor Descriptor4 = new(
        id: "Modex4",
        title: $"Part of calculation of {Constants.GenerateModexAttributeUsageName} attribute is not an arrow property",
        messageFormat: $"Property '{{0}}' in class '{{1}}' is not an arrow property so it cannot be used as part of the calculation of a {Constants.GenerateModexAttributeUsageName} attribute",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: "https://GitHub.com/ItaiTzur76/ModularExpressions/blob/main/source-generator-messages/modex4.html");

    internal static readonly DiagnosticDescriptor Descriptor5 = new(
        id: "Modex5",
        title: $"Part of calculation of {Constants.GenerateModexAttributeUsageName} attribute is a non-property symbol",
        messageFormat: $"'{{0}}' in class '{{1}}' is not a property so it cannot be used as part of the calculation of a {Constants.GenerateModexAttributeUsageName} attribute",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: "https://GitHub.com/ItaiTzur76/ModularExpressions/blob/main/source-generator-messages/modex5.html");

    internal static readonly DiagnosticDescriptor Descriptor6 = new(
        id: "Modex6",
        title: $"Cycle found in calculation of {Constants.GenerateModexAttributeUsageName} attribute",
        messageFormat: "A Modex-property structure must be a DAG, but the following property cycle was found under class '{0}': {1}",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: "https://GitHub.com/ItaiTzur76/ModularExpressions/blob/main/source-generator-messages/modex6.html");

    internal static readonly DiagnosticDescriptor Descriptor7 = new(
        id: "Modex7",
        title: $"Part of calculation of {Constants.GenerateModexAttributeUsageName} attribute is not a compile-time constant",
        messageFormat: $"The value of property '{{0}}' in class '{{1}}' contains a call to '{{2}}' with the argument '{{3}}' which is not a compile-time constant so it cannot be used as part of the calculation of a {Constants.GenerateModexAttributeUsageName} attribute",
        category: "Usage",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true,
        helpLinkUri: "https://GitHub.com/ItaiTzur76/ModularExpressions/blob/main/source-generator-messages/modex7.html");

    public override void Initialize(AnalysisContext context)
    {
        context.EnableConcurrentExecution();
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.RegisterSymbolAction(AnalyzeNode, SymbolKind.Method);
    }

    private static void AnalyzeNode(SymbolAnalysisContext context)
    {
        var decoratedMethodSymbol = context.Symbol;
        var generateModexAttributes = GetGenerateModexAttributes(decoratedMethodSymbol);
        if (generateModexAttributes.Count == 0)
        {
            return;
        }

        ReportReturnTypeIfNotString((IMethodSymbol)decoratedMethodSymbol, context);
        new Parser(new ModexAnalyzerEventHandler(context)).RunForMethodWithModexAttribute(
            existingGenerateModexAttributes: generateModexAttributes,
            compilation: context.Compilation,
            classSymbol: decoratedMethodSymbol.ContainingType,
            decoratedMethodSymbol: decoratedMethodSymbol);
    }

    private static List<AttributeData> GetGenerateModexAttributes(ISymbol decoratedMethodSymbol)
        => [.. decoratedMethodSymbol
                .GetAttributes()
                .Where(static attributeData => attributeData.AttributeClass!.ToString() == Constants.GenerateModexAttributeMetadataName)];

    private static void ReportReturnTypeIfNotString(IMethodSymbol decoratedMethodSymbol, SymbolAnalysisContext context)
    {
        var returnType = decoratedMethodSymbol.ReturnType;
        if (!returnType.IsStringIn(context.Compilation))
        {
            context.ReportDiagnostic(
                descriptor: Descriptor1,
                location: decoratedMethodSymbol.DeclaringSyntaxReferences
                    .Select(static syntaxReference => (MethodDeclarationSyntax)syntaxReference.GetSyntax())
                    .First()
                    .ReturnType
                    .GetLocation(),
                decoratedMethodSymbol.Name,
                returnType.ToDisplayString());
        }
    }
}
