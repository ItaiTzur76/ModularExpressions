Feature: BitwiseOr

Addition Modex

Scenario Outline: a match of a Modex for a bitwise-or
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching a <SubexpressionType> bitwise-or of a digit and a non-word character
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | SubexpressionType | MatchedSubstring |
| A_f3qZ      | Direct            | 3                |
| A_f3qZ      | Indirect          | 3                |
| A_f&qZ      | Direct            | &                |
| A_f&qZ      | Indirect          | &                |

Scenario Outline: a non-match of a Modex for a bitwise-or
	Given 'A_fyqZ' as an input string
	When the input string is matched against a Modex property matching a <SubexpressionType> bitwise-or of a digit and a non-word character
	Then the Modex does not match
Examples:
| SubexpressionType |
| Direct            |
| Indirect          |
