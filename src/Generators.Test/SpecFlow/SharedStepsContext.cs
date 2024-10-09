using System.Text.RegularExpressions;

namespace ModularExpressions.Generators.Test.SpecFlow;

internal sealed class SharedStepsContext
{
    internal string? Input { get; set; }
    internal MatchCollection? Matches { get; private set; }

    internal void MatchPattern(string pattern)
    {
        Matches = Regex.Matches(Input!, pattern);
    }
}
