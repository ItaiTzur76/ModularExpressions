namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class WordBoundaryStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a Modex property matching 'H', then a non-new-line character, then a word boundary, then a non-new-line character")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingHThenANonNewLineCharacterThenAWordBoundaryThenANonNewLineCharacter()
    {
        _sharedStepsContext.MatchPattern(HNonNewLineCharacterWordBoundaryNonNewLineCharacterPattern());
    }

    [GenerateModex(nameof(HNonNewLineCharacterWordBoundaryNonNewLineCharacterModex))]
    private static partial string HNonNewLineCharacterWordBoundaryNonNewLineCharacterPattern();

    private static Modex HNonNewLineCharacterWordBoundaryNonNewLineCharacterModex
        => "H" + NonNewLineCharacter + WordBoundary + NonNewLineCharacter;
}
