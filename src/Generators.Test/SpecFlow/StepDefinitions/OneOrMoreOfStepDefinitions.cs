namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class OneOrMoreOfStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a Modex property matching one or more (.*) digits")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingOneOrMoreDigits(string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            subexpressionType switch
            {
                "Direct" => DirectOneOrMoreDigitsPattern(),
                "Indirect" => IndirectOneOrMoreDigitsPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [GenerateModex(nameof(DirectOneOrMoreDigitsModex))]
    private static partial string DirectOneOrMoreDigitsPattern();

    private static Modex DirectOneOrMoreDigitsModex => OneOrMoreOf(Digit);

    [GenerateModex(nameof(IndirectOneOrMoreDigitsModex))]
    private static partial string IndirectOneOrMoreDigitsPattern();

    private static Modex IndirectOneOrMoreDigitsModex => OneOrMoreOf(DigitModex);

    private static Modex DigitModex => Digit;
}
