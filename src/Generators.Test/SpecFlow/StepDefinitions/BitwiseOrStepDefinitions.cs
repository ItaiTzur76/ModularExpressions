namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class BitwiseOrStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a Modex property matching a (.*) bitwise-or of a digit and a non-word character")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingABitwiseOrOfADigitAndANonWordCharacter(string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            subexpressionType switch
            {
                "Direct" => DirectDigitOrNonWordCharacterPattern(),
                "Indirect" => IndirectDigitOrNonWordCharacterPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [GenerateModex(nameof(DirectDigitOrNonWordCharacterModex))]
    private static partial string DirectDigitOrNonWordCharacterPattern();

    private static Modex DirectDigitOrNonWordCharacterModex => Digit | NonWordCharacter;

    [GenerateModex(nameof(IndirectDigitOrNonWordCharacterModex))]
    private static partial string IndirectDigitOrNonWordCharacterPattern();

    private static Modex IndirectDigitOrNonWordCharacterModex => DigitModex | NonWordCharacterModex;

    private static Modex DigitModex => Digit;

    private static Modex NonWordCharacterModex => NonWordCharacter;
}
