Feature: OneOrMoreOf

OneOrMoreOf Modex

Scenario Outline: a match of a Modex for one or more digits
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching one or more <SubexpressionType> digits
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | SubexpressionType | MatchedSubstring |
| 4CDEFG      | Direct            | 4                |
| 4CDEFG      | Indirect          | 4                |
| 45DEFG      | Direct            | 45               |
| 45DEFG      | Indirect          | 45               |
| 456EFG      | Direct            | 456              |
| 456EFG      | Indirect          | 456              |

Scenario Outline: a non-match of a Modex for one or more digits
	Given 'BCDEFG' as an input string
	When the input string is matched against a Modex property matching one or more <SubexpressionType> digits
	Then the Modex does not match
Examples:
| SubexpressionType |
| Direct            |
| Indirect          |
