using ModularExpressions.Generators.Test.SpecFlow.Models;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class AnyCharacterNotInStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [Given("an input string containing only '(.)', '(.)' and '(.)'")]
    private void GivenAnInputStringContainingOnlyChar1Char2AndChar3(char char1, char char2, char char3)
    {
        SetInputStringToSomeStringOfCharactersFrom([char1, char2, char3]);
    }

    [Given("an input string containing only '@', word characters and '!'")]
    private void GivenAnInputStringContainingOnlyAtWordCharactersAndExclamationMark()
    {
        SetInputStringToSomeStringOfCharactersFrom(
            '0'.RangeTo('9')
                .Concat('A'.RangeTo('Z'))
                .Append('_')
                .Concat('a'.RangeTo('z'))
                .Append('@')
                .Append('!'));
    }

    [Given("an input string containing only 'C', non-word characters and '1'")]
    private void GivenAnInputStringContainingOnlyCNonWordCharactersAnd1()
    {
        _sharedStepsContext.Input = SharedStepDefinitions.BuildStringOfSomeQwertyCharactersExcept(
            "023456789ABDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz");
    }

    [Given("an input string containing only 'Q', whitespace characters and '2'")]
    private void GivenAnInputStringNotContainingOnlyQWhitespaceCharactersAnd2()
    {
        SetInputStringToSomeStringOfCharactersFrom(['Q', '\t', ' ', '2']);
    }

    [Given("an input string containing only non-whitespace characters")]
    private void GivenAnInputStringContainingOnlyNonWhitespaceCharacters()
    {
        SetInputStringToSomeStringOfCharactersFrom(SharedStepDefinitions.QwertyKeyboardNonWhitespaceCharacters);
    }

    [Given("an input string containing only 'X', digits and '%'")]
    private void GivenAnInputStringContainingOnlyXDigitsAndPercent()
    {
        SetInputStringToSomeStringOfCharactersFrom(['X', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '%']);
    }

    [Given("an input string containing only '3', non-digits and '8'")]
    private void GivenAnInputStringContainingOnly3NonDigitsAnd8()
    {
        _sharedStepsContext.Input = SharedStepDefinitions.BuildStringOfSomeQwertyCharactersExcept("01245679");
    }

    [Given("an input string containing only '(.)' to '(.)', and '(.)'")]
    private void GivenAnInputStringContainingOnlyFirstToLastAndChar3(char first, char last, char char3)
    {
        SetInputStringToSomeStringOfCharactersFrom(first.RangeTo(last).Append(char3));
    }

    [Given("an input string containing only '(.)', '(.)' to '(.)', and '(.)'")]
    private void GivenAnInputStringContainingOnlyChar1FirstToLastAndChar2(char char1, char first, char last, char char2)
    {
        SetInputStringToSomeStringOfCharactersFrom(first.RangeTo(last).Append(char1).Append(char2));
    }

    [Given("an input string containing only '(.)', and '(.)' to '(.)'")]
    private void GivenAnInputStringContainingOnlyChar1AndFirstToLast(char char1, char first, char last)
    {
        SetInputStringToSomeStringOfCharactersFrom([char1, first, last]);
    }

    private void SetInputStringToSomeStringOfCharactersFrom(IEnumerable<char> characterPool)
    {
        _sharedStepsContext.Input = SharedStepDefinitions.BuildStringOfSomeCharactersFrom(new(characterPool.ToArray()));
    }

    [When(@"the input string is matched against a (.*) Modex property matching any character except '\^', 'W' or '5'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptCaretWOr5(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotCaretWOr5Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotCaretWOr5Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotCaretWOr5InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotCaretWOr5InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotCaretWOr5InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotCaretWOr5InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching any character except '8', '\\' or 'D'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExcept8BackslashOrD(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNot8BackslashOrDPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNot8BackslashOrDPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNot8BackslashOrDInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNot8BackslashOrDInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNot8BackslashOrDInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNot8BackslashOrDInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except 'P', '\"' or '6'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptPDoubleQuoteOr6(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotPDoubleQuoteOr6Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotPDoubleQuoteOr6Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotPDoubleQuoteOr6InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotPDoubleQuoteOr6InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotPDoubleQuoteOr6InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotPDoubleQuoteOr6InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except '9', '\\]' or 'M'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExcept9RightBracketOrM(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNot9RightBracketOrMPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNot9RightBracketOrMPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNot9RightBracketOrMInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNot9RightBracketOrMInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNot9RightBracketOrMInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNot9RightBracketOrMInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except '-', '4' or 'J'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptMinus4OrJ(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotMinus4OrJPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotMinus4OrJPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotMinus4OrJInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotMinus4OrJInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotMinus4OrJInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotMinus4OrJInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except 'C', '7' or '-'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptC7OrMinus(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotC7OrMinusPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotC7OrMinusPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotC7OrMinusInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotC7OrMinusInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotC7OrMinusInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotC7OrMinusInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except '2', '-' or 'S'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExcept2MinusOrS(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNot2MinusOrSPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNot2MinusOrSPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNot2MinusOrSInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNot2MinusOrSInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNot2MinusOrSInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNot2MinusOrSInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a Modex property matching any character except '@', word characters or '!'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptAtWordCharactersOrExclamationMark()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.NotAtWordCharactersOrExclamationMarkPattern());
    }

    [When("the input string is matched against a Modex property matching any character except 'C', non-word characters or '1'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptCNonWordCharactersOr1()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.NotCNonWordCharactersOr1Pattern());
    }

    [When("the input string is matched against a Modex property matching any character except 'Q', whitespace characters or '2'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptQWhitespaceCharactersOr2()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.NotQWhitespaceCharactersOr2Pattern());
    }

    [When("the input string is matched against a Modex property matching any character except non-whitespace characters or a tab")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptNonWhitespaceCharactersOrATab()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.NotNonWhitespaceCharactersOrATabPattern());
    }

    [When("the input string is matched against a Modex property matching any character except 'X', digits or '%'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptXDigitsOrPercent()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.NotXDigitsOrPercentPattern());
    }

    [When("the input string is matched against a Modex property matching any character except '3', non-digits or '8'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExcept3NonDigitsOr8()
    {
        _sharedStepsContext.MatchPattern(BaseNamespacedClass.Not3NonDigitsOr8Pattern());
    }

    [When("the input string is matched against a (.*) Modex property matching any character except '\\^' to '`', or 'B'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptCaretToBacktickOrB(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotCaretToBacktickOrBPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotCaretToBacktickOrBPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotCaretToBacktickOrBInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotCaretToBacktickOrBInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotCaretToBacktickOrBInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotCaretToBacktickOrBInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching any character except 'Z', '\\' to '_', or '0'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptZBackslashToUnderscoreOr0(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotZBackslashToUnderscoreOr0Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotZBackslashToUnderscoreOr0Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotZBackslashToUnderscoreOr0InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotZBackslashToUnderscoreOr0InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotZBackslashToUnderscoreOr0InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotZBackslashToUnderscoreOr0InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching any character except 'R', 'Z' to '\\', or '5'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptRZToBackslashOr5(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotRZToBackslashOr5Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotRZToBackslashOr5Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotRZToBackslashOr5InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotRZToBackslashOr5InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotRZToBackslashOr5InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotRZToBackslashOr5InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching any character except 'Y', '""' to '\$', or '1'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptYDoubleQuoteToDollarOr1(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotYDoubleQuoteToDollarOr1Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotYDoubleQuoteToDollarOr1Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotYDoubleQuoteToDollarOr1InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotYDoubleQuoteToDollarOr1InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotYDoubleQuoteToDollarOr1InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotYDoubleQuoteToDollarOr1InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching any character except 'E', ' ' to '""', or '7'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptESpaceToDoubleQuoteOr7(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotESpaceToDoubleQuoteOr7Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotESpaceToDoubleQuoteOr7Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotESpaceToDoubleQuoteOr7InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotESpaceToDoubleQuoteOr7InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotESpaceToDoubleQuoteOr7InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotESpaceToDoubleQuoteOr7InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except 'A', ']' to '`', or '2'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptARightBracketToBacktickOr2(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotARightBracketToBacktickOr2Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotARightBracketToBacktickOr2Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotARightBracketToBacktickOr2InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotARightBracketToBacktickOr2InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotARightBracketToBacktickOr2InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotARightBracketToBacktickOr2InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except 'H', '\\[' to ']', or '8'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptHLeftBracketToRightBracketOr8(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotHLeftBracketToRightBracketOr8Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotHLeftBracketToRightBracketOr8Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotHLeftBracketToRightBracketOr8InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotHLeftBracketToRightBracketOr8InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotHLeftBracketToRightBracketOr8InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotHLeftBracketToRightBracketOr8InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except '\\+' to '-', or 'L'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptPlusToMinusOrL(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotPlusToMinusOrLPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotPlusToMinusOrLPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotPlusToMinusOrLInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotPlusToMinusOrLInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotPlusToMinusOrLInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotPlusToMinusOrLInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When("the input string is matched against a (.*) Modex property matching any character except 'T', or '-' to '0'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAnyCharacterExceptTOrMinusTo1(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralNotTOrMinusTo0Pattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstNotTOrMinusTo0Pattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstNotTOrMinusTo0InNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstNotTOrMinusTo0InAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstNotTOrMinusTo0InAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstNotTOrMinusTo0InGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }
}
