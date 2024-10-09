using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModularExpressions.Generators.CSharp.CodeFixes;

internal abstract class ModexCodeFixBase(string diagnosticId) : CodeFixProvider
{
    private readonly ImmutableArray<string> _fixableDiagnosticIds = [diagnosticId];

    public override ImmutableArray<string> FixableDiagnosticIds => _fixableDiagnosticIds;

    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var diagnostic = context.Diagnostics.First();
        var syntaxRoot = await context.Document.GetSyntaxRootAsync()
            ?? throw new InvalidOperationException("No syntax root could be obtained from the document.");
        context.RegisterCodeFix(
            CodeAction.Create(
                title: Title,
                createChangedDocument: CreateChangedDocumentFactory(
                    context.Document, GetDiagnosticParentSyntaxNode(syntaxRoot, diagnostic)),
                equivalenceKey: Title),
            diagnostic);
    }

    private static SyntaxNode GetDiagnosticParentSyntaxNode(SyntaxNode syntaxRoot, Diagnostic diagnostic)
        => syntaxRoot.FindToken(diagnostic.Location.SourceSpan.Start).Parent!;

    protected abstract string Title { get; }

    protected abstract Func<CancellationToken, Task<Document>> CreateChangedDocumentFactory(
        Document document, SyntaxNode syntaxNode);

    protected static Document GetDocumentWithReplacedNodes(
        Document document, SyntaxNode? syntaxNode, SyntaxNode oldNode, SyntaxNode newNode)
        => document.WithSyntaxRoot(syntaxNode!.ReplaceNode(oldNode, newNode));

    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;
}
