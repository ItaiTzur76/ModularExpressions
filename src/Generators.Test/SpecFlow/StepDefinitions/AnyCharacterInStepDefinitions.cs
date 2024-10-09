using Bogus;
using ModularExpressions.Generators.Test.SpecFlow.Models;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class AnyCharacterInStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [Given("an input string not containing '(.)', '(.)' or '(.)'")]
    private void GivenAnInputStringNotContainingChar1Char2OrChar3(char char1, char char2, char char3)
    {
        SetInputStringToSomeQwertyCharactersExcept([char1, char2, char3]);
    }

    [Given("an input string not containing '@', a word character or '!'")]
    private void GivenAnInputStringNotContainingAtAWordCharacterOrExclamationMark()
    {
        SetInputStringToSomeQwertyCharactersExcept(
            '0'.RangeTo('9')
                .Concat('A'.RangeTo('Z'))
                .Append('_')
                .Concat('a'.RangeTo('z'))
                .Append('@')
                .Append('!'));
    }

    [Given("an input string not containing 'C', a non-word character or '1'")]
    private void GivenAnInputStringNotContainingCANonWordCharacterOr1()
    {
        _sharedStepsContext.Input = new Faker().Random.String2(
            minLength: 0,
            maxLength: 1023,
            chars: "023456789ABDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz");
    }

    [Given("an input string not containing 'Q', a whitespace character or '2'")]
    private void GivenAnInputStringNotContainingQAWhitespaceCharacterOr2()
    {
        SetInputStringToSomeQwertyCharactersExcept(['Q', '\t', ' ', '2']);
    }

    [Given("an input string containing a non-whitespace character")]
    private void GivenAnInputStringContainingANonWhitespaceCharacter()
    {
        _sharedStepsContext.Input =
            $"{BuildWhitespaceStringOfRandomLength()}{new Faker().Random.String2(length: 1, chars: SharedStepDefinitions.QwertyKeyboardNonWhitespaceCharacters)}{BuildWhitespaceStringOfRandomLength()}";
    }

    [Given("an input string not containing a non-whitespace character")]
    private void GivenAnInputStringNotContainingANonWhitespaceCharacter()
    {
        _sharedStepsContext.Input = BuildWhitespaceStringOfRandomLength();
    }

    [Given("an input string not containing 'X', a digit or '%'")]
    private void GivenAnInputStringNotContainingXADigitOrPercent()
    {
        SetInputStringToSomeQwertyCharactersExcept(['X', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '%']);
    }

    [Given("an input string not containing '3', a non-digit or '8'")]
    private void GivenAnInputStringNotContaining3ANonDigitOr8()
    {
        _sharedStepsContext.Input = SharedStepDefinitions.BuildStringOfSomeCharactersFrom("01245679");
    }

    [Given("an input string not containing '(.)' to '(.)', or '(.)'")]
    private void GivenAnInputStringNotContainingFirstToLastOrChar3(char first, char last, char char3)
    {
        SetInputStringToSomeQwertyCharactersExcept(first.RangeTo(last).Append(char3));
    }

    [Given("an input string not containing '(.)', '(.)' to '(.)', or '(.)'")]
    private void GivenAnInputStringNotContainingChar1FirstToLastOrChar2(char char1, char first, char last, char char2)
    {
        SetInputStringToSomeQwertyCharactersExcept(first.RangeTo(last).Append(char1).Append(char2));
    }

    [Given("an input string not containing '(.)', or '(.)' to '(.)'")]
    private void GivenAnInputStringNotContainingChar1OrFirstToLast(char char1, char first, char last)
    {
        SetInputStringToSomeQwertyCharactersExcept(first.RangeTo(last).Append(char1));
    }

    private void SetInputStringToSomeQwertyCharactersExcept(IEnumerable<char> charactersToExclude)
    {
        _sharedStepsContext.Input = SharedStepDefinitions.BuildStringOfSomeQwertyCharactersExcept(charactersToExclude);
    }

    private static string BuildWhitespaceStringOfRandomLength() => new(' ', new Faker().Random.Int(min: 0, max: 1023));

    [When(@"the input string is matched against a (.*) Modex property matching '\^', 'W' or '5'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingCaretWOr5(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralCaretWOr5Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstCaretWOr5Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstCaretWOr5InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstCaretWOr5InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstCaretWOr5InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstCaretWOr5InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching '8', '\\' or 'D'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatching8BackslashOrD(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.Literal8BackslashOrDPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.Const8BackslashOrDPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.Const8BackslashOrDInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.Const8BackslashOrDInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.Const8BackslashOrDInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.Const8BackslashOrDInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching 'P', '\"' or '6'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingPDoubleQuoteOr6(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralPDoubleQuoteOr6Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstPDoubleQuoteOr6Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstPDoubleQuoteOr6InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstPDoubleQuoteOr6InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstPDoubleQuoteOr6InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstPDoubleQuoteOr6InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching '9', '\\]' or 'M'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatching9RightBracketOrM(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.Literal9RightBracketOrMPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.Const9RightBracketOrMPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.Const9RightBracketOrMInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.Const9RightBracketOrMInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.Const9RightBracketOrMInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.Const9RightBracketOrMInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching '-', '4' or 'J'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingMinus4OrJ(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralMinus4OrJPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstMinus4OrJPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstMinus4OrJInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstMinus4OrJInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstMinus4OrJInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstMinus4OrJInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching 'C', '7' or '-'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingC7OrMinus(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralC7OrMinusPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstC7OrMinusPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstC7OrMinusInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstC7OrMinusInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstC7OrMinusInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstC7OrMinusInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching '2', '-' or 'S'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatching2MinusOrS(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.Literal2MinusOrSPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.Const2MinusOrSPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.Const2MinusOrSInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.Const2MinusOrSInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.Const2MinusOrSInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.Const2MinusOrSInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a Modex property matching '@', a word character or '!'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAtAWordCharacterOrExclamationMark()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.AtAWordCharacterOrExclamationMarkPattern());
    }

    [When("the input string is matched against a Modex property matching 'C', a non-word character or '1'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingCANonWordCharacterOr1()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.CANonWordCharacterOr1Pattern());
    }

    [When("the input string is matched against a Modex property matching 'Q', a whitespace character or '2'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingQAWhitespaceCharacterOr2()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.QAWhitespaceCharacterOr2Pattern());
    }

    [When("the input string is matched against a Modex property matching a non-whitespace character or a tab")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingANonWhitespaceCharacterOrATab()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.ANonWhitespaceCharacterOrATabPattern());
    }

    [When("the input string is matched against a Modex property matching 'X', a digit or '%'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingXADigitOrPercent()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.XADigitOrPercentPattern());
    }

    [When("the input string is matched against a Modex property matching '3', a non-digit or '8'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatching3ANonDigitOr8()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.ThreeANonDigitOr8Pattern());
    }

    [When("the input string is matched against a (.*) Modex property matching '\\^' to '`', or 'B'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingCaretToBacktickOrB(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralCaretToBacktickOrBPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstCaretToBacktickOrBPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstCaretToBacktickOrBInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstCaretToBacktickOrBInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstCaretToBacktickOrBInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstCaretToBacktickOrBInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching 'Z', '\\' to '_', or '0'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingZBackslashToUnderscoreOr0(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralZBackslashToUnderscoreOr0Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstZBackslashToUnderscoreOr0Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstZBackslashToUnderscoreOr0InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstZBackslashToUnderscoreOr0InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstZBackslashToUnderscoreOr0InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstZBackslashToUnderscoreOr0InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching 'R', 'Z' to '\\', or '5'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingRZToBackslashOr5(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralRZToBackslashOr5Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstRZToBackslashOr5Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstRZToBackslashOr5InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstRZToBackslashOr5InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstRZToBackslashOr5InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstRZToBackslashOr5InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching 'Y', '""' to '\$', or '1'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingYDoubleQuoteToDollarOr1(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralYDoubleQuoteToDollarOr1Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstYDoubleQuoteToDollarOr1Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstYDoubleQuoteToDollarOr1InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstYDoubleQuoteToDollarOr1InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstYDoubleQuoteToDollarOr1InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstYDoubleQuoteToDollarOr1InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching 'E', '!' to '""', or '7'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingEExclamationMarkToDoubleQuoteOr7(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralEExclamationMarkToDoubleQuoteOr7Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstEExclamationMarkToDoubleQuoteOr7Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstEExclamationMarkToDoubleQuoteOr7InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstEExclamationMarkToDoubleQuoteOr7InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstEExclamationMarkToDoubleQuoteOr7InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstEExclamationMarkToDoubleQuoteOr7InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching 'A', ']' to '`', or '2'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingARightBracketToBacktickOr2(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralARightBracketToBacktickOr2Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstARightBracketToBacktickOr2Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstARightBracketToBacktickOr2InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstARightBracketToBacktickOr2InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstARightBracketToBacktickOr2InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstARightBracketToBacktickOr2InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching 'H', '\\[' to ']', or '8'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingHLeftBracketToRightBracketOr8(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralHLeftBracketToRightBracketOr8Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstHLeftBracketToRightBracketOr8Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstHLeftBracketToRightBracketOr8InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstHLeftBracketToRightBracketOr8InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstHLeftBracketToRightBracketOr8InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstHLeftBracketToRightBracketOr8InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching '\\+' to '-', or 'L'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingPlusToMinusOrL(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralPlusToMinusOrLPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstPlusToMinusOrLPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstPlusToMinusOrLInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstPlusToMinusOrLInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstPlusToMinusOrLInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstPlusToMinusOrLInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching 'T', or '-' to '0'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingTOrMinusTo1(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralTOrMinusTo0Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstTOrMinusTo0Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstTOrMinusTo0InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstTOrMinusTo0InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstTOrMinusTo0InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstTOrMinusTo0InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [Then("the Modex matches the text surrounded by single-quote characters in ''([^']*)''")]
    private void ThenTheModexMatchesTheTextSurroundedBySingleQuoteCharactersIn(string matchedSubstring)
    {
        SharedStepDefinitions.AssertMatch(_sharedStepsContext, matchedSubstring);
    }
}
