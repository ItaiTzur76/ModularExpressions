using Bogus;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class TabStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [Given("an input string containing a tab character")]
    private void GivenAnInputStringContainingATabCharacter()
    {
        Faker faker = new();
        _sharedStepsContext.Input = $"{faker.Random.String()}\t{faker.Random.String()}";
    }

    [Given("an input string not containing a tab character")]
    private void GivenAnInputStringNotContainingATabCharacter()
    {
        SharedStepDefinitions.SetInputStringToSomeLowercaseLetters(_sharedStepsContext);
    }

    [When("the input string is matched against a tab Modex property")]
    private void WhenTheInputStringIsMatchedAgainstATabModexProperty()
    {
        _sharedStepsContext.MatchPattern(TabPattern());
    }

    [GenerateModex(nameof(TabModex))]
    private static partial string TabPattern();

    private static Modex TabModex => Tab;
}
