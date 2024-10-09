using Bogus;
using FluentAssertions;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class EndStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [Given(@"an input string ending with at least (\d+) non-whitespace characters")]
    private void GivenAnInputStringEndingWithAtLeastNonWhitespaceCharacters(int minLength)
    {
        Faker faker = new();
        _sharedStepsContext.Input =
            $"{faker.Random.String2(minLength: 0, maxLength: 1023, chars: SharedStepDefinitions.QwertyKeyboardCharacters)}{faker.Random.String2(minLength: minLength, maxLength: 1023, chars: SharedStepDefinitions.BuildStringOfAllQwertyCharactersExcept(SharedStepDefinitions.QwertyKeyboardWhitespaceCharacters))}";
    }

    [Given(@"an input string containing at least (\d+) non-whitespace characters, then at least 1 whitespace character, then ending with (\d+) non-whitespace characters or fewer")]
    private void GivenAnInputStringContainingAtLeastNonWhitespaceCharactersThenAtLeast1WhitespaceCharacterThenEndingWithNonWhitespaceCharactersOrFewer(
        int minLength1, int maxLength2)
    {
        Faker faker = new();
        _sharedStepsContext.Input = $"{faker.Random.String2(minLength: minLength1, maxLength: 1023, chars: SharedStepDefinitions.BuildStringOfAllQwertyCharactersExcept(SharedStepDefinitions.QwertyKeyboardWhitespaceCharacters))}{faker.Random.String2(minLength: 1, maxLength: 1023, chars: SharedStepDefinitions.QwertyKeyboardWhitespaceCharacters)}{faker.Random.String2(minLength: 0, maxLength: maxLength2, chars: SharedStepDefinitions.BuildStringOfAllQwertyCharactersExcept(SharedStepDefinitions.QwertyKeyboardWhitespaceCharacters))}";
    }

    [When("the input string is matched against a Modex property ending with 5 non-whitespace characters")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyEndingWith5NonWhitespaceCharacters()
    {
        _sharedStepsContext.MatchPattern(EndingWith5NonWhitespaceCharactersPattern());
    }

    [Then(@"the Modex matches only the last (\d+) characters of the input string")]
    private void ThenTheModexMatchesOnlyTheLastCharactersOfTheInputString(int matchedCharacters)
    {
        _sharedStepsContext.Matches.Should().ContainSingle();
        SharedStepDefinitions.AssertMatch(_sharedStepsContext, _sharedStepsContext.Input![^matchedCharacters..]);
    }

    [GenerateModex(nameof(EndingWith5NonWhitespaceCharactersModex))]
    private static partial string EndingWith5NonWhitespaceCharactersPattern();

    private static Modex EndingWith5NonWhitespaceCharactersModex => NonWhitespaceCharacter.Times(5) + End;
}
