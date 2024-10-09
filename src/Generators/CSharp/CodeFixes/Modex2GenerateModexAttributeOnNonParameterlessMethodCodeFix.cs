using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModularExpressions.Generators.Analyzers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModularExpressions.Generators.CSharp.CodeFixes;

[ExportCodeFixProvider(LanguageNames.CSharp)]
internal sealed class Modex2GenerateModexAttributeOnNonParameterlessMethodCodeFix : ModexCodeFixBase
{
    public Modex2GenerateModexAttributeOnNonParameterlessMethodCodeFix() : base(ModexAnalyzer.Diagnostic2Id)
    {
    }

    protected override string Title => "Remove all parameters";

    protected override Func<CancellationToken, Task<Document>> CreateChangedDocumentFactory(
        Document document, SyntaxNode syntaxNode)
        => async cancellationToken =>
        {
            var parameterListSyntax = (ParameterListSyntax)syntaxNode;
            var oldRootSyntaxNode = await document.GetSyntaxRootAsync(cancellationToken);
            return GetDocumentWithReplacedNodes(
                document,
                oldRootSyntaxNode,
                oldNode: syntaxNode,
                newNode: SyntaxFactory.ParseParameterList(string.Empty)
                                      .WithOpenParenToken(parameterListSyntax.OpenParenToken)
                                      .WithCloseParenToken(parameterListSyntax.CloseParenToken));
        };
}
