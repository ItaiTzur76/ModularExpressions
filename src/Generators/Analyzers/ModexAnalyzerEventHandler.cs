using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Linq;

namespace ModularExpressions.Generators.Analyzers;

internal sealed class ModexAnalyzerEventHandler(SymbolAnalysisContext context) : IModexEventHandler
{
    private readonly SymbolAnalysisContext _context = context;

    public bool BreaksOnFailures => false;

    public void HandleDecoratedMethodWithParameters(IMethodSymbol methodSymbol, int parameters)
    {
        _context.ReportDiagnostic(
            descriptor: ModexAnalyzer.Descriptor2,
            location: methodSymbol.GetSyntaxNodes<MethodDeclarationSyntax>()[0].ParameterList.GetLocation(),
            methodSymbol.Name,
            parameters == 1 ? "1 parameter" : $"{parameters} parameters");
    }

    public void HandleMissingModexProperty(INamedTypeSymbol classSymbol, string modexPropertyName)
    {
        ReportSimpleModexDiagnostic(descriptor: ModexAnalyzer.Descriptor3, modexPropertyName, classSymbol);
    }

    public void HandleNonArrowModexProperty(ISymbol classSymbol, string modexPropertyName)
    {
        ReportSimpleModexDiagnostic(descriptor: ModexAnalyzer.Descriptor4, modexPropertyName, classSymbol);
    }

    public void HandleReferenceToNonPropertySymbol(ISymbol classSymbol, string nonModexPropertyName)
    {
        ReportSimpleModexDiagnostic(descriptor: ModexAnalyzer.Descriptor5, nonModexPropertyName, classSymbol);
    }

    public void HandleParsedPropertyCycle(ISymbol classSymbol, IEnumerable<ISymbol> symbols, string cyclingPropertyName)
    {
        ReportDiagnosticOnContextSymbolLocation(
            descriptor: ModexAnalyzer.Descriptor6,
            GetName(classSymbol),
            symbols.Aggregate(cyclingPropertyName, static (aggregated, symbol) => $"{symbol.Name} » {aggregated}"));
    }

    public void HandleNonCompileTimeConstantArgumentInModexProperty(
        ISymbol classSymbol, string modexPropertyName, string modexMethodName, string argument)
    {
        ReportDiagnosticOnContextSymbolLocation(
            descriptor: ModexAnalyzer.Descriptor7, modexPropertyName, GetName(classSymbol), modexMethodName, argument);
    }

    private void ReportSimpleModexDiagnostic(DiagnosticDescriptor descriptor, string propertyName, ISymbol symbol)
    {
        ReportDiagnosticOnContextSymbolLocation(descriptor: descriptor, propertyName, GetName(symbol));
    }

    private static string GetName(ISymbol symbol)
    {
        var containingNamespace = symbol.ContainingNamespace;
        var className = symbol.ToDisplayString();
        return containingNamespace.IsGlobalNamespace ? className : className.Substring(containingNamespace.ToDisplayString().Length + 1);
    }

    private void ReportDiagnosticOnContextSymbolLocation(DiagnosticDescriptor descriptor, params object?[]? messageArgs)
    {
        _context.ReportDiagnostic(descriptor: descriptor, location: _context.Symbol.Locations[0], messageArgs);
    }
}
