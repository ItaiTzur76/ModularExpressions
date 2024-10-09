namespace System;

internal static class CharExtensions
{
    internal static IEnumerable<char> RangeTo(this char first, char last)
    {
        for (char current = first; current < last; ++current)
        {
            yield return current;
        }

        yield return last;
    }
}
