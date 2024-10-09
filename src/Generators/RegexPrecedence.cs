namespace ModularExpressions.Generators;

/// <summary>
/// Represents the precedence of <see cref="ModularExpressions.Generators.Model.ParsedNode">a ParsedNode record</see>.
/// <br />
/// See <see href="https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2010/ae5bf541(v=vs.100)#order-of-precedence">Order of Precedence</see> for definition.
/// </summary>
internal enum RegexPrecedence
{
    Alternation,
    Concatenation,
    Quantifier,
    AtomicElement
}
