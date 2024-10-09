using ModularExpressions.Generators.Test.SpecFlow.Models;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class TimesAtLeastStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a (.*) Modex property matching 3 or more (.*) non-digits")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingCaretWOr5(string tokenType, string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            (tokenType, subexpressionType) switch
            {
                ("Literal", "Direct") => BaseNamespacedClass.Literal3OrMoreDirectNonDigitsPattern(),
                ("Literal", "Indirect") => BaseNamespacedClass.Literal3OrMoreIndirectNonDigitsPattern(),
                ("Const in non-nested namespaced class", "Direct") => BaseNamespacedClass.Const3OrMoreDirectNonDigitsPattern(),
                ("Const in non-nested namespaced class", "Indirect") => BaseNamespacedClass.Const3OrMoreIndirectNonDigitsPattern(),
                ("Const in nested namespaced class", "Direct") => BaseNamespacedClass.Const3OrMoreDirectNonDigitsInNestedClassPattern(),
                ("Const in nested namespaced class", "Indirect") => BaseNamespacedClass.Const3OrMoreIndirectNonDigitsInNestedClassPattern(),
                ("Const in another class in same namespace", "Direct") => BaseNamespacedClass.Const3OrMoreDirectNonDigitsInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", "Indirect") => BaseNamespacedClass.Const3OrMoreIndirectNonDigitsInAnotherClassInSameNamespacePattern(),
                ("Const in another namespace", "Direct") => BaseNamespacedClass.Const3OrMoreDirectNonDigitsInAnotherNamespacePattern(),
                ("Const in another namespace", "Indirect") => BaseNamespacedClass.Const3OrMoreIndirectNonDigitsInAnotherNamespacePattern(),
                ("Const in global class", "Direct") => BaseNamespacedClass.Const3OrMoreDirectNonDigitsInGlobalClassPattern(),
                ("Const in global class", "Indirect") => BaseNamespacedClass.Const3OrMoreIndirectNonDigitsInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }
}
