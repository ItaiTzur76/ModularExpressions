namespace ModularExpressions.Generators;

internal static class Constants
{
    internal const string GenerateModexAttributeMetadataName = $"{ModularExpressionsNamespace}.{GenerateModexAttributeClassName}";
    internal const string ModularExpressionsNamespace = nameof(ModularExpressions);
    internal const string GenerateModexAttributeClassName = $"{GenerateModexAttributeUsageName}Attribute";
    internal const string GenerateModexAttributeUsageName = "GenerateModex";
    internal const string ModexClassName = "Modex";

    internal static class ModexMembers
    {
        #region Character Escapes
        internal const string Tab = "Tab";
        internal const string CarriageReturn = "CarriageReturn";
        internal const string NewLine = "NewLine";
        #endregion

        #region Character Classes
        internal const string AnyCharacterIn = "AnyCharacterIn";
        internal const string AnyCharacterNotIn = "AnyCharacterNotIn";
        internal const string NonNewLineCharacter = "NonNewLineCharacter";
        internal const string WordCharacter = "WordCharacter";
        internal const string NonWordCharacter = "NonWordCharacter";
        internal const string WhitespaceCharacter = "WhitespaceCharacter";
        internal const string NonWhitespaceCharacter = "NonWhitespaceCharacter";
        internal const string Digit = "Digit";
        internal const string NonDigit = "NonDigit";
        internal const string CharacterRange = "CharacterRange";
        #endregion

        #region Anchors
        internal const string Beginning = "Beginning";
        internal const string End = "End";
        internal const string WordBoundary = "WordBoundary";
        internal const string WordNonBoundary = "WordNonBoundary";
        #endregion

        #region Grouping Constructs
        internal const string NamedGroup = "NamedGroup";
        #endregion

        #region Quantifiers
        internal const string ZeroOrMoreOf = "ZeroOrMoreOf";
        internal const string OneOrMoreOf = "OneOrMoreOf";
        internal const string ZeroOrOneOf = "ZeroOrOneOf";
        internal const string Times = "Times";
        internal const string TimesAtLeast = "TimesAtLeast";
        internal const string TimesBetween = "TimesBetween";
        #endregion
    }

    internal static class CharacterClasses
    {
        internal const string WordCharacter = @"\\w";
        internal const string NonWordCharacter = @"\\W";
        internal const string WhitespaceCharacter = @"\\s";
        internal const string NonWhitespaceCharacter = @"\\S";
        internal const string Digit = @"\\d";
        internal const string NonDigit = @"\\D";
    }
}
