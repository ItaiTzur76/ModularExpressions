using Bogus;
using ModularExpressions.Generators.Test.SpecFlow.Models;

using static ModularExpressions.Generators.Test.SpecFlow.Models.StaticallyUsedClass;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class SourceGenerationStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [Given("an input string containing a digit")]
    private void GivenAnInputStringContainingADigit()
    {
        Faker faker = new();
        _sharedStepsContext.Input = $"{faker.Random.String()}{faker.Random.Digits(1)}{faker.Random.String()}";
    }

    [Given("an input string not containing a digit")]
    private void GivenAnInputStringNotContainingADigit()
    {
        SharedStepDefinitions.SetInputStringToSomeLowercaseLetters(_sharedStepsContext);
    }

    [When("the input string is matched against a digit Modex declared in a generic")]
    private void WhenTheInputStringIsMatchedAgainstADigitModexDeclaredInAGeneric()
    {
        _sharedStepsContext.MatchPattern(
            BaseGeneric<int, char>.NestedClass.NestedGeneric<string, bool, double>.DigitPattern());
    }

    [When("the input string is matched against a digit Modex declared in a global class")]
    private void WhenTheInputStringIsMatchedAgainstADigitModexDeclaredInAGlobalClass()
    {
        _sharedStepsContext.MatchPattern(BaseGlobalClass.NestedGlobalClass.DigitInGlobalClassPattern());
    }

    [When("the input string is matched against a digit Modex declared and generated in a partial class spread over two different files")]
    private void WhenTheInputStringIsMatchedAgainstADigitModexDeclaredAndGeneratedInAPartialClassSpreadOverTwoDifferentFiles()
    {
        _sharedStepsContext.MatchPattern(
            BaseGeneric<int, char>.NestedClass.NestedGeneric<string, bool, double>.DigitPattern());
    }

    [When("the input string is matched against a digit Modex declared in a statically-used class")]
    private void WhenTheInputStringIsMatchedAgainstADigitModexDeclaredInAStaticallyUsedClass()
    {
        _sharedStepsContext.MatchPattern(DigitInStaticallyUsedClassPattern());
    }
}
