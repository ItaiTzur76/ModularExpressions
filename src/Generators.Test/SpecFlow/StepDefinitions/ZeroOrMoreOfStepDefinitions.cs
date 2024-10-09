using ModularExpressions.Generators.Test.SpecFlow.Models;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class ZeroOrMoreOfStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a Modex property matching zero or more (.*) non-digits")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingZeroOrMoreNonDigits(string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            subexpressionType switch
            {
                "Direct" => DirectZeroOrMoreNonDigitsPattern(),
                "Indirect" => IndirectZeroOrMoreNonDigitsPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [GenerateModex(nameof(DirectZeroOrMoreNonDigitsModex))]
    private static partial string DirectZeroOrMoreNonDigitsPattern();

    private static Modex DirectZeroOrMoreNonDigitsModex => ZeroOrMoreOf(NonDigit);

    [GenerateModex(nameof(IndirectZeroOrMoreNonDigitsModex))]
    private static partial string IndirectZeroOrMoreNonDigitsPattern();

    private static Modex IndirectZeroOrMoreNonDigitsModex => ZeroOrMoreOf(BaseNamespacedClass.NonDigitModex);
}
