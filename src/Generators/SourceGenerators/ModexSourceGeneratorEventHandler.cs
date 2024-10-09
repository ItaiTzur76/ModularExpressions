namespace ModularExpressions.Generators.SourceGenerators;

internal sealed class ModexSourceGeneratorEventHandler : IModexEventHandler
{
    public bool BreaksOnFailures => true;

    public void HandleDecoratedMethodWithParameters(IMethodSymbol methodSymbol, int parameters)
    {
    }

    public void HandleMissingModexProperty(INamedTypeSymbol classSymbol, string modexPropertyName)
    {
    }

    public void HandleNonArrowModexProperty(ISymbol classSymbol, string modexPropertyName)
    {
    }

    public void HandleReferenceToNonPropertySymbol(ISymbol classSymbol, string nonModexPropertyName)
    {
    }

    public void HandleParsedPropertyCycle(ISymbol classSymbol, IEnumerable<ISymbol> symbols, string cyclingPropertyName)
    {
    }

    public void HandleNonCompileTimeConstantArgumentInModexProperty(
        ISymbol classSymbol, string modexPropertyName, string modexMethodName, string argument)
    {
    }
}
