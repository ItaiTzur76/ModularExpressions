namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class ZeroOrOneOfStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a Modex property matching zero or one (.*) non-word characters")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingZeroOrOneNonWordCharacters(string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            subexpressionType switch
            {
                "Direct" => DirectZeroOrOneNonWordCharactersPattern(),
                "Indirect" => IndirectZeroOrOneNonWordCharactersPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [GenerateModex(nameof(DirectZeroOrOneNonWordCharactersModex))]
    private static partial string DirectZeroOrOneNonWordCharactersPattern();

    private static Modex DirectZeroOrOneNonWordCharactersModex => ZeroOrOneOf(NonWordCharacter);

    [GenerateModex(nameof(IndirectZeroOrOneNonWordCharactersModex))]
    private static partial string IndirectZeroOrOneNonWordCharactersPattern();

    private static Modex IndirectZeroOrOneNonWordCharactersModex => ZeroOrOneOf(NonWordCharacterModex);

    private static Modex NonWordCharacterModex => NonWordCharacter;
}
