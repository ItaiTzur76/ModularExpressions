using FluentAssertions;
using ModularExpressions.Generators.Test.SpecFlow.Models;

namespace ModularExpressions.Generators.Test.SpecFlow.StepDefinitions;

[Binding]
internal sealed class NamedGroupStepDefinitions(SharedStepsContext sharedStepsContext)
{
    private readonly SharedStepsContext _sharedStepsContext = sharedStepsContext;

    [When("the input string is matched against a (.*) Modex property matching a digit with the (.*) name 'myDigitGroup'")]
    private void WhenTheInputStringIsMatchedAgainstAModexPropertyMatchingADigitWithTheNameMyDigitGroup(string tokenType, string subexpressionType)
    {
        _sharedStepsContext.MatchPattern(
            (tokenType, subexpressionType) switch
            {
                ("Literal", "Direct") => BaseNamespacedClass.DirectDigitWithLiteralMyDigitNamedGroupPattern(),
                ("Literal", "Indirect") => BaseNamespacedClass.IndirectDigitWithLiteralMyDigitNamedGroupPattern(),
                ("Const in non-nested namespaced class", "Direct") => BaseNamespacedClass.DirectDigitWithConstMyDigitNamedGroupPattern(),
                ("Const in non-nested namespaced class", "Indirect") => BaseNamespacedClass.IndirectDigitWithConstMyDigitNamedGroupPattern(),
                ("Const in nested namespaced class", "Direct") => BaseNamespacedClass.DirectDigitWithConstMyDigitNamedGroupInNestedClassPattern(),
                ("Const in nested namespaced class", "Indirect") => BaseNamespacedClass.IndirectDigitWithConstMyDigitNamedGroupInNestedClassPattern(),
                ("Const in another class in same namespace", "Direct") => BaseNamespacedClass.DirectDigitWithConstMyDigitNamedGroupInAnotherClassInSameNamespacePattern(),
                ("Const in another class in same namespace", "Indirect") => BaseNamespacedClass.IndirectDigitWithConstMyDigitNamedGroupInAnotherClassInSameNamespacePattern(),
                ("Const in another namespace", "Direct") => BaseNamespacedClass.DirectDigitWithConstMyDigitNamedGroupInAnotherNamespacePattern(),
                ("Const in another namespace", "Indirect") => BaseNamespacedClass.IndirectDigitWithConstMyDigitNamedGroupInAnotherNamespacePattern(),
                ("Const in global class", "Direct") => BaseNamespacedClass.DirectDigitWithConstMyDigitNamedGroupInGlobalClassPattern(),
                ("Const in global class", "Indirect") => BaseNamespacedClass.IndirectDigitWithConstMyDigitNamedGroupInGlobalClassPattern(),
                _ => throw new NotImplementedException()
            });
    }

    [Then("the Modex matches '([^']*)' as '([^']*)'")]
    private void ThenTheModexMatchesAs(string matchedSubstring, string groupName)
    {
        SharedStepDefinitions.AssertMatch(_sharedStepsContext, matchedSubstring);
        var groups = _sharedStepsContext.Matches![0].Groups;
        groups.ContainsKey(groupName).Should().BeTrue();
        groups[groupName].Value.Should().Be(matchedSubstring);
    }
}
