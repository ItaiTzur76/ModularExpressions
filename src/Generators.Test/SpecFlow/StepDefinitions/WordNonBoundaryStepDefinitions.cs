namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class WordNonBoundaryStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a Modex property matching 'H', then a non-new-line character, then a word non-boundary, then a non-new-line character")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingHThenANonNewLineCharacterThenAWordNonBoundaryThenANonNewLineCharacter()
    {
        _sharedStepsContext.MatchPattern(HNonNewLineCharacterWordNonBoundaryNonNewLineCharacterPattern());
    }

    [GenerateModex(nameof(HNonNewLineCharacterWordNonBoundaryNonNewLineCharacterModex))]
    private static partial string HNonNewLineCharacterWordNonBoundaryNonNewLineCharacterPattern();

    private static Modex HNonNewLineCharacterWordNonBoundaryNonNewLineCharacterModex
        => "H" + NonNewLineCharacter + WordNonBoundary + NonNewLineCharacter;
}
