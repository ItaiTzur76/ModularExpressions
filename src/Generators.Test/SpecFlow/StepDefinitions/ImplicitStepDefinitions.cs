using ModularExpressions.Generators.Test.SpecFlow.Models;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class ImplicitStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a (.*) Modex property matching 'A(.)B'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingAB(string tokenType, char escapeCharacter)
    {
        _sharedStepsContext.MatchPattern(
            (tokenType, escapeCharacter) switch
            {
                ("Literal", '.') => BaseNamespacedClass.LiteralADotBPattern(),
                ("Literal", '+') => BaseNamespacedClass.LiteralAPlusBPattern(),
                ("Literal", '*') => BaseNamespacedClass.LiteralAAsteriskBPattern(),
                ("Literal", '?') => BaseNamespacedClass.LiteralAQuestionMarkBPattern(),
                ("Literal", '(') => BaseNamespacedClass.LiteralALeftParenthesisBPattern(),
                ("Literal", ')') => BaseNamespacedClass.LiteralARightParenthesisBPattern(),
                ("Literal", '[') => BaseNamespacedClass.LiteralALeftBracketBPattern(),
                ("Literal", ']') => BaseNamespacedClass.LiteralARightBracketBPattern(),
                ("Literal", '{') => BaseNamespacedClass.LiteralALeftBraceBPattern(),
                ("Literal", '}') => BaseNamespacedClass.LiteralARightBraceBPattern(),
                ("Literal", '|') => BaseNamespacedClass.LiteralAVerticalBarBPattern(),
                ("Const in non-nested namespaced class", '.') => BaseNamespacedClass.ConstADotBPattern(),
                ("Const in non-nested namespaced class", '+') => BaseNamespacedClass.ConstAPlusBPattern(),
                ("Const in non-nested namespaced class", '*') => BaseNamespacedClass.ConstAAsteriskBPattern(),
                ("Const in non-nested namespaced class", '?') => BaseNamespacedClass.ConstAQuestionMarkBPattern(),
                ("Const in non-nested namespaced class", '(') => BaseNamespacedClass.ConstALeftParenthesisBPattern(),
                ("Const in non-nested namespaced class", ')') => BaseNamespacedClass.ConstARightParenthesisBPattern(),
                ("Const in non-nested namespaced class", '[') => BaseNamespacedClass.ConstALeftBracketBPattern(),
                ("Const in non-nested namespaced class", ']') => BaseNamespacedClass.ConstARightBracketBPattern(),
                ("Const in non-nested namespaced class", '{') => BaseNamespacedClass.ConstALeftBraceBPattern(),
                ("Const in non-nested namespaced class", '}') => BaseNamespacedClass.ConstARightBraceBPattern(),
                ("Const in non-nested namespaced class", '|') => BaseNamespacedClass.ConstAVerticalBarBPattern(),
                ("Const in nested namespaced class", '.') => BaseNamespacedClass.ConstADotBInNestedClassPattern(),
                ("Const in nested namespaced class", '+') => BaseNamespacedClass.ConstAPlusBInNestedClassPattern(),
                ("Const in nested namespaced class", '*') => BaseNamespacedClass.ConstAAsteriskBInNestedClassPattern(),
                ("Const in nested namespaced class", '?') => BaseNamespacedClass.ConstAQuestionMarkBInNestedClassPattern(),
                ("Const in nested namespaced class", '(') => BaseNamespacedClass.ConstALeftParenthesisBInNestedClassPattern(),
                ("Const in nested namespaced class", ')') => BaseNamespacedClass.ConstARightParenthesisBInNestedClassPattern(),
                ("Const in nested namespaced class", '[') => BaseNamespacedClass.ConstALeftBracketBInNestedClassPattern(),
                ("Const in nested namespaced class", ']') => BaseNamespacedClass.ConstARightBracketBInNestedClassPattern(),
                ("Const in nested namespaced class", '{') => BaseNamespacedClass.ConstALeftBraceBInNestedClassPattern(),
                ("Const in nested namespaced class", '}') => BaseNamespacedClass.ConstARightBraceBInNestedClassPattern(),
                ("Const in nested namespaced class", '|') => BaseNamespacedClass.ConstAVerticalBarBInNestedClassPattern(),
                ("Const in another class in same namespace", '.') => BaseNamespacedClass.ConstADotBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", '+') => BaseNamespacedClass.ConstAPlusBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", '*') => BaseNamespacedClass.ConstAAsteriskBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", '?') => BaseNamespacedClass.ConstAQuestionMarkBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", '(') => BaseNamespacedClass.ConstALeftParenthesisBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", ')') => BaseNamespacedClass.ConstARightParenthesisBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", '[') => BaseNamespacedClass.ConstALeftBracketBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", ']') => BaseNamespacedClass.ConstARightBracketBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", '{') => BaseNamespacedClass.ConstALeftBraceBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", '}') => BaseNamespacedClass.ConstARightBraceBInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", '|') => BaseNamespacedClass.ConstAVerticalBarBInAnotherClassInSameNamespacePattern(),
                ("Const in another namespace", '.') => BaseNamespacedClass.ConstADotBInAnotherNamespacePattern(),
                ("Const in another namespace", '+') => BaseNamespacedClass.ConstAPlusBInAnotherNamespacePattern(),
                ("Const in another namespace", '*') => BaseNamespacedClass.ConstAAsteriskBInAnotherNamespacePattern(),
                ("Const in another namespace", '?') => BaseNamespacedClass.ConstAQuestionMarkBInAnotherNamespacePattern(),
                ("Const in another namespace", '(') => BaseNamespacedClass.ConstALeftParenthesisBInAnotherNamespacePattern(),
                ("Const in another namespace", ')') => BaseNamespacedClass.ConstARightParenthesisBInAnotherNamespacePattern(),
                ("Const in another namespace", '[') => BaseNamespacedClass.ConstALeftBracketBInAnotherNamespacePattern(),
                ("Const in another namespace", ']') => BaseNamespacedClass.ConstARightBracketBInAnotherNamespacePattern(),
                ("Const in another namespace", '{') => BaseNamespacedClass.ConstALeftBraceBInAnotherNamespacePattern(),
                ("Const in another namespace", '}') => BaseNamespacedClass.ConstARightBraceBInAnotherNamespacePattern(),
                ("Const in another namespace", '|') => BaseNamespacedClass.ConstAVerticalBarBInAnotherNamespacePattern(),
                ("Const in global class", '.') => BaseNamespacedClass.ConstADotBInGlobalClassPattern(),
                ("Const in global class", '+') => BaseNamespacedClass.ConstAPlusBInGlobalClassPattern(),
                ("Const in global class", '*') => BaseNamespacedClass.ConstAAsteriskBInGlobalClassPattern(),
                ("Const in global class", '?') => BaseNamespacedClass.ConstAQuestionMarkBInGlobalClassPattern(),
                ("Const in global class", '(') => BaseNamespacedClass.ConstALeftParenthesisBInGlobalClassPattern(),
                ("Const in global class", ')') => BaseNamespacedClass.ConstARightParenthesisBInGlobalClassPattern(),
                ("Const in global class", '[') => BaseNamespacedClass.ConstALeftBracketBInGlobalClassPattern(),
                ("Const in global class", ']') => BaseNamespacedClass.ConstARightBracketBInGlobalClassPattern(),
                ("Const in global class", '{') => BaseNamespacedClass.ConstALeftBraceBInGlobalClassPattern(),
                ("Const in global class", '}') => BaseNamespacedClass.ConstARightBraceBInGlobalClassPattern(),
                ("Const in global class", '|') => BaseNamespacedClass.ConstAVerticalBarBInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching '\^a'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingCaretA(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralCaretAPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstCaretAPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstCaretAInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstCaretAInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstCaretAInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstCaretAInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [When(@"the input string is matched against a (.*) Modex property matching '_\$'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingUnderscoreDollar(string tokenType)
    {
        _sharedStepsContext.MatchPattern(
            tokenType switch
            {
                "Literal" => BaseNamespacedClass.LiteralUnderscoreDollarPattern(),
                "Const in non-nested namespaced class" => BaseNamespacedClass.ConstUnderscoreDollarPattern(),
                "Const in nested namespaced class" => BaseNamespacedClass.ConstUnderscoreDollarInNestedClassPattern(),
                "Const in another class in same namespace" => BaseNamespacedClass.ConstUnderscoreDollarInAnotherClassInSameNamespacePattern(),
                "Const in another namespace" => BaseNamespacedClass.ConstUnderscoreDollarInAnotherNamespacePattern(),
                "Const in global class" => BaseNamespacedClass.ConstUnderscoreDollarInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }
}
