Feature: WordBoundary

WordBoundary Modex

Scenario Outline: a match of a Modex with word boundary
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching 'H', then a non-new-line character, then a word boundary, then a non-new-line character
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| FGHI%#+     | HI%              |
| %#H+JKL     | H+J              |

Scenario Outline: a non-match of a Modex with word boundary
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching 'H', then a non-new-line character, then a word boundary, then a non-new-line character
	Then the Modex does not match
Examples:
| InputString |
| FGHIJ%#+    |
| %#H+-JKL    |
