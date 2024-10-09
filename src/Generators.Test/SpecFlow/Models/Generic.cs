namespace ModularExpressions.Generators.Test.SpecFlow.Models;

internal partial class BaseGeneric<T1, T2>
{
    internal partial class NestedClass
    {
        internal partial class NestedGeneric<TT1, TT2, TT3>
        {
            [GenerateModex(nameof(DigitModex))]
            internal static partial string DigitPattern();

            private static Modex DigitModex => Digit;
        }
    }
}
