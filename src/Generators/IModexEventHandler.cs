namespace ModularExpressions.Generators;

internal interface IModexEventHandler
{
    bool BreaksOnFailures { get; }

    void HandleDecoratedMethodWithParameters(IMethodSymbol methodSymbol, int parameters);

    void HandleMissingModexProperty(INamedTypeSymbol classSymbol, string modexPropertyName);

    void HandleNonArrowModexProperty(ISymbol classSymbol, string modexPropertyName);

    void HandleReferenceToNonPropertySymbol(ISymbol classSymbol, string nonModexPropertyName);

    void HandleParsedPropertyCycle(ISymbol classSymbol, IEnumerable<ISymbol> symbols, string cyclingPropertyName);

    void HandleNonCompileTimeConstantArgumentInModexProperty(
        ISymbol classSymbol, string modexPropertyName, string modexMethodName, string argument);
}
