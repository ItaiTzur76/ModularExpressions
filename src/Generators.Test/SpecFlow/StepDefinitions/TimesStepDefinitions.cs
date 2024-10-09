using ModularExpressions.Generators.Test.SpecFlow.Models;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class TimesStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a (.*) Modex property matching 3 (.*) word characters")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatching3WordCharacters(string tokenType, string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            (tokenType, subexpressionType) switch
            {
                ("Literal", "Direct") => BaseNamespacedClass.Literal3DirectWordCharactersPattern(),
                ("Literal", "Indirect") => BaseNamespacedClass.Literal3IndirectWordCharactersPattern(),
                ("Const in non-nested namespaced class", "Direct") => BaseNamespacedClass.Const3DirectWordCharactersPattern(),
                ("Const in non-nested namespaced class", "Indirect") => BaseNamespacedClass.Const3IndirectWordCharactersPattern(),
                ("Const in nested namespaced class", "Direct") => BaseNamespacedClass.Const3DirectWordCharactersInNestedClassPattern(),
                ("Const in nested namespaced class", "Indirect") => BaseNamespacedClass.Const3IndirectWordCharactersInNestedClassPattern(),
                ("Const in another class in same namespace", "Direct") => BaseNamespacedClass.Const3DirectWordCharactersInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", "Indirect") => BaseNamespacedClass.Const3IndirectWordCharactersInAnotherClassInSameNamespacePattern(),
                ("Const in another namespace", "Direct") => BaseNamespacedClass.Const3DirectWordCharactersInAnotherNamespacePattern(),
                ("Const in another namespace", "Indirect") => BaseNamespacedClass.Const3IndirectWordCharactersInAnotherNamespacePattern(),
                ("Const in global class", "Direct") => BaseNamespacedClass.Const3DirectWordCharactersInGlobalClassPattern(),
                ("Const in global class", "Indirect") => BaseNamespacedClass.Const3IndirectWordCharactersInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }
}
