using Bogus;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class NonNewLineCharacterStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [Given("any QWERTY-keyboard character as an input string")]
    private void GivenAnyQwertyKeyboardCharacterAsAnInputString()
    {
        _sharedStepsContext.Input = new Faker().Random.String2(
            length: 1, chars: SharedStepDefinitions.QwertyKeyboardCharacters);
    }

    [Given("an input string containing only a new-line character")]
    private void GivenAnInputStringContainingOnlyANewLineCharacter()
    {
        _sharedStepsContext.Input = "\n";
    }

    [When("the input string is matched against a Modex property matching any non-new-line character")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyNonNewLineCharacter()
    {
        _sharedStepsContext.MatchPattern(NonNewLineCharacterPattern());
    }

    [Then("the Modex matches the character in the input string")]
    private void ThenTheModexMatchesTheCharacterInTheInputString()
    {
        SharedStepDefinitions.AssertMatch(_sharedStepsContext, _sharedStepsContext.Input!);
    }

    [GenerateModex(nameof(NonNewLineCharacterModex))]
    internal static partial string NonNewLineCharacterPattern();

    private static Modex NonNewLineCharacterModex => NonNewLineCharacter;
}
