using System.Text;

namespace ModularExpressions.Generators.Model;

internal sealed record ParsedNode(StringBuilder? Tokens, RegexPrecedence Precedence);
