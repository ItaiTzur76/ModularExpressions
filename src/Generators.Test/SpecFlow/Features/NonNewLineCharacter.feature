Feature: NonNewLineCharacter

NonNewLineCharacter Modex

Scenario: a match of a Modex for any non-new-line character
	Given any QWERTY-keyboard character as an input string
	When the input string is matched against a Modex property matching any non-new-line character
	Then the Modex matches the character in the input string

Scenario: a non-match of a Modex for any non-new-line character
	Given an input string containing only a new-line character
	When the input string is matched against a Modex property matching any non-new-line character
	Then the Modex does not match
