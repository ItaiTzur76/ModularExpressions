namespace ModularExpressions.Generators.Model;

internal sealed record MethodToGenerate(
    string? NamespaceName,
    string ClassMetadataName,
    string ClassName,
    string MethodName,
    string? LeadingTrivia,
    Accessibility Accessibility,
    bool IsStatic,
    string? Pattern);
