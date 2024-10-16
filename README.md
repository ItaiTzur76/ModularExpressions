# ModularExpressions for C#
## Project Description
**ModularExpressions** is a Rosyln-powered generator for regular expressions from .NET syntax. With this **ModularExpressions** package, C# developers can create methods that return regular-expression patterns from basic C# modules and compile-time constants. It therefore allows developers to employ regular expressions using readable, maintainable C# code without having any familiarity with the Regex language.

The **ModularExpressions** package uses a Roslyn source-generator, so these regular-expression patterns are generated at compile-time.

## Install and Setup
To use Modular Expressions, include [the ModularExpressions NuGet package](https://www.NuGet.org/packages/ModularExpressions) in your C# project.

It is also recommended to add the following to the `.csproj` file of that project (see **Usage** for explanation):
```xml
<ItemGroup>
  <Using Include="ModularExpressions.Modex" Static="true" />
</ItemGroup>
```

## Usage
To create a Modular Expression, first create an arrow-property with `Modex` as its return-type in the class where you want the regular-expression pattern generated, and have it return the Modular Expression you want. (See **Modex Elements** below for a list of available elements.)

For example, to generate a pattern that matches any text that looks like a decimal number with digit grouping:
```csharp
private static Modex GroupedDecimalNumberModex => ZeroOrOneOf("-") + (Digit.TimesBetween(min: 1, max: 3) + ZeroOrMoreOf("," + Digit.Times(3)) + ZeroOrOneOf("." + ZeroOrMoreOf(Digit)) | "." + OneOrMoreOf(Digit));
```
Then, create a `partial` parameterless method declaration (i.e. without a body) that returns a `string`, and decorate it with the `GenerateModex` attribute, with the name of the `Modex` property as argument.

For the decimal-number example above, it would look like:
```csharp
[GenerateModex(nameof(GroupedDecimalNumberModex))]
public static partial string GroupedDecimalNumberPattern();

private static Modex GroupedDecimalNumberModex => ZeroOrOneOf("-") + (Digit.TimesBetween(min: 1, max: 3) + ZeroOrMoreOf("," + Digit.Times(3)) + ZeroOrOneOf("." + ZeroOrMoreOf(Digit)) | "." + OneOrMoreOf(Digit));
```
Of course, the containing class would then have to be declared `partial` as well. (A compilation error would occur if not.)

And that's it. Now, every time `GroupedDecimalNumberPattern()` is called, it returns the correct regular-expression pattern matching any text that looks like a decimal number with digit grouping.

*Note:* the `<Using Include="ModularExpressions.Modex" Static="true" />` element mentioned in the ***Install and Setup*** section above allows all those built-in Modex elements (`Digit`, `ZeroOrOneOf` and so on) to appear in the example above without any prefix. If that element is not added to the `.csproj` file as recommended, then every such built-in Modex element would have to be prefixed with its (`Modex`) class, making the example above look like:
```csharp
[GenerateModex(nameof(GroupedDecimalNumberModex))]
public static partial string GroupedDecimalNumberPattern();

private static Modex GroupedDecimalNumberModex => Modex.ZeroOrOneOf("-") + (Modex.Digit.TimesBetween(min: 1, max: 3) + Modex.ZeroOrMoreOf("," + Modex.Digit.Times(3)) + Modex.ZeroOrOneOf("." + Modex.ZeroOrMoreOf(Modex.Digit)) | "." + Modex.OneOrMoreOf(Modex.Digit));
```
The pattern is not understood immediately, so the extra verbosity might deteriorate readability.

### Modex XML-Documentation
A new `<modex />` element is supported in the XML documentation of the `string` method that returns the regular-expression pattern. This allows the developer to see the returned pattern without having to run or debug the code.

If the decimal-number example above is changed to:
```csharp
/// <summary>
/// Returns the pattern <b><modex /></b> that matches any text that looks like a decimal number with digit grouping.
/// </summary>
[GenerateModex(nameof(GroupedDecimalNumberModex))]
public static partial string GroupedDecimalNumberPattern();

private static Modex GroupedDecimalNumberModex => ZeroOrOneOf("-") + (Digit.TimesBetween(min: 1, max: 3) + ZeroOrMoreOf("," + Digit.Times(3)) + ZeroOrOneOf("." + ZeroOrMoreOf(Digit)) | "." + OneOrMoreOf(Digit));
```
then hovering the mouse over the `GroupedDecimalNumberPattern()` method (or starting to type-out its name) will show the following hint:
>Returns the pattern <b>"-?(\\\\d{1,3}(,\\\\d{3})*(\\\\.\\\\d*)?|\\\\.\\\\d+)"</b> that matches any text that looks like a decimal number with digit grouping.

This makes it clear that the developer has managed to generate an element of the Regex language with nothing more than what C# provides and, indeed, without even having to know the first thing about the Regex language.

### Modex References
One `Modex`-returning arrow-property can reference another. This can be done recursively (as long as there is no reference cycle) to reduce duplication and make the `Modex`-returning properties themselves more readable and manageable.

So the decimal-number example above can be rephrased more elegantly as:
```csharp
/// <summary>
/// Returns the pattern <b><modex /></b> that matches any text that looks like a decimal number with digit grouping.
/// </summary>
[GenerateModex(nameof(GroupedDecimalNumberModex))]
public static partial string GroupedDecimalNumberPattern();

private static Modex GroupedDecimalNumberModex => OptionalMinusModex + (DecimalNumberWithAWholePartModex | DecimalNumberWithoutAWholePartModex);

private static Modex OptionalMinusModex => ZeroOrOneOf("-");

private static Modex DecimalNumberWithAWholePartModex => OneToThreeDigitsModex + OptionalDigitGroupsModex + OptionalFractionPartModex;

private static Modex OneToThreeDigitsModex => Digit.TimesBetween(min: 1, max: 3);

private static Modex OptionalDigitGroupsModex => ZeroOrMoreOf(DigitGroupModex);

private static Modex DigitGroupModex => "," + ThreeDigitsModex;

private static Modex ThreeDigitsModex => Digit.Times(3);

private static Modex OptionalFractionPartModex => ZeroOrOneOf(DecimalNumberWithoutAWholePartModex);

private static Modex DecimalNumberWithoutAWholePartModex => "." + OneOrMoreDigitsModex;

private static Modex OneOrMoreDigitsModex => OneOrMoreOf(Digit);
```

### Modex Elements
The following list shows all elements available in the **ModularExpressions** package:
|Element                                        |Static                  |Example Modex                                              |Resulting Pattern             |
|-----------------------------------------------|------------------------|-----------------------------------------------------------|------------------------------|
|**Tab**                                        |:heavy_check_mark:      |**Tab**                                                    |"\\\\t"                       |
|**CarriageReturn**                             |:heavy_check_mark:      |**CarriageReturn**                                         |"\\\\r"                       |
|**NewLine**                                    |:heavy_check_mark:      |**NewLine**                                                |"\\\\n"                       |
|                                               |                        |                                                           |                              |
|**AnyCharacterIn**(*characterClassElements*)   |:heavy_check_mark:      |**AnyCharacterIn**('Z', '2', **Tab**)                      |"[Z2\\\\t]"                   |
|**AnyCharacterNotIn**(*characterClassElements*)|:heavy_check_mark:      |**AnyCharacterNotIn**('b', **NewLine**, '$')               |"[^b\\\\n$]"                  |
|**CharacterRange**(*first*, *last*)            |:heavy_check_mark:      |**AnyCharacterIn**('_', **CharacterRange**('A', 'M'))      |"[_A-M]"                      |
|**NonNewLineCharacter**                        |:heavy_check_mark:      |**NonNewLineCharacter**                                    |"."                           |
|**WordCharacter**                              |:heavy_check_mark:      |**WordCharacter**                                          |"\\\\w"                       |
|**NonWordCharacter**                           |:heavy_check_mark:      |**NonWordCharacter**                                       |"\\\\W"                       |
|**WhitespaceCharacter**                        |:heavy_check_mark:      |**WhitespaceCharacter**                                    |"\\\\s"                       |
|**NonWhitespaceCharacter**                     |:heavy_check_mark:      |**NonWhitespaceCharacter**                                 |"\\\\S"                       |
|**Digit**                                      |:heavy_check_mark:      |**Digit**                                                  |"\\\\d"                       |
|**NonDigit**                                   |:heavy_check_mark:      |**NonDigit**                                               |"\\\\D"                       |
|                                               |                        |                                                           |                              |
|**Beginning**                                  |:heavy_check_mark:      |**Beginning**                                              |"^"                           |
|**End**                                        |:heavy_check_mark:      |**End**                                                    |"$"                           |
|**WordBoundary**                               |:heavy_check_mark:      |**WordBoundary**                                           |"\\\\b"                       |
|**WordNonBoundary**                            |:heavy_check_mark:      |**WordNonBoundary**                                        |"\\\\B"                       |
|                                               |                        |                                                           |                              |
|**NamedGroup**(*name*, *subexpression*)        |:heavy_check_mark:      |**NamedGroup**("beginWithDigit", **Beginning** + **Digit**)|"(?&lt;beginWithDigit>^\\\\d)"|
|                                               |                        |                                                           |                              |
|**ZeroOrMoreOf**(*subexpression*)              |:heavy_check_mark:      |**ZeroOrMoreOf**(**WordCharacter**)                        |"\\\\w*"                      |
|**OneOrMoreOf**(*subexpression*)               |:heavy_check_mark:      |**OneOrMoreOf**(**Digit** \| **NonWordCharacter**)         |"(\\\\d\|\\\\S)+"             |
|**ZeroOrOneOf**(*subexpression*)               |:heavy_check_mark:      |**ZeroOrOneOf**(**WordBoundary**)                          |"\\\\b?"                      |
|**Times**(*times*)                             |:heavy_multiplication_x:|"aBc".**Times**(3)                                         |"(aBc){3}"                    |
|**TimesAtLeast**(*times*)                      |:heavy_multiplication_x:|**NonDigit**.**TimesAtLeast**(6)                           |"\\\\D"{6,}                   |
|**TimesBetween**(*min*, *max*)                 |:heavy_multiplication_x:|**Digit**.**TimesBetween**(10, 20)                         |"\\\\d{10,20}"                |

As can be seen in the **NamedGroup** example above, `Modex` elements can be concatenated by a `+` operator.

As can be seen in the **OneOrMoreOf** example above, a `|` operator can be used for alternating between `Modex` elements.

As can be seen in the **Times** example above, a `string` can serve as a `Modex` element by itself.

## Contribute
This is a living, developing project, so it might not cover everything that comes to mind.
If you have a need for a specific regular-expression pattern not supported by this package, or if you find a problem, bug or mismatch with the official Regex language, please contact me using the *Contact owners &rarr;* link on [the NuGet page](https://www.NuGet.org/packages/ModularExpressions) and I will do my best to comply.
Enjoy!
