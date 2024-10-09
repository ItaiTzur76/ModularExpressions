Feature: WordNonBoundary

WordNonBoundary Modex

Scenario Outline: a match of a Modex with word non-boundary
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching 'H', then a non-new-line character, then a word non-boundary, then a non-new-line character
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| FGHIJ%#+    | HIJ              |
| %#H+-JKL    | H+-              |

Scenario Outline: a non-match of a Modex with word non-boundary
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching 'H', then a non-new-line character, then a word non-boundary, then a non-new-line character
	Then the Modex does not match
Examples:
| InputString |
| FGHI%#+     |
| %#H+JKL     |
