namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class AdditionStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a Modex property matching a (.*) concatenation of a non-word character and a whitespace character")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAConcatenationOfANonWordCharacterAndAWhitespaceCharacter(string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            subexpressionType switch
            {
                "Direct" => DirectNonWordCharacterAndWhitespaceCharacterPattern(),
                "Indirect" => IndirectNonWordCharacterAndWhitespaceCharacterPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [GenerateModex(nameof(DirectNonWordCharacterAndWhitespaceCharacterModex))]
    private static partial string DirectNonWordCharacterAndWhitespaceCharacterPattern();

    private static Modex DirectNonWordCharacterAndWhitespaceCharacterModex => NonWordCharacter + WhitespaceCharacter;

    [GenerateModex(nameof(IndirectNonWordCharacterAndWhitespaceCharacterModex))]
    private static partial string IndirectNonWordCharacterAndWhitespaceCharacterPattern();

    private static Modex IndirectNonWordCharacterAndWhitespaceCharacterModex => NonWordCharacterModex + WhitespaceCharacterModex;

    private static Modex NonWordCharacterModex => NonWordCharacter;

    private static Modex WhitespaceCharacterModex => WhitespaceCharacter;
}
