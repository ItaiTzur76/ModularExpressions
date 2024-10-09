using Bogus;
using FluentAssertions;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class BeginningStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [Given(@"an input string starting with at least (\d+) word characters")]
    private void GivenAnInputStringStartingWithAtLeastWordCharacters(int minLength)
    {
        Faker faker = new();
        _sharedStepsContext.Input =
            $"{faker.Random.String2(minLength: minLength, maxLength: 1023, chars: SharedStepDefinitions.WordCharacters)}{faker.Random.String2(minLength: 0, maxLength: 1023, chars: SharedStepDefinitions.QwertyKeyboardCharacters)}";
    }

    [Given(@"an input string starting with (\d+) word characters or fewer, then at least 1 non-word character, then at least (\d+) word characters")]
    private void GivenAnInputStringStartingWithWordCharactersOrFewerThenAtLeast1NonWordCharacterThenAtLeastWordCharacters(
        int maxLength1, int minLength2)
    {
        Faker faker = new();
        _sharedStepsContext.Input = $"{faker.Random.String2(minLength: 0, maxLength: maxLength1, chars: SharedStepDefinitions.WordCharacters)}{faker.Random.String2(minLength: 1, maxLength: 1023, chars: "!@#$%^&*()")}{faker.Random.String2(minLength: minLength2, maxLength: 1023, chars: SharedStepDefinitions.WordCharacters)}";
    }

    [When("the input string is matched against a Modex property beginning with 4 word characters")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyBeginningWith4WordCharacters()
    {
        _sharedStepsContext.MatchPattern(Beginning4WordCharactersPattern());
    }

    [GenerateModex(nameof(Beginning4WordCharactersModex))]
    private static partial string Beginning4WordCharactersPattern();

    private static Modex Beginning4WordCharactersModex => Beginning + WordCharacter.Times(4);

    [Then(@"the Modex matches only the first (\d+) characters of the input string")]
    private void ThenTheModexMatchesOnlyTheFirstCharactersOfTheInputString(int matchedCharacters)
    {
        _sharedStepsContext.Matches.Should().ContainSingle();
        SharedStepDefinitions.AssertMatch(_sharedStepsContext, _sharedStepsContext.Input![..matchedCharacters]);
    }
}
