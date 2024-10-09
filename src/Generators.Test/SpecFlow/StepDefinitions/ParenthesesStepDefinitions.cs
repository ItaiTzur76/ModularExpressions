namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed partial class ParenthesesStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When(@"the input string is matched against a Modex property matching \(with no parentheses\) 'A' and a digit or '_'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingWithNoParenthesesAAndADigitOrUnderscore()
    {
        _sharedStepsContext.MatchPattern(AAndADigitOrUnderscorePattern());
    }

    [GenerateModex(nameof(AAndADigitOrUnderscoreModex))]
    private static partial string AAndADigitOrUnderscorePattern();

    private static Modex AAndADigitOrUnderscoreModex => "A" + Digit | "_";


    [When(@"the input string is matched against a Modex property matching \(with no parentheses\) '\^' or a word character and 'q'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingWithNoParenthesesCaretOrAWordCharacterAndQ()
    {
        _sharedStepsContext.MatchPattern(CaretOrAWordCharacterAndQPattern());
    }

    [GenerateModex(nameof(CaretOrAWordCharacterAndQModex))]
    private static partial string CaretOrAWordCharacterAndQPattern();

    private static Modex CaretOrAWordCharacterAndQModex => "^" | WordCharacter + "q";


    [When(@"the input string is matched against a Modex property matching '@' or a word character \(in parentheses\) and then '#'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAtOrAWordCharacterInParenthesesAndThenHash()
    {
        _sharedStepsContext.MatchPattern(AtOrAWordCharacterInParenthesesAndThenHashPattern());
    }

    [GenerateModex(nameof(AtOrAWordCharacterInParenthesesAndThenHashModex))]
    private static partial string AtOrAWordCharacterInParenthesesAndThenHashPattern();

    private static Modex AtOrAWordCharacterInParenthesesAndThenHashModex => ("@" | WordCharacter) + "#";


    [When("the input string is matched against a Modex property matching '%' and then one or more word characters")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingPercentAndThenOneOrMoreWordCharacters()
    {
        _sharedStepsContext.MatchPattern(PercentAndThenOneOrMoreWordCharactersPattern());
    }

    [GenerateModex(nameof(PercentAndThenOneOrMoreWordCharactersModex))]
    private static partial string PercentAndThenOneOrMoreWordCharactersPattern();

    private static Modex PercentAndThenOneOrMoreWordCharactersModex => "%" + OneOrMoreOf(WordCharacter);


    [When("the input string is matched against a Modex property matching one or more instances of '%' and a word character")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingOneOrMoreInstancesOfPercentAndAWordCharacter()
    {
        _sharedStepsContext.MatchPattern(OneOrMoreInstancesOfPercentAndAWordCharacterPattern());
    }

    [GenerateModex(nameof(OneOrMoreInstancesOfPercentAndAWordCharacterModex))]
    private static partial string OneOrMoreInstancesOfPercentAndAWordCharacterPattern();

    private static Modex OneOrMoreInstancesOfPercentAndAWordCharacterModex => OneOrMoreOf("%" + WordCharacter);
}
