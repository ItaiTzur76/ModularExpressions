Feature: ZeroOrMoreOf

ZeroOrMoreOf Modex

Scenario Outline: a match of a Modex for zero or more non-digits
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching zero or more <SubexpressionType> non-digits
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | SubexpressionType | MatchedSubstring |
| 567890      | Direct            |                  |
| 567890      | Indirect          |                  |
| J67890      | Direct            | J                |
| J67890      | Indirect          | J                |
| JK7890      | Direct            | JK               |
| JK7890      | Indirect          | JK               |
| JKL890      | Direct            | JKL              |
| JKL890      | Indirect          | JKL              |
