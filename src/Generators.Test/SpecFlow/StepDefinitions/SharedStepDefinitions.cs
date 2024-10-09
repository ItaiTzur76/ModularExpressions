using Bogus;
using FluentAssertions;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class SharedStepDefinitions(SharedStepsContext sharedStepsContext)
{
    internal const string Digits = "0123456789";

    internal const string WordCharacters = $"{Digits}ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz";

    internal const string QwertyKeyboardCharacters =
        "\t !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

    internal const string QwertyKeyboardWhitespaceCharacters = "\t ";

    internal const string QwertyKeyboardNonWhitespaceCharacters =
        "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [Given("'([^']*)' as an input string")]
    private void GivenAsAnInputString(string input)
    {
        _sharedStepsContext.Input = input;
    }

    [Then("the Modex matches '([^']*)'")]
    private void ThenTheModexMatches(string matchedSubstring)
    {
        AssertMatch(_sharedStepsContext, matchedSubstring);
    }

    [Then("the Modex matches")]
    private void ThenTheModexMatches()
    {
        _sharedStepsContext.Matches.Should().NotBeEmpty();
    }

    [Then("the Modex does not match")]
    private void ThenTheModexDoesNotMatch()
    {
        _sharedStepsContext.Matches.Should().BeEmpty();
    }

    internal static void SetInputStringToSomeLowercaseLetters(SharedStepsContext sharedStepsContext)
    {
        sharedStepsContext.Input = new Faker().Random.String2(minLength: 0, maxLength: 1023);
    }

    internal static string BuildStringOfSomeQwertyCharactersExcept(IEnumerable<char> charactersToExclude)
        => BuildStringOfSomeCharactersFrom(new(BuildArrayOfAllQwertyCharactersExcept(charactersToExclude)));

    internal static string BuildStringOfSomeCharactersFrom(string chars)
        => new Faker().Random.String2(minLength: 0, maxLength: 1023, chars: chars);

    internal static string BuildStringOfAllQwertyCharactersExcept(IEnumerable<char> charactersToExclude)
        => new(BuildArrayOfAllQwertyCharactersExcept(charactersToExclude));

    private static char[] BuildArrayOfAllQwertyCharactersExcept(IEnumerable<char> charactersToExclude)
    {
        HashSet<char> exclusionSet = charactersToExclude.ToHashSet();
        return QwertyKeyboardCharacters.Where(character => !exclusionSet.Contains(character)).ToArray();
    }

    internal static void AssertMatch(SharedStepsContext sharedStepsContext, string matchedSubstring)
    {
        sharedStepsContext.Matches.Should().NotBeEmpty();
        sharedStepsContext.Matches!.First().Value.Should().Be(matchedSubstring);
    }
}
