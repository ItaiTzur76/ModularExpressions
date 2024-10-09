using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using ModularExpressions.Generators.Analyzers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModularExpressions.Generators.CSharp.CodeFixes;

[ExportCodeFixProvider(LanguageNames.CSharp)]
internal sealed class Modex1GenerateModexAttributeOnNonStringMethodCodeFix : ModexCodeFixBase
{
    public Modex1GenerateModexAttributeOnNonStringMethodCodeFix() : base(ModexAnalyzer.Diagnostic1Id)
    {
    }

    protected override string Title => "Change return type to string";

    protected override Func<CancellationToken, Task<Document>> CreateChangedDocumentFactory(Document document, SyntaxNode syntaxNode)
    {
        var typeSyntax = GetNonNullable(syntaxNode);
        return async cancellationToken =>
        {
            var oldRootSyntaxNode = await document.GetSyntaxRootAsync(cancellationToken);
            return GetDocumentWithReplacedNodes(
                document,
                oldRootSyntaxNode,
                oldNode: typeSyntax,
                newNode: SyntaxFactory.ParseTypeName("string").WithTrailingTrivia(typeSyntax.GetTrailingTrivia()));
        };
    }

    private static SyntaxNode GetNonNullable(SyntaxNode syntaxNode)
    {
        var parent = syntaxNode.Parent;
        return parent.IsKind(SyntaxKind.NullableType) ? parent : syntaxNode;
    }
}
