using System.Linq;

namespace Microsoft.CodeAnalysis;

internal static class SymbolExtensions
{
    internal static List<TSyntaxNode> GetSyntaxNodes<TSyntaxNode>(this ISymbol symbol) where TSyntaxNode : SyntaxNode
        => symbol.DeclaringSyntaxReferences
            .Select(static syntaxReference => (TSyntaxNode)syntaxReference.GetSyntax())
            .ToList();

    internal static bool IsStringIn(this ISymbol symbol, Compilation compilation)
        => symbol.EqualsSymbol(compilation.GetTypeByMetadataName("System.String"));

    internal static bool EqualsSymbol(this ISymbol symbol, ISymbol? other)
        => symbol.Equals(other, equalityComparer: SymbolEqualityComparer.Default);
}
