namespace Microsoft.CodeAnalysis.Diagnostics;

internal static class SymbolAnalysisContextExtensions
{
    internal static void ReportDiagnostic(
        this SymbolAnalysisContext context,
        DiagnosticDescriptor descriptor,
        Location? location,
        params object?[]? messageArgs)
    {
        context.ReportDiagnostic(Diagnostic.Create(descriptor, location, messageArgs));
    }
}
