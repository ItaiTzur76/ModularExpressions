Feature: Addition

Addition Modex

Scenario Outline: a match of a Modex for a concatenation
	Given 'a3_B% 1Pz' as an input string
	When the input string is matched against a Modex property matching a <SubexpressionType> concatenation of a non-word character and a whitespace character
	Then the Modex matches '% '
Examples:
| SubexpressionType |
| Direct            |
| Indirect          |

Scenario Outline: a non-match of a Modex for a concatenation
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching a <SubexpressionType> concatenation of a non-word character and a whitespace character
	Then the Modex does not match
Examples:
| InputString | SubexpressionType |
| a3_B%1 Pz   | Direct            |
| a3_B%1 Pz   | Indirect          |
| a3_%B 1Pz   | Direct            |
| a3_%B 1Pz   | Indirect          |
