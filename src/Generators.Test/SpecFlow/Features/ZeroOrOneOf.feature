Feature: ZeroOrOneOf

ZeroOrOneOf Modex

Scenario Outline: a match of a Modex for zero or one non-word characters
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching zero or one <SubexpressionType> non-word characters
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | SubexpressionType | MatchedSubstring |
| QRS         | Direct            |                  |
| QRS         | Indirect          |                  |
| #QRS        | Direct            | #                |
| #QRS        | Indirect          | #                |
| #$QRS       | Direct            | #                |
| #$QRS       | Indirect          | #                |
