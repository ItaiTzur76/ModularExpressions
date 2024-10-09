using ModularExpressions.Generators.Test.SpecFlow.Models;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class TimesBetweenStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a (.*) Modex property matching 3 to 5 (.*) non-word characters")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatching3To5NonWordCharacters(string tokenType, string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            (tokenType, subexpressionType) switch
            {
                ("Literal", "Direct") => BaseNamespacedClass.Literal3To5DirectNonWordCharactersPattern(),
                ("Literal", "Indirect") => BaseNamespacedClass.Literal3To5IndirectNonWordCharactersPattern(),
                ("Const in non-nested namespaced class", "Direct") => BaseNamespacedClass.Const3To5DirectNonWordCharactersPattern(),
                ("Const in non-nested namespaced class", "Indirect") => BaseNamespacedClass.Const3To5IndirectNonWordCharactersPattern(),
                ("Const in nested namespaced class", "Direct") => BaseNamespacedClass.Const3To5DirectNonWordCharactersInNestedClassPattern(),
                ("Const in nested namespaced class", "Indirect") => BaseNamespacedClass.Const3To5IndirectNonWordCharactersInNestedClassPattern(),
                ("Const in another class in same namespace", "Direct") => BaseNamespacedClass.Const3To5DirectNonWordCharactersInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", "Indirect") => BaseNamespacedClass.Const3To5IndirectNonWordCharactersInAnotherClassInSameNamespacePattern(),
                ("Const in another namespace", "Direct") => BaseNamespacedClass.Const3To5DirectNonWordCharactersInAnotherNamespacePattern(),
                ("Const in another namespace", "Indirect") => BaseNamespacedClass.Const3To5DirectNonWordCharactersInAnotherNamespacePattern(),
                ("Const in global class", "Direct") => BaseNamespacedClass.Const3To5DirectNonWordCharactersInGlobalClassPattern(),
                ("Const in global class", "Indirect") => BaseNamespacedClass.Const3To5DirectNonWordCharactersInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }
}
