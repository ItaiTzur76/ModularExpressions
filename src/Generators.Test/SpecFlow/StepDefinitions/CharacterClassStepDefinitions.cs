using Bogus;
using FluentAssertions;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class CharacterClassStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;
    private string? _testedCharacterClass;
    private string? _singleTokenString;

    [Given("an input string containing a single (.*)")]
    private void GivenAnInputStringContainingASingle(string characterClass)
    {
        _testedCharacterClass = characterClass;
        var yes = GetCharacters(characterClass);
        _singleTokenString = $"{new Faker().Random.CollectionItem(yes.ToList())}";
        _sharedStepsContext.Input =
            $"{SharedStepDefinitions.BuildStringOfSomeQwertyCharactersExcept(yes)}{_singleTokenString}{SharedStepDefinitions.BuildStringOfSomeQwertyCharactersExcept(yes)}";
    }

    [Scope(Feature = "CharacterClass")]
    [Given("an input string not containing a (.*)")]
    private void GivenAnInputStringNotContainingA(string characterClass)
    {
        _sharedStepsContext.Input =
            SharedStepDefinitions.BuildStringOfSomeQwertyCharactersExcept(GetCharacters(characterClass));
    }

    private static string GetCharacters(string characterClass)
        => characterClass switch
        {
            "word character" => SharedStepDefinitions.WordCharacters,
            "non-word character" => SharedStepDefinitions.BuildStringOfAllQwertyCharactersExcept(SharedStepDefinitions.WordCharacters),
            "whitespace character" => SharedStepDefinitions.QwertyKeyboardWhitespaceCharacters,
            "non-whitespace character" => SharedStepDefinitions.BuildStringOfAllQwertyCharactersExcept(SharedStepDefinitions.QwertyKeyboardWhitespaceCharacters),
            "digit" => SharedStepDefinitions.Digits,
            "non-digit" => SharedStepDefinitions.BuildStringOfAllQwertyCharactersExcept(SharedStepDefinitions.Digits),
            _ => throw new NotImplementedException()
        };

    [Scope(Feature = "CharacterClass")]
    [When("the input string is matched against a Modex property matching a (.*)")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingA(string characterClass)
    {
        _sharedStepsContext.MatchPattern(
            characterClass switch
            {
                "word character" => WordCharacterPattern(),
                "non-word character" => NonWordCharacterPattern(),
                "whitespace character" => WhitespaceCharacterPattern(),
                "non-whitespace character" => NonWhitespaceCharacterPattern(),
                "digit" => DigitPattern(),
                "non-digit" => NonDigitPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [GenerateModex(nameof(WordCharacterModex))]
    private static partial string WordCharacterPattern();

    private static Modex WordCharacterModex => WordCharacter;

    [GenerateModex(nameof(NonWordCharacterModex))]
    private static partial string NonWordCharacterPattern();

    private static Modex NonWordCharacterModex => NonWordCharacter;

    [GenerateModex(nameof(WhitespaceCharacterModex))]
    private static partial string WhitespaceCharacterPattern();

    private static Modex WhitespaceCharacterModex => WhitespaceCharacter;

    [GenerateModex(nameof(NonWhitespaceCharacterModex))]
    private static partial string NonWhitespaceCharacterPattern();

    private static Modex NonWhitespaceCharacterModex => NonWhitespaceCharacter;

    [GenerateModex(nameof(DigitModex))]
    private static partial string DigitPattern();

    private static Modex DigitModex => Digit;

    [GenerateModex(nameof(NonDigitModex))]
    private static partial string NonDigitPattern();

    private static Modex NonDigitModex => NonDigit;

    [Then("the Modex matches the single (.*)")]
    private void ThenTheModexMatchesTheSingle(string characterClass)
    {
        characterClass.Should().Be(_testedCharacterClass);
        SharedStepDefinitions.AssertMatch(_sharedStepsContext, _singleTokenString!);
    }
}
