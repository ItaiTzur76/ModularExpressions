namespace ModularExpressions.Generators.Test.SpecFlow.Models;

internal partial class BaseNamespacedClass
{
    private const int Const3 = 3;
    private const int Const5 = 5;

    private const char ConstSpace = ' ';
    private const char ConstExclamationMark = '!';
    private const char ConstDoubleQuote = '"';
    private const char ConstDollar = '$';
    private const char ConstPlus = '+';
    private const char ConstMinus = '-';
    private const char Const0Character = '0';
    private const char Const1Character = '1';
    private const char Const2Character = '2';
    private const char Const4Character = '4';
    private const char Const5Character = '5';
    private const char Const6Character = '6';
    private const char Const7Character = '7';
    private const char Const8Character = '8';
    private const char Const9Character = '9';
    private const char ConstA = 'A';
    private const char ConstB = 'B';
    private const char ConstC = 'C';
    private const char ConstD = 'D';
    private const char ConstE = 'E';
    private const char ConstH = 'H';
    private const char ConstJ = 'J';
    private const char ConstL = 'L';
    private const char ConstM = 'M';
    private const char ConstP = 'P';
    private const char ConstR = 'R';
    private const char ConstS = 'S';
    private const char ConstT = 'T';
    private const char ConstW = 'W';
    private const char ConstY = 'Y';
    private const char ConstZ = 'Z';
    private const char ConstLeftBracket = '[';
    private const char ConstBackslash = '\\';
    private const char ConstRightBracket = ']';
    private const char ConstCaret = '^';
    private const char ConstUnderscore = '_';
    private const char ConstBacktick = '`';

    private const string ConstMyDigitGroup = "myDigitGroup";
    private const string ConstALeftParenthesisB = "A(B";
    private const string ConstARightParenthesisB = "A)B";
    private const string ConstAAsteriskB = "A*B";
    private const string ConstAPlusB = "A+B";
    private const string ConstADotB = "A.B";
    private const string ConstAQuestionMarkB = "A?B";
    private const string ConstALeftBracketB = "A[B";
    private const string ConstARightBracketB = "A]B";
    private const string ConstALeftBraceB = "A{B";
    private const string ConstAVerticalBarB = "A|B";
    private const string ConstARightBraceB = "A}B";
    private const string ConstCaretA = "^a";
    private const string ConstUnderscoreDollar = "_$";

    [GenerateModex(nameof(LiteralCaretWOr5Modex))]
    internal static partial string LiteralCaretWOr5Pattern();

    private static Modex LiteralCaretWOr5Modex => AnyCharacterIn('^', 'W', '5');

    [GenerateModex(nameof(LiteralNotCaretWOr5Modex))]
    internal static partial string LiteralNotCaretWOr5Pattern();

    private static Modex LiteralNotCaretWOr5Modex => AnyCharacterNotIn('^', 'W', '5');

    [GenerateModex(nameof(ConstCaretWOr5Modex))]
    internal static partial string ConstCaretWOr5Pattern();

    private static Modex ConstCaretWOr5Modex => AnyCharacterIn(ConstCaret, ConstW, Const5Character);

    [GenerateModex(nameof(ConstNotCaretWOr5Modex))]
    internal static partial string ConstNotCaretWOr5Pattern();

    private static Modex ConstNotCaretWOr5Modex => AnyCharacterNotIn(ConstCaret, ConstW, Const5Character);

    [GenerateModex(nameof(ConstCaretWOr5InNestedClassModex))]
    internal static partial string ConstCaretWOr5InNestedClassPattern();

    private static Modex ConstCaretWOr5InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstCaret,
        NestedNamespacedClass.NestedConstW,
        NestedNamespacedClass.NestedConst5Character);

    [GenerateModex(nameof(ConstNotCaretWOr5InNestedClassModex))]
    internal static partial string ConstNotCaretWOr5InNestedClassPattern();

    private static Modex ConstNotCaretWOr5InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstCaret,
        NestedNamespacedClass.NestedConstW,
        NestedNamespacedClass.NestedConst5Character);

    [GenerateModex(nameof(ConstCaretWOr5InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstCaretWOr5InAnotherClassInSameNamespacePattern();

    private static Modex ConstCaretWOr5InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstCaretInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstWInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const5CharacterInAnotherClass);

    [GenerateModex(nameof(ConstNotCaretWOr5InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotCaretWOr5InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotCaretWOr5InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstCaretInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstWInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const5CharacterInAnotherClass);

    [GenerateModex(nameof(ConstCaretWOr5InAnotherNamespaceModex))]
    internal static partial string ConstCaretWOr5InAnotherNamespacePattern();

    private static Modex ConstCaretWOr5InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstCaretInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstWInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const5CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstNotCaretWOr5InAnotherNamespaceModex))]
    internal static partial string ConstNotCaretWOr5InAnotherNamespacePattern();

    private static Modex ConstNotCaretWOr5InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstCaretInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstWInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const5CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstCaretWOr5InGlobalClassModex))]
    internal static partial string ConstCaretWOr5InGlobalClassPattern();

    private static Modex ConstCaretWOr5InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstCaretInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstWInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.Const5CharacterInGlobalClass);

    [GenerateModex(nameof(ConstNotCaretWOr5InGlobalClassModex))]
    internal static partial string ConstNotCaretWOr5InGlobalClassPattern();

    private static Modex ConstNotCaretWOr5InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstCaretInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstWInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.Const5CharacterInGlobalClass);

    [GenerateModex(nameof(Literal8BackslashOrDModex))]
    internal static partial string Literal8BackslashOrDPattern();

    private static Modex Literal8BackslashOrDModex => AnyCharacterIn('8', '\\', 'D');

    [GenerateModex(nameof(LiteralNot8BackslashOrDModex))]
    internal static partial string LiteralNot8BackslashOrDPattern();

    private static Modex LiteralNot8BackslashOrDModex => AnyCharacterNotIn('8', '\\', 'D');

    [GenerateModex(nameof(Const8BackslashOrDModex))]
    internal static partial string Const8BackslashOrDPattern();

    private static Modex Const8BackslashOrDModex => AnyCharacterIn(Const8Character, ConstBackslash, ConstD);

    [GenerateModex(nameof(ConstNot8BackslashOrDModex))]
    internal static partial string ConstNot8BackslashOrDPattern();

    private static Modex ConstNot8BackslashOrDModex => AnyCharacterNotIn(Const8Character, ConstBackslash, ConstD);

    [GenerateModex(nameof(Const8BackslashOrDInNestedClassModex))]
    internal static partial string Const8BackslashOrDInNestedClassPattern();

    private static Modex Const8BackslashOrDInNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConst8Character,
        NestedNamespacedClass.NestedConstBackslash,
        NestedNamespacedClass.NestedConstD);

    [GenerateModex(nameof(ConstNot8BackslashOrDInNestedClassModex))]
    internal static partial string ConstNot8BackslashOrDInNestedClassPattern();

    private static Modex ConstNot8BackslashOrDInNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConst8Character,
        NestedNamespacedClass.NestedConstBackslash,
        NestedNamespacedClass.NestedConstD);

    [GenerateModex(nameof(Const8BackslashOrDInAnotherClassInSameNamespaceModex))]
    internal static partial string Const8BackslashOrDInAnotherClassInSameNamespacePattern();

    private static Modex Const8BackslashOrDInAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const8CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBackslashInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDInAnotherClass);

    [GenerateModex(nameof(ConstNot8BackslashOrDInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNot8BackslashOrDInAnotherClassInSameNamespacePattern();

    private static Modex ConstNot8BackslashOrDInAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const8CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBackslashInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDInAnotherClass);

    [GenerateModex(nameof(Const8BackslashOrDInAnotherNamespaceModex))]
    internal static partial string Const8BackslashOrDInAnotherNamespacePattern();

    private static Modex Const8BackslashOrDInAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const8CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBackslashInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDInAnotherNamespace);

    [GenerateModex(nameof(ConstNot8BackslashOrDInAnotherNamespaceModex))]
    internal static partial string ConstNot8BackslashOrDInAnotherNamespacePattern();

    private static Modex ConstNot8BackslashOrDInAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const8CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBackslashInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDInAnotherNamespace);

    [GenerateModex(nameof(Const8BackslashOrDInGlobalClassModex))]
    internal static partial string Const8BackslashOrDInGlobalClassPattern();

    private static Modex Const8BackslashOrDInGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.Const8CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstBackslashInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstDInGlobalClass);

    [GenerateModex(nameof(ConstNot8BackslashOrDInGlobalClassModex))]
    internal static partial string ConstNot8BackslashOrDInGlobalClassPattern();

    private static Modex ConstNot8BackslashOrDInGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.Const8CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstBackslashInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstDInGlobalClass);

    [GenerateModex(nameof(LiteralPDoubleQuoteOr6Modex))]
    internal static partial string LiteralPDoubleQuoteOr6Pattern();

    private static Modex LiteralPDoubleQuoteOr6Modex => AnyCharacterIn('P', '"', '6');

    [GenerateModex(nameof(LiteralNotPDoubleQuoteOr6Modex))]
    internal static partial string LiteralNotPDoubleQuoteOr6Pattern();

    private static Modex LiteralNotPDoubleQuoteOr6Modex => AnyCharacterNotIn('P', '"', '6');

    [GenerateModex(nameof(ConstPDoubleQuoteOr6Modex))]
    internal static partial string ConstPDoubleQuoteOr6Pattern();

    private static Modex ConstPDoubleQuoteOr6Modex => AnyCharacterIn(ConstP, ConstDoubleQuote, Const6Character);

    [GenerateModex(nameof(ConstNotPDoubleQuoteOr6Modex))]
    internal static partial string ConstNotPDoubleQuoteOr6Pattern();

    private static Modex ConstNotPDoubleQuoteOr6Modex => AnyCharacterNotIn(ConstP, ConstDoubleQuote, Const6Character);

    [GenerateModex(nameof(ConstPDoubleQuoteOr6InNestedClassModex))]
    internal static partial string ConstPDoubleQuoteOr6InNestedClassPattern();

    private static Modex ConstPDoubleQuoteOr6InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstP,
        NestedNamespacedClass.NestedConstDoubleQuote,
        NestedNamespacedClass.NestedConst6Character);

    [GenerateModex(nameof(ConstNotPDoubleQuoteOr6InNestedClassModex))]
    internal static partial string ConstNotPDoubleQuoteOr6InNestedClassPattern();

    private static Modex ConstNotPDoubleQuoteOr6InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstP,
        NestedNamespacedClass.NestedConstDoubleQuote,
        NestedNamespacedClass.NestedConst6Character);

    [GenerateModex(nameof(ConstPDoubleQuoteOr6InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstPDoubleQuoteOr6InAnotherClassInSameNamespacePattern();

    private static Modex ConstPDoubleQuoteOr6InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstPInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const6CharacterInAnotherClass);

    [GenerateModex(nameof(ConstNotPDoubleQuoteOr6InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotPDoubleQuoteOr6InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotPDoubleQuoteOr6InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstPInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const6CharacterInAnotherClass);

    [GenerateModex(nameof(ConstPDoubleQuoteOr6InAnotherNamespaceModex))]
    internal static partial string ConstPDoubleQuoteOr6InAnotherNamespacePattern();

    private static Modex ConstPDoubleQuoteOr6InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstPInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const6CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstNotPDoubleQuoteOr6InAnotherNamespaceModex))]
    internal static partial string ConstNotPDoubleQuoteOr6InAnotherNamespacePattern();

    private static Modex ConstNotPDoubleQuoteOr6InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstPInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const6CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstPDoubleQuoteOr6InGlobalClassModex))]
    internal static partial string ConstPDoubleQuoteOr6InGlobalClassPattern();

    private static Modex ConstPDoubleQuoteOr6InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstPInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstDoubleQuoteInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.Const6CharacterInGlobalClass);

    [GenerateModex(nameof(ConstNotPDoubleQuoteOr6InGlobalClassModex))]
    internal static partial string ConstNotPDoubleQuoteOr6InGlobalClassPattern();

    private static Modex ConstNotPDoubleQuoteOr6InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstPInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstDoubleQuoteInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.Const6CharacterInGlobalClass);

    [GenerateModex(nameof(Literal9RightBracketOrMModex))]
    internal static partial string Literal9RightBracketOrMPattern();

    private static Modex Literal9RightBracketOrMModex => AnyCharacterIn('9', ']', 'M');

    [GenerateModex(nameof(LiteralNot9RightBracketOrMModex))]
    internal static partial string LiteralNot9RightBracketOrMPattern();

    private static Modex LiteralNot9RightBracketOrMModex => AnyCharacterNotIn('9', ']', 'M');

    [GenerateModex(nameof(Const9RightBracketOrMModex))]
    internal static partial string Const9RightBracketOrMPattern();

    private static Modex Const9RightBracketOrMModex => AnyCharacterIn(Const9Character, ConstRightBracket, ConstM);

    [GenerateModex(nameof(ConstNot9RightBracketOrMModex))]
    internal static partial string ConstNot9RightBracketOrMPattern();

    private static Modex ConstNot9RightBracketOrMModex => AnyCharacterNotIn(Const9Character, ConstRightBracket, ConstM);

    [GenerateModex(nameof(Const9RightBracketOrMInNestedClassModex))]
    internal static partial string Const9RightBracketOrMInNestedClassPattern();

    private static Modex Const9RightBracketOrMInNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConst9Character,
        NestedNamespacedClass.NestedConstRightBracket,
        NestedNamespacedClass.NestedConstM);

    [GenerateModex(nameof(ConstNot9RightBracketOrMInNestedClassModex))]
    internal static partial string ConstNot9RightBracketOrMInNestedClassPattern();

    private static Modex ConstNot9RightBracketOrMInNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConst9Character,
        NestedNamespacedClass.NestedConstRightBracket,
        NestedNamespacedClass.NestedConstM);

    [GenerateModex(nameof(Const9RightBracketOrMInAnotherClassInSameNamespaceModex))]
    internal static partial string Const9RightBracketOrMInAnotherClassInSameNamespacePattern();

    private static Modex Const9RightBracketOrMInAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const9CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstRightBracketInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMInAnotherClass);

    [GenerateModex(nameof(ConstNot9RightBracketOrMInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNot9RightBracketOrMInAnotherClassInSameNamespacePattern();

    private static Modex ConstNot9RightBracketOrMInAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const9CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstRightBracketInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMInAnotherClass);

    [GenerateModex(nameof(Const9RightBracketOrMInAnotherNamespaceModex))]
    internal static partial string Const9RightBracketOrMInAnotherNamespacePattern();

    private static Modex Const9RightBracketOrMInAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const9CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstRightBracketInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMInAnotherNamespace);

    [GenerateModex(nameof(ConstNot9RightBracketOrMInAnotherNamespaceModex))]
    internal static partial string ConstNot9RightBracketOrMInAnotherNamespacePattern();

    private static Modex ConstNot9RightBracketOrMInAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const9CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstRightBracketInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMInAnotherNamespace);

    [GenerateModex(nameof(Const9RightBracketOrMInGlobalClassModex))]
    internal static partial string Const9RightBracketOrMInGlobalClassPattern();

    private static Modex Const9RightBracketOrMInGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.Const9CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstRightBracketInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstMInGlobalClass);

    [GenerateModex(nameof(ConstNot9RightBracketOrMInGlobalClassModex))]
    internal static partial string ConstNot9RightBracketOrMInGlobalClassPattern();

    private static Modex ConstNot9RightBracketOrMInGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.Const9CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstRightBracketInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstMInGlobalClass);

    [GenerateModex(nameof(LiteralMinus4OrJModex))]
    internal static partial string LiteralMinus4OrJPattern();

    private static Modex LiteralMinus4OrJModex => AnyCharacterIn('-', '4', 'J');

    [GenerateModex(nameof(LiteralNotMinus4OrJModex))]
    internal static partial string LiteralNotMinus4OrJPattern();

    private static Modex LiteralNotMinus4OrJModex => AnyCharacterNotIn('-', '4', 'J');

    [GenerateModex(nameof(ConstMinus4OrJModex))]
    internal static partial string ConstMinus4OrJPattern();

    private static Modex ConstMinus4OrJModex => AnyCharacterIn(ConstMinus, Const4Character, ConstJ);

    [GenerateModex(nameof(ConstNotMinus4OrJModex))]
    internal static partial string ConstNotMinus4OrJPattern();

    private static Modex ConstNotMinus4OrJModex => AnyCharacterNotIn(ConstMinus, Const4Character, ConstJ);

    [GenerateModex(nameof(ConstMinus4OrJInNestedClassModex))]
    internal static partial string ConstMinus4OrJInNestedClassPattern();

    private static Modex ConstMinus4OrJInNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstMinus,
        NestedNamespacedClass.NestedConst4Character,
        NestedNamespacedClass.NestedConstJ);

    [GenerateModex(nameof(ConstNotMinus4OrJInNestedClassModex))]
    internal static partial string ConstNotMinus4OrJInNestedClassPattern();

    private static Modex ConstNotMinus4OrJInNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstMinus,
        NestedNamespacedClass.NestedConst4Character,
        NestedNamespacedClass.NestedConstJ);

    [GenerateModex(nameof(ConstMinus4OrJInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstMinus4OrJInAnotherClassInSameNamespacePattern();

    private static Modex ConstMinus4OrJInAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const4CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstJInAnotherClass);

    [GenerateModex(nameof(ConstNotMinus4OrJInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotMinus4OrJInAnotherClassInSameNamespacePattern();

    private static Modex ConstNotMinus4OrJInAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const4CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstJInAnotherClass);

    [GenerateModex(nameof(ConstMinus4OrJInAnotherNamespaceModex))]
    internal static partial string ConstMinus4OrJInAnotherNamespacePattern();

    private static Modex ConstMinus4OrJInAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const4CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstJInAnotherNamespace);

    [GenerateModex(nameof(ConstNotMinus4OrJInAnotherNamespaceModex))]
    internal static partial string ConstNotMinus4OrJInAnotherNamespacePattern();

    private static Modex ConstNotMinus4OrJInAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const4CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstJInAnotherNamespace);

    [GenerateModex(nameof(ConstMinus4OrJInGlobalClassModex))]
    internal static partial string ConstMinus4OrJInGlobalClassPattern();

    private static Modex ConstMinus4OrJInGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.Const4CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstJInGlobalClass);

    [GenerateModex(nameof(ConstNotMinus4OrJInGlobalClassModex))]
    internal static partial string ConstNotMinus4OrJInGlobalClassPattern();

    private static Modex ConstNotMinus4OrJInGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.Const4CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstJInGlobalClass);

    [GenerateModex(nameof(LiteralC7OrMinusModex))]
    internal static partial string LiteralC7OrMinusPattern();

    private static Modex LiteralC7OrMinusModex => AnyCharacterIn('C', '7', '-');

    [GenerateModex(nameof(LiteralNotC7OrMinusModex))]
    internal static partial string LiteralNotC7OrMinusPattern();

    private static Modex LiteralNotC7OrMinusModex => AnyCharacterNotIn('C', '7', '-');

    [GenerateModex(nameof(ConstC7OrMinusModex))]
    internal static partial string ConstC7OrMinusPattern();

    private static Modex ConstC7OrMinusModex => AnyCharacterIn(ConstC, Const7Character, ConstMinus);

    [GenerateModex(nameof(ConstNotC7OrMinusModex))]
    internal static partial string ConstNotC7OrMinusPattern();

    private static Modex ConstNotC7OrMinusModex => AnyCharacterNotIn(ConstC, Const7Character, ConstMinus);

    [GenerateModex(nameof(ConstC7OrMinusInNestedClassModex))]
    internal static partial string ConstC7OrMinusInNestedClassPattern();

    private static Modex ConstC7OrMinusInNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstC,
        NestedNamespacedClass.NestedConst7Character,
        NestedNamespacedClass.NestedConstMinus);

    [GenerateModex(nameof(ConstNotC7OrMinusInNestedClassModex))]
    internal static partial string ConstNotC7OrMinusInNestedClassPattern();

    private static Modex ConstNotC7OrMinusInNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstC,
        NestedNamespacedClass.NestedConst7Character,
        NestedNamespacedClass.NestedConstMinus);

    [GenerateModex(nameof(ConstC7OrMinusInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstC7OrMinusInAnotherClassInSameNamespacePattern();

    private static Modex ConstC7OrMinusInAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstCInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const7CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass);

    [GenerateModex(nameof(ConstNotC7OrMinusInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotC7OrMinusInAnotherClassInSameNamespacePattern();

    private static Modex ConstNotC7OrMinusInAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstCInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const7CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass);

    [GenerateModex(nameof(ConstC7OrMinusInAnotherNamespaceModex))]
    internal static partial string ConstC7OrMinusInAnotherNamespacePattern();

    private static Modex ConstC7OrMinusInAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstCInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const7CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace);

    [GenerateModex(nameof(ConstNotC7OrMinusInAnotherNamespaceModex))]
    internal static partial string ConstNotC7OrMinusInAnotherNamespacePattern();

    private static Modex ConstNotC7OrMinusInAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstCInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const7CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace);

    [GenerateModex(nameof(ConstC7OrMinusInGlobalClassModex))]
    internal static partial string ConstC7OrMinusInGlobalClassPattern();

    private static Modex ConstC7OrMinusInGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstCInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.Const7CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass);

    [GenerateModex(nameof(ConstNotC7OrMinusInGlobalClassModex))]
    internal static partial string ConstNotC7OrMinusInGlobalClassPattern();

    private static Modex ConstNotC7OrMinusInGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstCInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.Const7CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass);

    [GenerateModex(nameof(Literal2MinusOrSModex))]
    internal static partial string Literal2MinusOrSPattern();

    private static Modex Literal2MinusOrSModex => AnyCharacterIn('2', '-', 'S');

    [GenerateModex(nameof(LiteralNot2MinusOrSModex))]
    internal static partial string LiteralNot2MinusOrSPattern();

    private static Modex LiteralNot2MinusOrSModex => AnyCharacterNotIn('2', '-', 'S');

    [GenerateModex(nameof(Const2MinusOrSModex))]
    internal static partial string Const2MinusOrSPattern();

    private static Modex Const2MinusOrSModex => AnyCharacterIn(Const2Character, ConstMinus, ConstS);

    [GenerateModex(nameof(ConstNot2MinusOrSModex))]
    internal static partial string ConstNot2MinusOrSPattern();

    private static Modex ConstNot2MinusOrSModex => AnyCharacterNotIn(Const2Character, ConstMinus, ConstS);

    [GenerateModex(nameof(Const2MinusOrSInNestedClassModex))]
    internal static partial string Const2MinusOrSInNestedClassPattern();

    private static Modex Const2MinusOrSInNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConst2Character,
        NestedNamespacedClass.NestedConstMinus,
        NestedNamespacedClass.NestedConstS);

    [GenerateModex(nameof(ConstNot2MinusOrSInNestedClassModex))]
    internal static partial string ConstNot2MinusOrSInNestedClassPattern();

    private static Modex ConstNot2MinusOrSInNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConst2Character,
        NestedNamespacedClass.NestedConstMinus,
        NestedNamespacedClass.NestedConstS);

    [GenerateModex(nameof(Const2MinusOrSInAnotherClassInSameNamespaceModex))]
    internal static partial string Const2MinusOrSInAnotherClassInSameNamespacePattern();

    private static Modex Const2MinusOrSInAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const2CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstSInAnotherClass);

    [GenerateModex(nameof(ConstNot2MinusOrSInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNot2MinusOrSInAnotherClassInSameNamespacePattern();

    private static Modex ConstNot2MinusOrSInAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const2CharacterInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass,
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstSInAnotherClass);

    [GenerateModex(nameof(Const2MinusOrSInAnotherNamespaceModex))]
    internal static partial string Const2MinusOrSInAnotherNamespacePattern();

    private static Modex Const2MinusOrSInAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const2CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstSInAnotherNamespace);

    [GenerateModex(nameof(ConstNot2MinusOrSInAnotherNamespaceModex))]
    internal static partial string ConstNot2MinusOrSInAnotherNamespacePattern();

    private static Modex ConstNot2MinusOrSInAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const2CharacterInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace,
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstSInAnotherNamespace);

    [GenerateModex(nameof(Const2MinusOrSInGlobalClassModex))]
    internal static partial string Const2MinusOrSInGlobalClassPattern();

    private static Modex Const2MinusOrSInGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.Const2CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstSInGlobalClass);

    [GenerateModex(nameof(ConstNot2MinusOrSInGlobalClassModex))]
    internal static partial string ConstNot2MinusOrSInGlobalClassPattern();

    private static Modex ConstNot2MinusOrSInGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.Const2CharacterInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass,
        BaseGlobalClass.NestedGlobalClass.ConstSInGlobalClass);

    [GenerateModex(nameof(AtAWordCharacterOrExclamationMarkModex))]
    internal static partial string AtAWordCharacterOrExclamationMarkPattern();

    private static Modex AtAWordCharacterOrExclamationMarkModex => AnyCharacterIn('@', WordCharacter, '!');

    [GenerateModex(nameof(NotAtWordCharactersOrExclamationMarkModex))]
    internal static partial string NotAtWordCharactersOrExclamationMarkPattern();

    private static Modex NotAtWordCharactersOrExclamationMarkModex => AnyCharacterNotIn('@', WordCharacter, '!');

    [GenerateModex(nameof(CANonWordCharacterOr1Modex))]
    internal static partial string CANonWordCharacterOr1Pattern();

    private static Modex CANonWordCharacterOr1Modex => AnyCharacterIn('C', NonWordCharacter, '1');

    [GenerateModex(nameof(NotCNonWordCharactersOr1Modex))]
    internal static partial string NotCNonWordCharactersOr1Pattern();

    private static Modex NotCNonWordCharactersOr1Modex => AnyCharacterNotIn('C', NonWordCharacter, '1');

    [GenerateModex(nameof(QAWhitespaceCharacterOr2Modex))]
    internal static partial string QAWhitespaceCharacterOr2Pattern();

    private static Modex QAWhitespaceCharacterOr2Modex => AnyCharacterIn('Q', WhitespaceCharacter, '2');

    [GenerateModex(nameof(NotQWhitespaceCharactersOr2Modex))]
    internal static partial string NotQWhitespaceCharactersOr2Pattern();

    private static Modex NotQWhitespaceCharactersOr2Modex => AnyCharacterNotIn('Q', WhitespaceCharacter, '2');

    [GenerateModex(nameof(ANonWhitespaceCharacterOrATabModex))]
    internal static partial string ANonWhitespaceCharacterOrATabPattern();

    private static Modex ANonWhitespaceCharacterOrATabModex => AnyCharacterIn(NonWhitespaceCharacter, '\t');

    [GenerateModex(nameof(NotNonWhitespaceCharactersOrATabModex))]
    internal static partial string NotNonWhitespaceCharactersOrATabPattern();

    private static Modex NotNonWhitespaceCharactersOrATabModex => AnyCharacterNotIn(NonWhitespaceCharacter, '\t');

    [GenerateModex(nameof(XADigitOrPercentModex))]
    internal static partial string XADigitOrPercentPattern();

    private static Modex XADigitOrPercentModex => AnyCharacterIn('X', Digit, '%');

    [GenerateModex(nameof(NotXDigitsOrPercentModex))]
    internal static partial string NotXDigitsOrPercentPattern();

    private static Modex NotXDigitsOrPercentModex => AnyCharacterNotIn('X', Digit, '%');

    [GenerateModex(nameof(ThreeANonDigitOr8Modex))]
    internal static partial string ThreeANonDigitOr8Pattern();

    private static Modex ThreeANonDigitOr8Modex => AnyCharacterIn('3', NonDigit, '8');

    [GenerateModex(nameof(Not3NonDigitsOr8Modex))]
    internal static partial string Not3NonDigitsOr8Pattern();

    private static Modex Not3NonDigitsOr8Modex => AnyCharacterNotIn('3', NonDigit, '8');

    [GenerateModex(nameof(LiteralCaretToBacktickOrBModex))]
    internal static partial string LiteralCaretToBacktickOrBPattern();

    private static Modex LiteralCaretToBacktickOrBModex => AnyCharacterIn(CharacterRange(first: '^', last: '`'), 'B');

    [GenerateModex(nameof(LiteralNotCaretToBacktickOrBModex))]
    internal static partial string LiteralNotCaretToBacktickOrBPattern();

    private static Modex LiteralNotCaretToBacktickOrBModex => AnyCharacterNotIn(CharacterRange(first: '^', last: '`'), 'B');

    [GenerateModex(nameof(ConstCaretToBacktickOrBModex))]
    internal static partial string ConstCaretToBacktickOrBPattern();

    private static Modex ConstCaretToBacktickOrBModex
        => AnyCharacterIn(CharacterRange(first: ConstCaret, last: ConstBacktick), ConstB);

    [GenerateModex(nameof(ConstNotCaretToBacktickOrBModex))]
    internal static partial string ConstNotCaretToBacktickOrBPattern();

    private static Modex ConstNotCaretToBacktickOrBModex
        => AnyCharacterNotIn(CharacterRange(first: ConstCaret, last: ConstBacktick), ConstB);

    [GenerateModex(nameof(ConstCaretToBacktickOrBInNestedClassModex))]
    internal static partial string ConstCaretToBacktickOrBInNestedClassPattern();

    private static Modex ConstCaretToBacktickOrBInNestedClassModex => AnyCharacterIn(
        CharacterRange(first: NestedNamespacedClass.NestedConstCaret, last: NestedNamespacedClass.NestedConstBacktick),
        NestedNamespacedClass.NestedConstB);

    [GenerateModex(nameof(ConstNotCaretToBacktickOrBInNestedClassModex))]
    internal static partial string ConstNotCaretToBacktickOrBInNestedClassPattern();

    private static Modex ConstNotCaretToBacktickOrBInNestedClassModex => AnyCharacterNotIn(
        CharacterRange(first: NestedNamespacedClass.NestedConstCaret, last: NestedNamespacedClass.NestedConstBacktick),
        NestedNamespacedClass.NestedConstB);

    [GenerateModex(nameof(ConstCaretToBacktickOrBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstCaretToBacktickOrBInAnotherClassInSameNamespacePattern();

    private static Modex ConstCaretToBacktickOrBInAnotherClassInSameNamespaceModex => AnyCharacterIn(
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstCaretInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBacktickInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBInAnotherClass);

    [GenerateModex(nameof(ConstNotCaretToBacktickOrBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotCaretToBacktickOrBInAnotherClassInSameNamespacePattern();

    private static Modex ConstNotCaretToBacktickOrBInAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstCaretInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBacktickInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBInAnotherClass);

    [GenerateModex(nameof(ConstCaretToBacktickOrBInAnotherNamespaceModex))]
    internal static partial string ConstCaretToBacktickOrBInAnotherNamespacePattern();

    private static Modex ConstCaretToBacktickOrBInAnotherNamespaceModex => AnyCharacterIn(
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstCaretInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBacktickInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBInAnotherNamespace);

    [GenerateModex(nameof(ConstNotCaretToBacktickOrBInAnotherNamespaceModex))]
    internal static partial string ConstNotCaretToBacktickOrBInAnotherNamespacePattern();

    private static Modex ConstNotCaretToBacktickOrBInAnotherNamespaceModex => AnyCharacterNotIn(
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstCaretInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBacktickInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBInAnotherNamespace);

    [GenerateModex(nameof(ConstCaretToBacktickOrBInGlobalClassModex))]
    internal static partial string ConstCaretToBacktickOrBInGlobalClassPattern();

    private static Modex ConstCaretToBacktickOrBInGlobalClassModex => AnyCharacterIn(
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstCaretInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstBacktickInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.ConstBInGlobalClass);

    [GenerateModex(nameof(ConstNotCaretToBacktickOrBInGlobalClassModex))]
    internal static partial string ConstNotCaretToBacktickOrBInGlobalClassPattern();

    private static Modex ConstNotCaretToBacktickOrBInGlobalClassModex => AnyCharacterNotIn(
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstCaretInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstBacktickInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.ConstBInGlobalClass);

    [GenerateModex(nameof(LiteralZBackslashToUnderscoreOr0Modex))]
    internal static partial string LiteralZBackslashToUnderscoreOr0Pattern();

    private static Modex LiteralZBackslashToUnderscoreOr0Modex
        => AnyCharacterIn('Z', CharacterRange(first: '\\', last: '_'), '0');

    [GenerateModex(nameof(LiteralNotZBackslashToUnderscoreOr0Modex))]
    internal static partial string LiteralNotZBackslashToUnderscoreOr0Pattern();

    private static Modex LiteralNotZBackslashToUnderscoreOr0Modex
        => AnyCharacterNotIn('Z', CharacterRange(first: '\\', last: '_'), '0');

    [GenerateModex(nameof(ConstZBackslashToUnderscoreOr0Modex))]
    internal static partial string ConstZBackslashToUnderscoreOr0Pattern();

    private static Modex ConstZBackslashToUnderscoreOr0Modex
        => AnyCharacterIn(ConstZ, CharacterRange(first: ConstBackslash, last: ConstUnderscore), Const0Character);

    [GenerateModex(nameof(ConstNotZBackslashToUnderscoreOr0Modex))]
    internal static partial string ConstNotZBackslashToUnderscoreOr0Pattern();

    private static Modex ConstNotZBackslashToUnderscoreOr0Modex
        => AnyCharacterNotIn(ConstZ, CharacterRange(first: ConstBackslash, last: ConstUnderscore), Const0Character);

    [GenerateModex(nameof(ConstZBackslashToUnderscoreOr0InNestedClassModex))]
    internal static partial string ConstZBackslashToUnderscoreOr0InNestedClassPattern();

    private static Modex ConstZBackslashToUnderscoreOr0InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstZ,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstBackslash, last: NestedNamespacedClass.NestedConstUnderscore),
        NestedNamespacedClass.NestedConst0Character);

    [GenerateModex(nameof(ConstNotZBackslashToUnderscoreOr0InNestedClassModex))]
    internal static partial string ConstNotZBackslashToUnderscoreOr0InNestedClassPattern();

    private static Modex ConstNotZBackslashToUnderscoreOr0InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstZ,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstBackslash, last: NestedNamespacedClass.NestedConstUnderscore),
        NestedNamespacedClass.NestedConst0Character);

    [GenerateModex(nameof(ConstZBackslashToUnderscoreOr0InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstZBackslashToUnderscoreOr0InAnotherClassInSameNamespacePattern();

    private static Modex ConstZBackslashToUnderscoreOr0InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstZInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBackslashInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstUnderscoreInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const0CharacterInAnotherClass);

    [GenerateModex(nameof(ConstNotZBackslashToUnderscoreOr0InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotZBackslashToUnderscoreOr0InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotZBackslashToUnderscoreOr0InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstZInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBackslashInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstUnderscoreInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const0CharacterInAnotherClass);

    [GenerateModex(nameof(ConstZBackslashToUnderscoreOr0InAnotherNamespaceModex))]
    internal static partial string ConstZBackslashToUnderscoreOr0InAnotherNamespacePattern();

    private static Modex ConstZBackslashToUnderscoreOr0InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstZInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBackslashInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstUnderscoreInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const0CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstNotZBackslashToUnderscoreOr0InAnotherNamespaceModex))]
    internal static partial string ConstNotZBackslashToUnderscoreOr0InAnotherNamespacePattern();

    private static Modex ConstNotZBackslashToUnderscoreOr0InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstZInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBackslashInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstUnderscoreInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const0CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstZBackslashToUnderscoreOr0InGlobalClassModex))]
    internal static partial string ConstZBackslashToUnderscoreOr0InGlobalClassPattern();

    private static Modex ConstZBackslashToUnderscoreOr0InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstZInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstBackslashInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstUnderscoreInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const0CharacterInGlobalClass);

    [GenerateModex(nameof(ConstNotZBackslashToUnderscoreOr0InGlobalClassModex))]
    internal static partial string ConstNotZBackslashToUnderscoreOr0InGlobalClassPattern();

    private static Modex ConstNotZBackslashToUnderscoreOr0InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstZInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstBackslashInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstUnderscoreInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const0CharacterInGlobalClass);

    [GenerateModex(nameof(LiteralRZToBackslashOr5Modex))]
    internal static partial string LiteralRZToBackslashOr5Pattern();

    private static Modex LiteralRZToBackslashOr5Modex
        => AnyCharacterIn('R', CharacterRange(first: 'Z', last: '\\'), '5');

    [GenerateModex(nameof(LiteralNotRZToBackslashOr5Modex))]
    internal static partial string LiteralNotRZToBackslashOr5Pattern();

    private static Modex LiteralNotRZToBackslashOr5Modex
        => AnyCharacterNotIn('R', CharacterRange(first: 'Z', last: '\\'), '5');

    [GenerateModex(nameof(ConstRZToBackslashOr5Modex))]
    internal static partial string ConstRZToBackslashOr5Pattern();

    private static Modex ConstRZToBackslashOr5Modex
        => AnyCharacterIn(ConstR, CharacterRange(first: ConstZ, last: ConstBackslash), Const5Character);

    [GenerateModex(nameof(ConstNotRZToBackslashOr5Modex))]
    internal static partial string ConstNotRZToBackslashOr5Pattern();

    private static Modex ConstNotRZToBackslashOr5Modex
        => AnyCharacterNotIn(ConstR, CharacterRange(first: ConstZ, last: ConstBackslash), Const5Character);

    [GenerateModex(nameof(ConstRZToBackslashOr5InNestedClassModex))]
    internal static partial string ConstRZToBackslashOr5InNestedClassPattern();

    private static Modex ConstRZToBackslashOr5InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstR,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstZ, last: NestedNamespacedClass.NestedConstBackslash),
        NestedNamespacedClass.NestedConst5Character);

    [GenerateModex(nameof(ConstNotRZToBackslashOr5InNestedClassModex))]
    internal static partial string ConstNotRZToBackslashOr5InNestedClassPattern();

    private static Modex ConstNotRZToBackslashOr5InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstR,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstZ, last: NestedNamespacedClass.NestedConstBackslash),
        NestedNamespacedClass.NestedConst5Character);

    [GenerateModex(nameof(ConstRZToBackslashOr5InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstRZToBackslashOr5InAnotherClassInSameNamespacePattern();

    private static Modex ConstRZToBackslashOr5InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstRInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstZInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBackslashInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const5CharacterInAnotherClass);

    [GenerateModex(nameof(ConstNotRZToBackslashOr5InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotRZToBackslashOr5InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotRZToBackslashOr5InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstRInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstZInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBackslashInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const5CharacterInAnotherClass);

    [GenerateModex(nameof(ConstRZToBackslashOr5InAnotherNamespaceModex))]
    internal static partial string ConstRZToBackslashOr5InAnotherNamespacePattern();

    private static Modex ConstRZToBackslashOr5InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstRInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstZInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBackslashInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const5CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstNotRZToBackslashOr5InAnotherNamespaceModex))]
    internal static partial string ConstNotRZToBackslashOr5InAnotherNamespacePattern();

    private static Modex ConstNotRZToBackslashOr5InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstRInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstZInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBackslashInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const5CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstRZToBackslashOr5InGlobalClassModex))]
    internal static partial string ConstRZToBackslashOr5InGlobalClassPattern();

    private static Modex ConstRZToBackslashOr5InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstRInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstZInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstBackslashInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const5CharacterInGlobalClass);

    [GenerateModex(nameof(ConstNotRZToBackslashOr5InGlobalClassModex))]
    internal static partial string ConstNotRZToBackslashOr5InGlobalClassPattern();

    private static Modex ConstNotRZToBackslashOr5InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstRInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstZInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstBackslashInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const5CharacterInGlobalClass);

    [GenerateModex(nameof(LiteralYDoubleQuoteToDollarOr1Modex))]
    internal static partial string LiteralYDoubleQuoteToDollarOr1Pattern();

    private static Modex LiteralYDoubleQuoteToDollarOr1Modex
        => AnyCharacterIn('Y', CharacterRange(first: '"', last: '$'), '1');

    [GenerateModex(nameof(LiteralNotYDoubleQuoteToDollarOr1Modex))]
    internal static partial string LiteralNotYDoubleQuoteToDollarOr1Pattern();

    private static Modex LiteralNotYDoubleQuoteToDollarOr1Modex
        => AnyCharacterNotIn('Y', CharacterRange(first: '"', last: '$'), '1');

    [GenerateModex(nameof(ConstYDoubleQuoteToDollarOr1Modex))]
    internal static partial string ConstYDoubleQuoteToDollarOr1Pattern();

    private static Modex ConstYDoubleQuoteToDollarOr1Modex
        => AnyCharacterIn(ConstY, CharacterRange(first: ConstDoubleQuote, last: ConstDollar), Const1Character);

    [GenerateModex(nameof(ConstNotYDoubleQuoteToDollarOr1Modex))]
    internal static partial string ConstNotYDoubleQuoteToDollarOr1Pattern();

    private static Modex ConstNotYDoubleQuoteToDollarOr1Modex
        => AnyCharacterNotIn(ConstY, CharacterRange(first: ConstDoubleQuote, last: ConstDollar), Const1Character);

    [GenerateModex(nameof(ConstYDoubleQuoteToDollarOr1InNestedClassModex))]
    internal static partial string ConstYDoubleQuoteToDollarOr1InNestedClassPattern();

    private static Modex ConstYDoubleQuoteToDollarOr1InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstY,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstDoubleQuote, last: NestedNamespacedClass.NestedConstDollar),
        NestedNamespacedClass.NestedConst1Character);

    [GenerateModex(nameof(ConstNotYDoubleQuoteToDollarOr1InNestedClassModex))]
    internal static partial string ConstNotYDoubleQuoteToDollarOr1InNestedClassPattern();

    private static Modex ConstNotYDoubleQuoteToDollarOr1InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstY,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstDoubleQuote, last: NestedNamespacedClass.NestedConstDollar),
        NestedNamespacedClass.NestedConst1Character);

    [GenerateModex(nameof(ConstYDoubleQuoteToDollarOr1InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstYDoubleQuoteToDollarOr1InAnotherClassInSameNamespacePattern();

    private static Modex ConstYDoubleQuoteToDollarOr1InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstYInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDollarInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const1CharacterInAnotherClass);

    [GenerateModex(nameof(ConstNotYDoubleQuoteToDollarOr1InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotYDoubleQuoteToDollarOr1InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotYDoubleQuoteToDollarOr1InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstYInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDollarInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const1CharacterInAnotherClass);

    [GenerateModex(nameof(ConstYDoubleQuoteToDollarOr1InAnotherNamespaceModex))]
    internal static partial string ConstYDoubleQuoteToDollarOr1InAnotherNamespacePattern();

    private static Modex ConstYDoubleQuoteToDollarOr1InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstYInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDollarInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const1CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstNotYDoubleQuoteToDollarOr1InAnotherNamespaceModex))]
    internal static partial string ConstNotYDoubleQuoteToDollarOr1InAnotherNamespacePattern();

    private static Modex ConstNotYDoubleQuoteToDollarOr1InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstYInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDollarInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const1CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstYDoubleQuoteToDollarOr1InGlobalClassModex))]
    internal static partial string ConstYDoubleQuoteToDollarOr1InGlobalClassPattern();

    private static Modex ConstYDoubleQuoteToDollarOr1InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstYInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstDoubleQuoteInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstDollarInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const1CharacterInGlobalClass);

    [GenerateModex(nameof(ConstNotYDoubleQuoteToDollarOr1InGlobalClassModex))]
    internal static partial string ConstNotYDoubleQuoteToDollarOr1InGlobalClassPattern();

    private static Modex ConstNotYDoubleQuoteToDollarOr1InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstYInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstDoubleQuoteInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstDollarInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const1CharacterInGlobalClass);

    [GenerateModex(nameof(LiteralEExclamationMarkToDoubleQuoteOr7Modex))]
    internal static partial string LiteralEExclamationMarkToDoubleQuoteOr7Pattern();

    private static Modex LiteralEExclamationMarkToDoubleQuoteOr7Modex
        => AnyCharacterIn('E', CharacterRange(first: '!', last: '"'), '7');

    [GenerateModex(nameof(LiteralNotESpaceToDoubleQuoteOr7Modex))]
    internal static partial string LiteralNotESpaceToDoubleQuoteOr7Pattern();

    private static Modex LiteralNotESpaceToDoubleQuoteOr7Modex
        => AnyCharacterNotIn('E', CharacterRange(first: ' ', last: '"'), '7');

    [GenerateModex(nameof(ConstEExclamationMarkToDoubleQuoteOr7Modex))]
    internal static partial string ConstEExclamationMarkToDoubleQuoteOr7Pattern();

    private static Modex ConstEExclamationMarkToDoubleQuoteOr7Modex
        => AnyCharacterIn(ConstE, CharacterRange(first: ConstExclamationMark, last: ConstDoubleQuote), Const7Character);

    [GenerateModex(nameof(ConstNotESpaceToDoubleQuoteOr7Modex))]
    internal static partial string ConstNotESpaceToDoubleQuoteOr7Pattern();

    private static Modex ConstNotESpaceToDoubleQuoteOr7Modex
        => AnyCharacterNotIn(ConstE, CharacterRange(first: ConstSpace, last: ConstDoubleQuote), Const7Character);

    [GenerateModex(nameof(ConstEExclamationMarkToDoubleQuoteOr7InNestedClassModex))]
    internal static partial string ConstEExclamationMarkToDoubleQuoteOr7InNestedClassPattern();

    private static Modex ConstEExclamationMarkToDoubleQuoteOr7InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstE,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstExclamationMark,
            last: NestedNamespacedClass.NestedConstDoubleQuote),
        NestedNamespacedClass.NestedConst7Character);

    [GenerateModex(nameof(ConstNotESpaceToDoubleQuoteOr7InNestedClassModex))]
    internal static partial string ConstNotESpaceToDoubleQuoteOr7InNestedClassPattern();

    private static Modex ConstNotESpaceToDoubleQuoteOr7InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstE,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstSpace,
            last: NestedNamespacedClass.NestedConstDoubleQuote),
        NestedNamespacedClass.NestedConst7Character);

    [GenerateModex(nameof(ConstEExclamationMarkToDoubleQuoteOr7InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstEExclamationMarkToDoubleQuoteOr7InAnotherClassInSameNamespacePattern();

    private static Modex ConstEExclamationMarkToDoubleQuoteOr7InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstEInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstExclamationMarkInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const7CharacterInAnotherClass);

    [GenerateModex(nameof(ConstNotESpaceToDoubleQuoteOr7InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotESpaceToDoubleQuoteOr7InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotESpaceToDoubleQuoteOr7InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstEInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstSpaceInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const7CharacterInAnotherClass);

    [GenerateModex(nameof(ConstEExclamationMarkToDoubleQuoteOr7InAnotherNamespaceModex))]
    internal static partial string ConstEExclamationMarkToDoubleQuoteOr7InAnotherNamespacePattern();

    private static Modex ConstEExclamationMarkToDoubleQuoteOr7InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstEInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstExclamationMarkInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const7CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstNotESpaceToDoubleQuoteOr7InAnotherNamespaceModex))]
    internal static partial string ConstNotESpaceToDoubleQuoteOr7InAnotherNamespacePattern();

    private static Modex ConstNotESpaceToDoubleQuoteOr7InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstEInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstSpaceInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstDoubleQuoteInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const7CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstEExclamationMarkToDoubleQuoteOr7InGlobalClassModex))]
    internal static partial string ConstEExclamationMarkToDoubleQuoteOr7InGlobalClassPattern();

    private static Modex ConstEExclamationMarkToDoubleQuoteOr7InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstEInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstExclamationMarkInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstDoubleQuoteInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const7CharacterInGlobalClass);

    [GenerateModex(nameof(ConstNotESpaceToDoubleQuoteOr7InGlobalClassModex))]
    internal static partial string ConstNotESpaceToDoubleQuoteOr7InGlobalClassPattern();

    private static Modex ConstNotESpaceToDoubleQuoteOr7InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstEInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstSpaceInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstDoubleQuoteInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const7CharacterInGlobalClass);

    [GenerateModex(nameof(LiteralARightBracketToBacktickOr2Modex))]
    internal static partial string LiteralARightBracketToBacktickOr2Pattern();

    private static Modex LiteralARightBracketToBacktickOr2Modex
        => AnyCharacterIn('A', CharacterRange(first: ']', last: '`'), '2');

    [GenerateModex(nameof(LiteralNotARightBracketToBacktickOr2Modex))]
    internal static partial string LiteralNotARightBracketToBacktickOr2Pattern();

    private static Modex LiteralNotARightBracketToBacktickOr2Modex
        => AnyCharacterNotIn('A', CharacterRange(first: ']', last: '`'), '2');

    [GenerateModex(nameof(ConstARightBracketToBacktickOr2Modex))]
    internal static partial string ConstARightBracketToBacktickOr2Pattern();

    private static Modex ConstARightBracketToBacktickOr2Modex
        => AnyCharacterIn(ConstA, CharacterRange(first: ConstRightBracket, last: ConstBacktick), Const2Character);

    [GenerateModex(nameof(ConstNotARightBracketToBacktickOr2Modex))]
    internal static partial string ConstNotARightBracketToBacktickOr2Pattern();

    private static Modex ConstNotARightBracketToBacktickOr2Modex
        => AnyCharacterNotIn(ConstA, CharacterRange(first: ConstRightBracket, last: ConstBacktick), Const2Character);

    [GenerateModex(nameof(ConstARightBracketToBacktickOr2InNestedClassModex))]
    internal static partial string ConstARightBracketToBacktickOr2InNestedClassPattern();

    private static Modex ConstARightBracketToBacktickOr2InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstA,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstRightBracket, last: NestedNamespacedClass.NestedConstBacktick),
        NestedNamespacedClass.NestedConst2Character);

    [GenerateModex(nameof(ConstNotARightBracketToBacktickOr2InNestedClassModex))]
    internal static partial string ConstNotARightBracketToBacktickOr2InNestedClassPattern();

    private static Modex ConstNotARightBracketToBacktickOr2InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstA,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstRightBracket, last: NestedNamespacedClass.NestedConstBacktick),
        NestedNamespacedClass.NestedConst2Character);

    [GenerateModex(nameof(ConstARightBracketToBacktickOr2InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstARightBracketToBacktickOr2InAnotherClassInSameNamespacePattern();

    private static Modex ConstARightBracketToBacktickOr2InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstAInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstRightBracketInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBacktickInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const2CharacterInAnotherClass);

    [GenerateModex(nameof(ConstNotARightBracketToBacktickOr2InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotARightBracketToBacktickOr2InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotARightBracketToBacktickOr2InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstAInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstRightBracketInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstBacktickInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const2CharacterInAnotherClass);

    [GenerateModex(nameof(ConstARightBracketToBacktickOr2InAnotherNamespaceModex))]
    internal static partial string ConstARightBracketToBacktickOr2InAnotherNamespacePattern();

    private static Modex ConstARightBracketToBacktickOr2InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstAInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstRightBracketInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBacktickInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const2CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstNotARightBracketToBacktickOr2InAnotherNamespaceModex))]
    internal static partial string ConstNotARightBracketToBacktickOr2InAnotherNamespacePattern();

    private static Modex ConstNotARightBracketToBacktickOr2InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstAInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstRightBracketInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstBacktickInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const2CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstARightBracketToBacktickOr2InGlobalClassModex))]
    internal static partial string ConstARightBracketToBacktickOr2InGlobalClassPattern();

    private static Modex ConstARightBracketToBacktickOr2InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstAInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstRightBracketInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstBacktickInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const2CharacterInGlobalClass);

    [GenerateModex(nameof(ConstNotARightBracketToBacktickOr2InGlobalClassModex))]
    internal static partial string ConstNotARightBracketToBacktickOr2InGlobalClassPattern();

    private static Modex ConstNotARightBracketToBacktickOr2InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstAInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstRightBracketInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstBacktickInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const2CharacterInGlobalClass);

    [GenerateModex(nameof(LiteralHLeftBracketToRightBracketOr8Modex))]
    internal static partial string LiteralHLeftBracketToRightBracketOr8Pattern();

    private static Modex LiteralHLeftBracketToRightBracketOr8Modex
        => AnyCharacterIn('H', CharacterRange(first: '[', last: ']'), '8');

    [GenerateModex(nameof(LiteralNotHLeftBracketToRightBracketOr8Modex))]
    internal static partial string LiteralNotHLeftBracketToRightBracketOr8Pattern();

    private static Modex LiteralNotHLeftBracketToRightBracketOr8Modex
        => AnyCharacterNotIn('H', CharacterRange(first: '[', last: ']'), '8');

    [GenerateModex(nameof(ConstHLeftBracketToRightBracketOr8Modex))]
    internal static partial string ConstHLeftBracketToRightBracketOr8Pattern();

    private static Modex ConstHLeftBracketToRightBracketOr8Modex
        => AnyCharacterIn(ConstH, CharacterRange(first: ConstLeftBracket, last: ConstRightBracket), Const8Character);

    [GenerateModex(nameof(ConstNotHLeftBracketToRightBracketOr8Modex))]
    internal static partial string ConstNotHLeftBracketToRightBracketOr8Pattern();

    private static Modex ConstNotHLeftBracketToRightBracketOr8Modex
        => AnyCharacterNotIn(ConstH, CharacterRange(first: ConstLeftBracket, last: ConstRightBracket), Const8Character);

    [GenerateModex(nameof(ConstHLeftBracketToRightBracketOr8InNestedClassModex))]
    internal static partial string ConstHLeftBracketToRightBracketOr8InNestedClassPattern();

    private static Modex ConstHLeftBracketToRightBracketOr8InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstH,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstLeftBracket, last: NestedNamespacedClass.NestedConstRightBracket),
        NestedNamespacedClass.NestedConst8Character);

    [GenerateModex(nameof(ConstNotHLeftBracketToRightBracketOr8InNestedClassModex))]
    internal static partial string ConstNotHLeftBracketToRightBracketOr8InNestedClassPattern();

    private static Modex ConstNotHLeftBracketToRightBracketOr8InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstH,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstLeftBracket, last: NestedNamespacedClass.NestedConstRightBracket),
        NestedNamespacedClass.NestedConst8Character);

    [GenerateModex(nameof(ConstHLeftBracketToRightBracketOr8InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstHLeftBracketToRightBracketOr8InAnotherClassInSameNamespacePattern();

    private static Modex ConstHLeftBracketToRightBracketOr8InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstHInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstLeftBracketInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstRightBracketInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const8CharacterInAnotherClass);

    [GenerateModex(nameof(ConstNotHLeftBracketToRightBracketOr8InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotHLeftBracketToRightBracketOr8InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotHLeftBracketToRightBracketOr8InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstHInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstLeftBracketInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstRightBracketInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.Const8CharacterInAnotherClass);

    [GenerateModex(nameof(ConstHLeftBracketToRightBracketOr8InAnotherNamespaceModex))]
    internal static partial string ConstHLeftBracketToRightBracketOr8InAnotherNamespacePattern();

    private static Modex ConstHLeftBracketToRightBracketOr8InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstHInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstLeftBracketInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstRightBracketInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const8CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstNotHLeftBracketToRightBracketOr8InAnotherNamespaceModex))]
    internal static partial string ConstNotHLeftBracketToRightBracketOr8InAnotherNamespacePattern();

    private static Modex ConstNotHLeftBracketToRightBracketOr8InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstHInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstLeftBracketInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstRightBracketInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const8CharacterInAnotherNamespace);

    [GenerateModex(nameof(ConstHLeftBracketToRightBracketOr8InGlobalClassModex))]
    internal static partial string ConstHLeftBracketToRightBracketOr8InGlobalClassPattern();

    private static Modex ConstHLeftBracketToRightBracketOr8InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstHInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstLeftBracketInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstRightBracketInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const8CharacterInGlobalClass);

    [GenerateModex(nameof(ConstNotHLeftBracketToRightBracketOr8InGlobalClassModex))]
    internal static partial string ConstNotHLeftBracketToRightBracketOr8InGlobalClassPattern();

    private static Modex ConstNotHLeftBracketToRightBracketOr8InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstHInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstLeftBracketInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstRightBracketInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.Const8CharacterInGlobalClass);

    [GenerateModex(nameof(LiteralPlusToMinusOrLModex))]
    internal static partial string LiteralPlusToMinusOrLPattern();

    private static Modex LiteralPlusToMinusOrLModex => AnyCharacterIn(CharacterRange(first: '+', last: '-'), 'L');

    [GenerateModex(nameof(LiteralNotPlusToMinusOrLModex))]
    internal static partial string LiteralNotPlusToMinusOrLPattern();

    private static Modex LiteralNotPlusToMinusOrLModex => AnyCharacterNotIn(CharacterRange(first: '+', last: '-'), 'L');

    [GenerateModex(nameof(ConstPlusToMinusOrLModex))]
    internal static partial string ConstPlusToMinusOrLPattern();

    private static Modex ConstPlusToMinusOrLModex
        => AnyCharacterIn(CharacterRange(first: ConstPlus, last: ConstMinus), ConstL);

    [GenerateModex(nameof(ConstNotPlusToMinusOrLModex))]
    internal static partial string ConstNotPlusToMinusOrLPattern();

    private static Modex ConstNotPlusToMinusOrLModex
        => AnyCharacterNotIn(CharacterRange(first: ConstPlus, last: ConstMinus), ConstL);

    [GenerateModex(nameof(ConstPlusToMinusOrLInNestedClassModex))]
    internal static partial string ConstPlusToMinusOrLInNestedClassPattern();

    private static Modex ConstPlusToMinusOrLInNestedClassModex => AnyCharacterIn(
        CharacterRange(first: NestedNamespacedClass.NestedConstPlus, last: NestedNamespacedClass.NestedConstMinus),
        NestedNamespacedClass.NestedConstL);

    [GenerateModex(nameof(ConstNotPlusToMinusOrLInNestedClassModex))]
    internal static partial string ConstNotPlusToMinusOrLInNestedClassPattern();

    private static Modex ConstNotPlusToMinusOrLInNestedClassModex => AnyCharacterNotIn(
        CharacterRange(first: NestedNamespacedClass.NestedConstPlus, last: NestedNamespacedClass.NestedConstMinus),
        NestedNamespacedClass.NestedConstL);

    [GenerateModex(nameof(ConstPlusToMinusOrLInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstPlusToMinusOrLInAnotherClassInSameNamespacePattern();

    private static Modex ConstPlusToMinusOrLInAnotherClassInSameNamespaceModex => AnyCharacterIn(
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstPlusInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstLInAnotherClass);

    [GenerateModex(nameof(ConstNotPlusToMinusOrLInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotPlusToMinusOrLInAnotherClassInSameNamespacePattern();

    private static Modex ConstNotPlusToMinusOrLInAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstPlusInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass),
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstLInAnotherClass);

    [GenerateModex(nameof(ConstPlusToMinusOrLInAnotherNamespaceModex))]
    internal static partial string ConstPlusToMinusOrLInAnotherNamespacePattern();

    private static Modex ConstPlusToMinusOrLInAnotherNamespaceModex => AnyCharacterIn(
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstPlusInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstLInAnotherNamespace);

    [GenerateModex(nameof(ConstNotPlusToMinusOrLInAnotherNamespaceModex))]
    internal static partial string ConstNotPlusToMinusOrLInAnotherNamespacePattern();

    private static Modex ConstNotPlusToMinusOrLInAnotherNamespaceModex => AnyCharacterNotIn(
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstPlusInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace),
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstLInAnotherNamespace);

    [GenerateModex(nameof(ConstPlusToMinusOrLInGlobalClassModex))]
    internal static partial string ConstPlusToMinusOrLInGlobalClassPattern();

    private static Modex ConstPlusToMinusOrLInGlobalClassModex => AnyCharacterIn(
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstPlusInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.ConstLInGlobalClass);

    [GenerateModex(nameof(ConstNotPlusToMinusOrLInGlobalClassModex))]
    internal static partial string ConstNotPlusToMinusOrLInGlobalClassPattern();

    private static Modex ConstNotPlusToMinusOrLInGlobalClassModex => AnyCharacterNotIn(
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstPlusInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass),
        BaseGlobalClass.NestedGlobalClass.ConstLInGlobalClass);

    [GenerateModex(nameof(LiteralTOrMinusTo0Modex))]
    internal static partial string LiteralTOrMinusTo0Pattern();

    private static Modex LiteralTOrMinusTo0Modex => AnyCharacterIn('T', CharacterRange(first: '-', last: '0'));

    [GenerateModex(nameof(LiteralNotTOrMinusTo0Modex))]
    internal static partial string LiteralNotTOrMinusTo0Pattern();

    private static Modex LiteralNotTOrMinusTo0Modex => AnyCharacterNotIn('T', CharacterRange(first: '-', last: '0'));

    [GenerateModex(nameof(ConstTOrMinusTo0Modex))]
    internal static partial string ConstTOrMinusTo0Pattern();

    private static Modex ConstTOrMinusTo0Modex
        => AnyCharacterIn(ConstT, CharacterRange(first: ConstMinus, last: Const0Character));

    [GenerateModex(nameof(ConstNotTOrMinusTo0Modex))]
    internal static partial string ConstNotTOrMinusTo0Pattern();

    private static Modex ConstNotTOrMinusTo0Modex
        => AnyCharacterNotIn(ConstT, CharacterRange(first: ConstMinus, last: Const0Character));

    [GenerateModex(nameof(ConstTOrMinusTo0InNestedClassModex))]
    internal static partial string ConstTOrMinusTo0InNestedClassPattern();

    private static Modex ConstTOrMinusTo0InNestedClassModex => AnyCharacterIn(
        NestedNamespacedClass.NestedConstT,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstMinus, last: NestedNamespacedClass.NestedConst0Character));

    [GenerateModex(nameof(ConstNotTOrMinusTo0InNestedClassModex))]
    internal static partial string ConstNotTOrMinusTo0InNestedClassPattern();

    private static Modex ConstNotTOrMinusTo0InNestedClassModex => AnyCharacterNotIn(
        NestedNamespacedClass.NestedConstT,
        CharacterRange(
            first: NestedNamespacedClass.NestedConstMinus, last: NestedNamespacedClass.NestedConst0Character));

    [GenerateModex(nameof(ConstTOrMinusTo0InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstTOrMinusTo0InAnotherClassInSameNamespacePattern();

    private static Modex ConstTOrMinusTo0InAnotherClassInSameNamespaceModex => AnyCharacterIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstTInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.Const0CharacterInAnotherClass));

    [GenerateModex(nameof(ConstNotTOrMinusTo0InAnotherClassInSameNamespaceModex))]
    internal static partial string ConstNotTOrMinusTo0InAnotherClassInSameNamespacePattern();

    private static Modex ConstNotTOrMinusTo0InAnotherClassInSameNamespaceModex => AnyCharacterNotIn(
        SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstTInAnotherClass,
        CharacterRange(
            first: SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMinusInAnotherClass,
            last: SomeOtherClassInTheSameNamespace.SomeNestedClass.Const0CharacterInAnotherClass));

    [GenerateModex(nameof(ConstTOrMinusTo0InAnotherNamespaceModex))]
    internal static partial string ConstTOrMinusTo0InAnotherNamespacePattern();

    private static Modex ConstTOrMinusTo0InAnotherNamespaceModex => AnyCharacterIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstTInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const0CharacterInAnotherNamespace));

    [GenerateModex(nameof(ConstNotTOrMinusTo0InAnotherNamespaceModex))]
    internal static partial string ConstNotTOrMinusTo0InAnotherNamespacePattern();

    private static Modex ConstNotTOrMinusTo0InAnotherNamespaceModex => AnyCharacterNotIn(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstTInAnotherNamespace,
        CharacterRange(
            first: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMinusInAnotherNamespace,
            last: Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const0CharacterInAnotherNamespace));

    [GenerateModex(nameof(ConstTOrMinusTo0InGlobalClassModex))]
    internal static partial string ConstTOrMinusTo0InGlobalClassPattern();

    private static Modex ConstTOrMinusTo0InGlobalClassModex => AnyCharacterIn(
        BaseGlobalClass.NestedGlobalClass.ConstTInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.Const0CharacterInGlobalClass));

    [GenerateModex(nameof(ConstNotTOrMinusTo0InGlobalClassModex))]
    internal static partial string ConstNotTOrMinusTo0InGlobalClassPattern();

    private static Modex ConstNotTOrMinusTo0InGlobalClassModex => AnyCharacterNotIn(
        BaseGlobalClass.NestedGlobalClass.ConstTInGlobalClass,
        CharacterRange(
            first: BaseGlobalClass.NestedGlobalClass.ConstMinusInGlobalClass,
            last: BaseGlobalClass.NestedGlobalClass.Const0CharacterInGlobalClass));


    [GenerateModex(nameof(Literal3DirectWordCharactersModex))]
    internal static partial string Literal3DirectWordCharactersPattern();

    private static Modex Literal3DirectWordCharactersModex => WordCharacter.Times(3);

    [GenerateModex(nameof(Literal3IndirectWordCharactersModex))]
    internal static partial string Literal3IndirectWordCharactersPattern();

    private static Modex Literal3IndirectWordCharactersModex => WordCharacterModex.Times(3);

    [GenerateModex(nameof(Const3DirectWordCharactersModex))]
    internal static partial string Const3DirectWordCharactersPattern();

    private static Modex Const3DirectWordCharactersModex => WordCharacter.Times(Const3);

    [GenerateModex(nameof(Const3IndirectWordCharactersModex))]
    internal static partial string Const3IndirectWordCharactersPattern();

    private static Modex Const3IndirectWordCharactersModex => WordCharacterModex.Times(Const3);

    [GenerateModex(nameof(Const3DirectWordCharactersInNestedClassModex))]
    internal static partial string Const3DirectWordCharactersInNestedClassPattern();

    private static Modex Const3DirectWordCharactersInNestedClassModex
        => WordCharacter.Times(NestedNamespacedClass.NestedConst3);

    [GenerateModex(nameof(Const3IndirectWordCharactersInNestedClassModex))]
    internal static partial string Const3IndirectWordCharactersInNestedClassPattern();

    private static Modex Const3IndirectWordCharactersInNestedClassModex
        => WordCharacterModex.Times(NestedNamespacedClass.NestedConst3);

    [GenerateModex(nameof(Const3DirectWordCharactersInAnotherClassInSameNamespaceModex))]
    internal static partial string Const3DirectWordCharactersInAnotherClassInSameNamespacePattern();

    private static Modex Const3DirectWordCharactersInAnotherClassInSameNamespaceModex
        => WordCharacter.Times(SomeOtherClassInTheSameNamespace.SomeNestedClass.Const3InAnotherClass);

    [GenerateModex(nameof(Const3IndirectWordCharactersInAnotherClassInSameNamespaceModex))]
    internal static partial string Const3IndirectWordCharactersInAnotherClassInSameNamespacePattern();

    private static Modex Const3IndirectWordCharactersInAnotherClassInSameNamespaceModex
        => WordCharacterModex.Times(SomeOtherClassInTheSameNamespace.SomeNestedClass.Const3InAnotherClass);

    [GenerateModex(nameof(Const3DirectWordCharactersInAnotherNamespaceModex))]
    internal static partial string Const3DirectWordCharactersInAnotherNamespacePattern();

    private static Modex Const3DirectWordCharactersInAnotherNamespaceModex => WordCharacter.Times(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const3InAnotherNamespace);

    [GenerateModex(nameof(Const3IndirectWordCharactersInAnotherNamespaceModex))]
    internal static partial string Const3IndirectWordCharactersInAnotherNamespacePattern();

    private static Modex Const3IndirectWordCharactersInAnotherNamespaceModex => WordCharacterModex.Times(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const3InAnotherNamespace);

    [GenerateModex(nameof(Const3DirectWordCharactersInGlobalClassModex))]
    internal static partial string Const3DirectWordCharactersInGlobalClassPattern();

    private static Modex Const3DirectWordCharactersInGlobalClassModex
        => WordCharacter.Times(BaseGlobalClass.NestedGlobalClass.Const3InGlobalClass);

    [GenerateModex(nameof(Const3IndirectWordCharactersInGlobalClassModex))]
    internal static partial string Const3IndirectWordCharactersInGlobalClassPattern();

    private static Modex Const3IndirectWordCharactersInGlobalClassModex
        => WordCharacterModex.Times(BaseGlobalClass.NestedGlobalClass.Const3InGlobalClass);

    internal static Modex WordCharacterModex => WordCharacter;


    [GenerateModex(nameof(Literal3OrMoreDirectNonDigitsModex))]
    internal static partial string Literal3OrMoreDirectNonDigitsPattern();

    private static Modex Literal3OrMoreDirectNonDigitsModex => NonDigit.TimesAtLeast(3);

    [GenerateModex(nameof(Literal3OrMoreIndirectNonDigitsModex))]
    internal static partial string Literal3OrMoreIndirectNonDigitsPattern();

    private static Modex Literal3OrMoreIndirectNonDigitsModex => NonDigitModex.TimesAtLeast(3);

    [GenerateModex(nameof(Const3OrMoreDirectNonDigitsModex))]
    internal static partial string Const3OrMoreDirectNonDigitsPattern();

    private static Modex Const3OrMoreDirectNonDigitsModex => NonDigit.TimesAtLeast(Const3);

    [GenerateModex(nameof(Const3OrMoreIndirectNonDigitsModex))]
    internal static partial string Const3OrMoreIndirectNonDigitsPattern();

    private static Modex Const3OrMoreIndirectNonDigitsModex => NonDigitModex.TimesAtLeast(Const3);

    [GenerateModex(nameof(Const3OrMoreDirectNonDigitsInNestedClassModex))]
    internal static partial string Const3OrMoreDirectNonDigitsInNestedClassPattern();

    private static Modex Const3OrMoreDirectNonDigitsInNestedClassModex
        => NonDigit.TimesAtLeast(NestedNamespacedClass.NestedConst3);

    [GenerateModex(nameof(Const3OrMoreIndirectNonDigitsInNestedClassModex))]
    internal static partial string Const3OrMoreIndirectNonDigitsInNestedClassPattern();

    private static Modex Const3OrMoreIndirectNonDigitsInNestedClassModex
        => NonDigitModex.TimesAtLeast(NestedNamespacedClass.NestedConst3);

    [GenerateModex(nameof(Const3OrMoreDirectNonDigitsInAnotherClassInSameNamespaceModex))]
    internal static partial string Const3OrMoreDirectNonDigitsInAnotherClassInSameNamespacePattern();

    private static Modex Const3OrMoreDirectNonDigitsInAnotherClassInSameNamespaceModex
        => NonDigit.TimesAtLeast(SomeOtherClassInTheSameNamespace.SomeNestedClass.Const3InAnotherClass);

    [GenerateModex(nameof(Const3OrMoreIndirectNonDigitsInAnotherClassInSameNamespaceModex))]
    internal static partial string Const3OrMoreIndirectNonDigitsInAnotherClassInSameNamespacePattern();

    private static Modex Const3OrMoreIndirectNonDigitsInAnotherClassInSameNamespaceModex
        => NonDigitModex.TimesAtLeast(SomeOtherClassInTheSameNamespace.SomeNestedClass.Const3InAnotherClass);

    [GenerateModex(nameof(Const3OrMoreDirectNonDigitsInAnotherNamespaceModex))]
    internal static partial string Const3OrMoreDirectNonDigitsInAnotherNamespacePattern();

    private static Modex Const3OrMoreDirectNonDigitsInAnotherNamespaceModex
        => NonDigit.TimesAtLeast(Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const3InAnotherNamespace);

    [GenerateModex(nameof(Const3OrMoreIndirectNonDigitsInAnotherNamespaceModex))]
    internal static partial string Const3OrMoreIndirectNonDigitsInAnotherNamespacePattern();

    private static Modex Const3OrMoreIndirectNonDigitsInAnotherNamespaceModex
        => NonDigitModex.TimesAtLeast(Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const3InAnotherNamespace);

    [GenerateModex(nameof(Const3OrMoreDirectNonDigitsInGlobalClassModex))]
    internal static partial string Const3OrMoreDirectNonDigitsInGlobalClassPattern();

    private static Modex Const3OrMoreDirectNonDigitsInGlobalClassModex
        => NonDigit.TimesAtLeast(BaseGlobalClass.NestedGlobalClass.Const3InGlobalClass);

    [GenerateModex(nameof(Const3OrMoreIndirectNonDigitsInGlobalClassModex))]
    internal static partial string Const3OrMoreIndirectNonDigitsInGlobalClassPattern();

    private static Modex Const3OrMoreIndirectNonDigitsInGlobalClassModex
        => NonDigitModex.TimesAtLeast(BaseGlobalClass.NestedGlobalClass.Const3InGlobalClass);

    internal static Modex NonDigitModex => NonDigit;

    [GenerateModex(nameof(Literal3To5DirectNonWordCharactersModex))]
    internal static partial string Literal3To5DirectNonWordCharactersPattern();

    private static Modex Literal3To5DirectNonWordCharactersModex => NonWordCharacter.TimesBetween(3, 5);

    [GenerateModex(nameof(Literal3To5IndirectNonWordCharactersModex))]
    internal static partial string Literal3To5IndirectNonWordCharactersPattern();

    private static Modex Literal3To5IndirectNonWordCharactersModex => NonWordCharacterModex.TimesBetween(3, 5);

    [GenerateModex(nameof(Const3To5DirectNonWordCharactersModex))]
    internal static partial string Const3To5DirectNonWordCharactersPattern();

    private static Modex Const3To5DirectNonWordCharactersModex => NonWordCharacter.TimesBetween(Const3, Const5);

    [GenerateModex(nameof(Const3To5IndirectNonWordCharactersModex))]
    internal static partial string Const3To5IndirectNonWordCharactersPattern();

    private static Modex Const3To5IndirectNonWordCharactersModex => NonWordCharacterModex.TimesBetween(Const3, Const5);

    [GenerateModex(nameof(Const3To5DirectNonWordCharactersInNestedClassModex))]
    internal static partial string Const3To5DirectNonWordCharactersInNestedClassPattern();

    private static Modex Const3To5DirectNonWordCharactersInNestedClassModex
        => NonWordCharacter.TimesBetween(NestedNamespacedClass.NestedConst3, NestedNamespacedClass.NestedConst5);

    [GenerateModex(nameof(Const3To5IndirectNonWordCharactersInNestedClassModex))]
    internal static partial string Const3To5IndirectNonWordCharactersInNestedClassPattern();

    private static Modex Const3To5IndirectNonWordCharactersInNestedClassModex
        => NonWordCharacterModex.TimesBetween(NestedNamespacedClass.NestedConst3, NestedNamespacedClass.NestedConst5);

    [GenerateModex(nameof(Const3To5DirectNonWordCharactersInAnotherClassInSameNamespaceModex))]
    internal static partial string Const3To5DirectNonWordCharactersInAnotherClassInSameNamespacePattern();

    private static Modex Const3To5DirectNonWordCharactersInAnotherClassInSameNamespaceModex
        => NonWordCharacter.TimesBetween(
            SomeOtherClassInTheSameNamespace.SomeNestedClass.Const3InAnotherClass,
            SomeOtherClassInTheSameNamespace.SomeNestedClass.Const5InAnotherClass);

    [GenerateModex(nameof(Const3To5IndirectNonWordCharactersInAnotherClassInSameNamespaceModex))]
    internal static partial string Const3To5IndirectNonWordCharactersInAnotherClassInSameNamespacePattern();

    private static Modex Const3To5IndirectNonWordCharactersInAnotherClassInSameNamespaceModex
        => NonWordCharacterModex.TimesBetween(
            SomeOtherClassInTheSameNamespace.SomeNestedClass.Const3InAnotherClass,
            SomeOtherClassInTheSameNamespace.SomeNestedClass.Const5InAnotherClass);

    [GenerateModex(nameof(Const3To5DirectNonWordCharactersInAnotherNamespaceModex))]
    internal static partial string Const3To5DirectNonWordCharactersInAnotherNamespacePattern();

    private static Modex Const3To5DirectNonWordCharactersInAnotherNamespaceModex
        => NonWordCharacter.TimesBetween(
            Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const3InAnotherNamespace,
            Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.Const5InAnotherNamespace);

    [GenerateModex(nameof(Const3To5DirectNonWordCharactersInGlobalClassModex))]
    internal static partial string Const3To5DirectNonWordCharactersInGlobalClassPattern();

    private static Modex Const3To5DirectNonWordCharactersInGlobalClassModex
        => NonWordCharacter.TimesBetween(
            BaseGlobalClass.NestedGlobalClass.Const3InGlobalClass,
            BaseGlobalClass.NestedGlobalClass.Const5InGlobalClass);

    internal static Modex NonWordCharacterModex => NonWordCharacter;


    [GenerateModex(nameof(DirectDigitWithLiteralMyDigitNamedGroupModex))]
    internal static partial string DirectDigitWithLiteralMyDigitNamedGroupPattern();

    private static Modex DirectDigitWithLiteralMyDigitNamedGroupModex => NamedGroup("myDigitGroup", Digit);

    [GenerateModex(nameof(IndirectDigitWithLiteralMyDigitNamedGroupModex))]
    internal static partial string IndirectDigitWithLiteralMyDigitNamedGroupPattern();

    private static Modex IndirectDigitWithLiteralMyDigitNamedGroupModex => NamedGroup("myDigitGroup", DigitModex);

    [GenerateModex(nameof(DirectDigitWithConstMyDigitNamedGroupModex))]
    internal static partial string DirectDigitWithConstMyDigitNamedGroupPattern();

    private static Modex DirectDigitWithConstMyDigitNamedGroupModex => NamedGroup(ConstMyDigitGroup, Digit);

    [GenerateModex(nameof(IndirectDigitWithConstMyDigitNamedGroupModex))]
    internal static partial string IndirectDigitWithConstMyDigitNamedGroupPattern();

    private static Modex IndirectDigitWithConstMyDigitNamedGroupModex => NamedGroup(ConstMyDigitGroup, DigitModex);

    [GenerateModex(nameof(DirectDigitWithConstMyDigitNamedGroupInNestedClassModex))]
    internal static partial string DirectDigitWithConstMyDigitNamedGroupInNestedClassPattern();

    private static Modex DirectDigitWithConstMyDigitNamedGroupInNestedClassModex
        => NamedGroup(NestedNamespacedClass.NestedConstMyDigitGroup, Digit);

    [GenerateModex(nameof(IndirectDigitWithConstMyDigitNamedGroupInNestedClassModex))]
    internal static partial string IndirectDigitWithConstMyDigitNamedGroupInNestedClassPattern();

    private static Modex IndirectDigitWithConstMyDigitNamedGroupInNestedClassModex
        => NamedGroup(NestedNamespacedClass.NestedConstMyDigitGroup, DigitModex);

    [GenerateModex(nameof(DirectDigitWithConstMyDigitNamedGroupInAnotherClassInSameNamespaceModex))]
    internal static partial string DirectDigitWithConstMyDigitNamedGroupInAnotherClassInSameNamespacePattern();

    private static Modex DirectDigitWithConstMyDigitNamedGroupInAnotherClassInSameNamespaceModex
        => NamedGroup(SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMyDigitGroupInAnotherClass, Digit);

    [GenerateModex(nameof(IndirectDigitWithConstMyDigitNamedGroupInAnotherClassInSameNamespaceModex))]
    internal static partial string IndirectDigitWithConstMyDigitNamedGroupInAnotherClassInSameNamespacePattern();

    private static Modex IndirectDigitWithConstMyDigitNamedGroupInAnotherClassInSameNamespaceModex
        => NamedGroup(SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstMyDigitGroupInAnotherClass, DigitModex);

    [GenerateModex(nameof(DirectDigitWithConstMyDigitNamedGroupInAnotherNamespaceModex))]
    internal static partial string DirectDigitWithConstMyDigitNamedGroupInAnotherNamespacePattern();

    private static Modex DirectDigitWithConstMyDigitNamedGroupInAnotherNamespaceModex => NamedGroup(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMyDigitGroupInAnotherNamespace,
        Digit);

    [GenerateModex(nameof(IndirectDigitWithConstMyDigitNamedGroupInAnotherNamespaceModex))]
    internal static partial string IndirectDigitWithConstMyDigitNamedGroupInAnotherNamespacePattern();

    private static Modex IndirectDigitWithConstMyDigitNamedGroupInAnotherNamespaceModex => NamedGroup(
        Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstMyDigitGroupInAnotherNamespace,
        DigitModex);

    [GenerateModex(nameof(DirectDigitWithConstMyDigitNamedGroupInGlobalClassModex))]
    internal static partial string DirectDigitWithConstMyDigitNamedGroupInGlobalClassPattern();

    private static Modex DirectDigitWithConstMyDigitNamedGroupInGlobalClassModex
        => NamedGroup(BaseGlobalClass.NestedGlobalClass.ConstMyDigitGroupInGlobalClass, Digit);

    [GenerateModex(nameof(IndirectDigitWithConstMyDigitNamedGroupInGlobalClassModex))]
    internal static partial string IndirectDigitWithConstMyDigitNamedGroupInGlobalClassPattern();

    private static Modex IndirectDigitWithConstMyDigitNamedGroupInGlobalClassModex
        => NamedGroup(BaseGlobalClass.NestedGlobalClass.ConstMyDigitGroupInGlobalClass, DigitModex);

    internal static Modex DigitModex => Digit;


    [GenerateModex(nameof(LiteralADotBModex))]
    internal static partial string LiteralADotBPattern();

    private static Modex LiteralADotBModex => "A.B";

    [GenerateModex(nameof(ConstADotBModex))]
    internal static partial string ConstADotBPattern();

    private static Modex ConstADotBModex => ConstADotB;

    [GenerateModex(nameof(ConstADotBInNestedClassModex))]
    internal static partial string ConstADotBInNestedClassPattern();

    private static Modex ConstADotBInNestedClassModex => NestedNamespacedClass.NestedConstADotB;

    [GenerateModex(nameof(ConstADotBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstADotBInAnotherClassInSameNamespacePattern();

    private static Modex ConstADotBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstADotBInAnotherClass;

    [GenerateModex(nameof(ConstADotBInAnotherNamespaceModex))]
    internal static partial string ConstADotBInAnotherNamespacePattern();

    private static Modex ConstADotBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstADotBInAnotherNamespace;

    [GenerateModex(nameof(ConstADotBInGlobalClassModex))]
    internal static partial string ConstADotBInGlobalClassPattern();

    private static Modex ConstADotBInGlobalClassModex => BaseGlobalClass.NestedGlobalClass.ConstADotBInGlobalClass;

    [GenerateModex(nameof(LiteralAPlusBModex))]
    internal static partial string LiteralAPlusBPattern();

    private static Modex LiteralAPlusBModex => "A+B";

    [GenerateModex(nameof(ConstAPlusBModex))]
    internal static partial string ConstAPlusBPattern();

    private static Modex ConstAPlusBModex => ConstAPlusB;

    [GenerateModex(nameof(ConstAPlusBInNestedClassModex))]
    internal static partial string ConstAPlusBInNestedClassPattern();

    private static Modex ConstAPlusBInNestedClassModex => NestedNamespacedClass.NestedConstAPlusB;

    [GenerateModex(nameof(ConstAPlusBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstAPlusBInAnotherClassInSameNamespacePattern();

    private static Modex ConstAPlusBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstAPlusBInAnotherClass;

    [GenerateModex(nameof(ConstAPlusBInAnotherNamespaceModex))]
    internal static partial string ConstAPlusBInAnotherNamespacePattern();

    private static Modex ConstAPlusBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstAPlusBInAnotherNamespace;

    [GenerateModex(nameof(ConstAPlusBInGlobalClassModex))]
    internal static partial string ConstAPlusBInGlobalClassPattern();

    private static Modex ConstAPlusBInGlobalClassModex => BaseGlobalClass.NestedGlobalClass.ConstAPlusBInGlobalClass;

    [GenerateModex(nameof(LiteralAAsteriskBModex))]
    internal static partial string LiteralAAsteriskBPattern();

    private static Modex LiteralAAsteriskBModex => "A*B";

    [GenerateModex(nameof(ConstAAsteriskBModex))]
    internal static partial string ConstAAsteriskBPattern();

    private static Modex ConstAAsteriskBModex => ConstAAsteriskB;

    [GenerateModex(nameof(ConstAAsteriskBInNestedClassModex))]
    internal static partial string ConstAAsteriskBInNestedClassPattern();

    private static Modex ConstAAsteriskBInNestedClassModex => NestedNamespacedClass.NestedConstAAsteriskB;

    [GenerateModex(nameof(ConstAAsteriskBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstAAsteriskBInAnotherClassInSameNamespacePattern();

    private static Modex ConstAAsteriskBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstAAsteriskBInAnotherClass;

    [GenerateModex(nameof(ConstAAsteriskBInAnotherNamespaceModex))]
    internal static partial string ConstAAsteriskBInAnotherNamespacePattern();

    private static Modex ConstAAsteriskBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstAAsteriskBInAnotherNamespace;

    [GenerateModex(nameof(ConstAAsteriskBInGlobalClassModex))]
    internal static partial string ConstAAsteriskBInGlobalClassPattern();

    private static Modex ConstAAsteriskBInGlobalClassModex => BaseGlobalClass.NestedGlobalClass.ConstAAsteriskBInGlobalClass;

    [GenerateModex(nameof(LiteralAQuestionMarkBModex))]
    internal static partial string LiteralAQuestionMarkBPattern();

    private static Modex LiteralAQuestionMarkBModex => "A?B";

    [GenerateModex(nameof(ConstAQuestionMarkBModex))]
    internal static partial string ConstAQuestionMarkBPattern();

    private static Modex ConstAQuestionMarkBModex => ConstAQuestionMarkB;

    [GenerateModex(nameof(ConstAQuestionMarkBInNestedClassModex))]
    internal static partial string ConstAQuestionMarkBInNestedClassPattern();

    private static Modex ConstAQuestionMarkBInNestedClassModex => NestedNamespacedClass.NestedConstAQuestionMarkB;

    [GenerateModex(nameof(ConstAQuestionMarkBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstAQuestionMarkBInAnotherClassInSameNamespacePattern();

    private static Modex ConstAQuestionMarkBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstAQuestionMarkBInAnotherClass;

    [GenerateModex(nameof(ConstAQuestionMarkBInAnotherNamespaceModex))]
    internal static partial string ConstAQuestionMarkBInAnotherNamespacePattern();

    private static Modex ConstAQuestionMarkBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstAQuestionMarkBInAnotherNamespace;

    [GenerateModex(nameof(ConstAQuestionMarkBInGlobalClassModex))]
    internal static partial string ConstAQuestionMarkBInGlobalClassPattern();

    private static Modex ConstAQuestionMarkBInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstAQuestionMarkBInGlobalClass;

    [GenerateModex(nameof(LiteralCaretAModex))]
    internal static partial string LiteralCaretAPattern();

    private static Modex LiteralCaretAModex => "^a";

    [GenerateModex(nameof(ConstCaretAModex))]
    internal static partial string ConstCaretAPattern();

    private static Modex ConstCaretAModex => ConstCaretA;

    [GenerateModex(nameof(ConstCaretAInNestedClassModex))]
    internal static partial string ConstCaretAInNestedClassPattern();

    private static Modex ConstCaretAInNestedClassModex => NestedNamespacedClass.NestedConstCaretA;

    [GenerateModex(nameof(ConstCaretAInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstCaretAInAnotherClassInSameNamespacePattern();

    private static Modex ConstCaretAInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstCaretAInAnotherClass;

    [GenerateModex(nameof(ConstCaretAInAnotherNamespaceModex))]
    internal static partial string ConstCaretAInAnotherNamespacePattern();

    private static Modex ConstCaretAInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstCaretAInAnotherNamespace;

    [GenerateModex(nameof(ConstCaretAInGlobalClassModex))]
    internal static partial string ConstCaretAInGlobalClassPattern();

    private static Modex ConstCaretAInGlobalClassModex => BaseGlobalClass.NestedGlobalClass.ConstCaretAInGlobalClass;

    [GenerateModex(nameof(LiteralUnderscoreDollarModex))]
    internal static partial string LiteralUnderscoreDollarPattern();

    private static Modex LiteralUnderscoreDollarModex => "_$";

    [GenerateModex(nameof(ConstUnderscoreDollarModex))]
    internal static partial string ConstUnderscoreDollarPattern();

    private static Modex ConstUnderscoreDollarModex => ConstUnderscoreDollar;

    [GenerateModex(nameof(ConstUnderscoreDollarInNestedClassModex))]
    internal static partial string ConstUnderscoreDollarInNestedClassPattern();

    private static Modex ConstUnderscoreDollarInNestedClassModex => NestedNamespacedClass.NestedConstUnderscoreDollar;

    [GenerateModex(nameof(ConstUnderscoreDollarInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstUnderscoreDollarInAnotherClassInSameNamespacePattern();

    private static Modex ConstUnderscoreDollarInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstUnderscoreDollarInAnotherClass;

    [GenerateModex(nameof(ConstUnderscoreDollarInAnotherNamespaceModex))]
    internal static partial string ConstUnderscoreDollarInAnotherNamespacePattern();

    private static Modex ConstUnderscoreDollarInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstUnderscoreDollarInAnotherNamespace;

    [GenerateModex(nameof(ConstUnderscoreDollarInGlobalClassModex))]
    internal static partial string ConstUnderscoreDollarInGlobalClassPattern();

    private static Modex ConstUnderscoreDollarInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstUnderscoreDollarInGlobalClass;

    [GenerateModex(nameof(LiteralALeftParenthesisBModex))]
    internal static partial string LiteralALeftParenthesisBPattern();

    private static Modex LiteralALeftParenthesisBModex => "A(B";

    [GenerateModex(nameof(ConstALeftParenthesisBModex))]
    internal static partial string ConstALeftParenthesisBPattern();

    private static Modex ConstALeftParenthesisBModex => ConstALeftParenthesisB;

    [GenerateModex(nameof(ConstALeftParenthesisBInNestedClassModex))]
    internal static partial string ConstALeftParenthesisBInNestedClassPattern();

    private static Modex ConstALeftParenthesisBInNestedClassModex => NestedNamespacedClass.NestedConstALeftParenthesisB;

    [GenerateModex(nameof(ConstALeftParenthesisBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstALeftParenthesisBInAnotherClassInSameNamespacePattern();

    private static Modex ConstALeftParenthesisBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstALeftParenthesisBInAnotherClass;

    [GenerateModex(nameof(ConstALeftParenthesisBInAnotherNamespaceModex))]
    internal static partial string ConstALeftParenthesisBInAnotherNamespacePattern();

    private static Modex ConstALeftParenthesisBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstALeftParenthesisBInAnotherNamespace;

    [GenerateModex(nameof(ConstALeftParenthesisBInGlobalClassModex))]
    internal static partial string ConstALeftParenthesisBInGlobalClassPattern();

    private static Modex ConstALeftParenthesisBInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstALeftParenthesisBInGlobalClass;

    [GenerateModex(nameof(LiteralARightParenthesisBModex))]
    internal static partial string LiteralARightParenthesisBPattern();

    private static Modex LiteralARightParenthesisBModex => "A)B";

    [GenerateModex(nameof(ConstARightParenthesisBModex))]
    internal static partial string ConstARightParenthesisBPattern();

    private static Modex ConstARightParenthesisBModex => ConstARightParenthesisB;

    [GenerateModex(nameof(ConstARightParenthesisBInNestedClassModex))]
    internal static partial string ConstARightParenthesisBInNestedClassPattern();

    private static Modex ConstARightParenthesisBInNestedClassModex
        => NestedNamespacedClass.NestedConstARightParenthesisB;

    [GenerateModex(nameof(ConstARightParenthesisBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstARightParenthesisBInAnotherClassInSameNamespacePattern();

    private static Modex ConstARightParenthesisBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstARightParenthesisBInAnotherClass;

    [GenerateModex(nameof(ConstARightParenthesisBInAnotherNamespaceModex))]
    internal static partial string ConstARightParenthesisBInAnotherNamespacePattern();

    private static Modex ConstARightParenthesisBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstARightParenthesisBInAnotherNamespace;

    [GenerateModex(nameof(ConstARightParenthesisBInGlobalClassModex))]
    internal static partial string ConstARightParenthesisBInGlobalClassPattern();

    private static Modex ConstARightParenthesisBInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstARightParenthesisBInGlobalClass;

    [GenerateModex(nameof(LiteralALeftBracketBModex))]
    internal static partial string LiteralALeftBracketBPattern();

    private static Modex LiteralALeftBracketBModex => "A[B";

    [GenerateModex(nameof(ConstALeftBracketBModex))]
    internal static partial string ConstALeftBracketBPattern();

    private static Modex ConstALeftBracketBModex => ConstALeftBracketB;

    [GenerateModex(nameof(ConstALeftBracketBInNestedClassModex))]
    internal static partial string ConstALeftBracketBInNestedClassPattern();

    private static Modex ConstALeftBracketBInNestedClassModex => NestedNamespacedClass.NestedConstALeftBracketB;

    [GenerateModex(nameof(ConstALeftBracketBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstALeftBracketBInAnotherClassInSameNamespacePattern();

    private static Modex ConstALeftBracketBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstALeftBracketBInAnotherClass;

    [GenerateModex(nameof(ConstALeftBracketBInAnotherNamespaceModex))]
    internal static partial string ConstALeftBracketBInAnotherNamespacePattern();

    private static Modex ConstALeftBracketBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstALeftBracketBInAnotherNamespace;

    [GenerateModex(nameof(ConstALeftBracketBInGlobalClassModex))]
    internal static partial string ConstALeftBracketBInGlobalClassPattern();

    private static Modex ConstALeftBracketBInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstALeftBracketBInGlobalClass;

    [GenerateModex(nameof(LiteralARightBracketBModex))]
    internal static partial string LiteralARightBracketBPattern();

    private static Modex LiteralARightBracketBModex => "A]B";

    [GenerateModex(nameof(ConstARightBracketBModex))]
    internal static partial string ConstARightBracketBPattern();

    private static Modex ConstARightBracketBModex => ConstARightBracketB;

    [GenerateModex(nameof(ConstARightBracketBInNestedClassModex))]
    internal static partial string ConstARightBracketBInNestedClassPattern();

    private static Modex ConstARightBracketBInNestedClassModex => NestedNamespacedClass.NestedConstARightBracketB;

    [GenerateModex(nameof(ConstARightBracketBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstARightBracketBInAnotherClassInSameNamespacePattern();

    private static Modex ConstARightBracketBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstARightBracketBInAnotherClass;

    [GenerateModex(nameof(ConstARightBracketBInAnotherNamespaceModex))]
    internal static partial string ConstARightBracketBInAnotherNamespacePattern();

    private static Modex ConstARightBracketBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstARightBracketBInAnotherNamespace;

    [GenerateModex(nameof(ConstARightBracketBInGlobalClassModex))]
    internal static partial string ConstARightBracketBInGlobalClassPattern();

    private static Modex ConstARightBracketBInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstARightBracketBInGlobalClass;

    [GenerateModex(nameof(LiteralALeftBraceBModex))]
    internal static partial string LiteralALeftBraceBPattern();

    private static Modex LiteralALeftBraceBModex => "A{B";

    [GenerateModex(nameof(ConstALeftBraceBModex))]
    internal static partial string ConstALeftBraceBPattern();

    private static Modex ConstALeftBraceBModex => ConstALeftBraceB;

    [GenerateModex(nameof(ConstALeftBraceBInNestedClassModex))]
    internal static partial string ConstALeftBraceBInNestedClassPattern();

    private static Modex ConstALeftBraceBInNestedClassModex => NestedNamespacedClass.NestedConstALeftBraceB;

    [GenerateModex(nameof(ConstALeftBraceBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstALeftBraceBInAnotherClassInSameNamespacePattern();

    private static Modex ConstALeftBraceBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstALeftBraceBInAnotherClass;

    [GenerateModex(nameof(ConstALeftBraceBInAnotherNamespaceModex))]
    internal static partial string ConstALeftBraceBInAnotherNamespacePattern();

    private static Modex ConstALeftBraceBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstALeftBraceBInAnotherNamespace;

    [GenerateModex(nameof(ConstALeftBraceBInGlobalClassModex))]
    internal static partial string ConstALeftBraceBInGlobalClassPattern();

    private static Modex ConstALeftBraceBInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstALeftBraceBInGlobalClass;

    [GenerateModex(nameof(LiteralARightBraceBModex))]
    internal static partial string LiteralARightBraceBPattern();

    private static Modex LiteralARightBraceBModex => "A}B";

    [GenerateModex(nameof(ConstARightBraceBModex))]
    internal static partial string ConstARightBraceBPattern();

    private static Modex ConstARightBraceBModex => ConstARightBraceB;

    [GenerateModex(nameof(ConstARightBraceBInNestedClassModex))]
    internal static partial string ConstARightBraceBInNestedClassPattern();

    private static Modex ConstARightBraceBInNestedClassModex => NestedNamespacedClass.NestedConstARightBraceB;

    [GenerateModex(nameof(ConstARightBraceBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstARightBraceBInAnotherClassInSameNamespacePattern();

    private static Modex ConstARightBraceBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstARightBraceBInAnotherClass;

    [GenerateModex(nameof(ConstARightBraceBInAnotherNamespaceModex))]
    internal static partial string ConstARightBraceBInAnotherNamespacePattern();

    private static Modex ConstARightBraceBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstARightBraceBInAnotherNamespace;

    [GenerateModex(nameof(ConstARightBraceBInGlobalClassModex))]
    internal static partial string ConstARightBraceBInGlobalClassPattern();

    private static Modex ConstARightBraceBInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstARightBraceBInGlobalClass;

    [GenerateModex(nameof(LiteralAVerticalBarBModex))]
    internal static partial string LiteralAVerticalBarBPattern();

    private static Modex LiteralAVerticalBarBModex => "A|B";

    [GenerateModex(nameof(ConstAVerticalBarBModex))]
    internal static partial string ConstAVerticalBarBPattern();

    private static Modex ConstAVerticalBarBModex => ConstAVerticalBarB;

    [GenerateModex(nameof(ConstAVerticalBarBInNestedClassModex))]
    internal static partial string ConstAVerticalBarBInNestedClassPattern();

    private static Modex ConstAVerticalBarBInNestedClassModex => NestedNamespacedClass.NestedConstAVerticalBarB;

    [GenerateModex(nameof(ConstAVerticalBarBInAnotherClassInSameNamespaceModex))]
    internal static partial string ConstAVerticalBarBInAnotherClassInSameNamespacePattern();

    private static Modex ConstAVerticalBarBInAnotherClassInSameNamespaceModex
        => SomeOtherClassInTheSameNamespace.SomeNestedClass.ConstAVerticalBarBInAnotherClass;

    [GenerateModex(nameof(ConstAVerticalBarBInAnotherNamespaceModex))]
    internal static partial string ConstAVerticalBarBInAnotherNamespacePattern();

    private static Modex ConstAVerticalBarBInAnotherNamespaceModex
        => Some.Other.NamespaceName.SomeClassInAnotherNamespace.SomeNestedClass.ConstAVerticalBarBInAnotherNamespace;

    [GenerateModex(nameof(ConstAVerticalBarBInGlobalClassModex))]
    internal static partial string ConstAVerticalBarBInGlobalClassPattern();

    private static Modex ConstAVerticalBarBInGlobalClassModex
        => BaseGlobalClass.NestedGlobalClass.ConstAVerticalBarBInGlobalClass;


    internal static char LastChar = '@';

    internal sealed partial class NestedNamespacedClass
    {
        internal const char NestedConstCaret = '^';
        internal const char NestedConstW = 'W';
        internal const char NestedConst5Character = '5';
        internal const char NestedConst8Character = '8';
        internal const char NestedConstBackslash = '\\';
        internal const char NestedConstD = 'D';
        internal const char NestedConstP = 'P';
        internal const char NestedConstDoubleQuote = '"';
        internal const char NestedConst6Character = '6';
        internal const char NestedConst9Character = '9';
        internal const char NestedConstRightBracket = ']';
        internal const char NestedConstM = 'M';
        internal const char NestedConstMinus = '-';
        internal const char NestedConst4Character = '4';
        internal const char NestedConstJ = 'J';
        internal const char NestedConstC = 'C';
        internal const char NestedConst7Character = '7';
        internal const char NestedConst2Character = '2';
        internal const char NestedConstS = 'S';
        internal const char NestedConstBacktick = '`';
        internal const char NestedConstB = 'B';
        internal const char NestedConstZ = 'Z';
        internal const char NestedConstUnderscore = '_';
        internal const char NestedConst0Character = '0';
        internal const char NestedConstR = 'R';
        internal const char NestedConstY = 'Y';
        internal const char NestedConstDollar = '$';
        internal const char NestedConst1Character = '1';
        internal const char NestedConstE = 'E';
        internal const char NestedConstExclamationMark = '!';
        internal const char NestedConstSpace = ' ';
        internal const char NestedConstA = 'A';
        internal const char NestedConstH = 'H';
        internal const char NestedConstLeftBracket = '[';
        internal const char NestedConstPlus = '+';
        internal const char NestedConstL = 'L';
        internal const char NestedConstT = 'T';
        internal const char NestedConstSlash = '/';
        internal const int NestedConst3 = 3;
        internal const int NestedConst5 = 5;
        internal const string NestedConstMyDigitGroup = "myDigitGroup";
        internal const string NestedConstADotB = "A.B";
        internal const string NestedConstAPlusB = "A+B";
        internal const string NestedConstAAsteriskB = "A*B";
        internal const string NestedConstAQuestionMarkB = "A?B";
        internal const string NestedConstCaretA = "^a";
        internal const string NestedConstUnderscoreDollar = "_$";
        internal const string NestedConstALeftParenthesisB = "A(B";
        internal const string NestedConstARightParenthesisB = "A)B";
        internal const string NestedConstALeftBracketB = "A[B";
        internal const string NestedConstARightBracketB = "A]B";
        internal const string NestedConstALeftBraceB = "A{B";
        internal const string NestedConstARightBraceB = "A}B";
        internal const string NestedConstAVerticalBarB = "A|B";

        internal const char ConstH = 'H';
        internal const int Const90 = 90;
        internal static char CharField = '=';
        internal const char ConstMinus = '-';
        internal static int IntField = 25;
    }
}

internal partial class StaticallyUsedClass
{
    [GenerateModex(nameof(DigitInStaticallyUsedClassModex))]
    internal static partial string DigitInStaticallyUsedClassPattern();

    internal static Modex DigitInStaticallyUsedClassModex => Digit;
}
