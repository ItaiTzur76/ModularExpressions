Feature: CharacterClass

Character-class Modex: WordCharacter, NonWordCharacter, WhitespaceCharacter, NonWhitespaceCharacter, Digit, NonDigit

Scenario Outline: a match of a Modex for a given character-class
	Given an input string containing a single <CharacterClass>
	When the input string is matched against a Modex property matching a <CharacterClass>
	Then the Modex matches the single <CharacterClass>
Examples:
| CharacterClass           |
| word character           |
| non-word character       |
| whitespace character     |
| non-whitespace character |
| digit                    |
| non-digit                |

Scenario Outline: a non-match of a Modex for a given character-class
	Given an input string not containing a <CharacterClass>
	When the input string is matched against a Modex property matching a <CharacterClass>
	Then the Modex does not match
Examples:
| CharacterClass           |
| word character           |
| non-word character       |
| whitespace character     |
| non-whitespace character |
| digit                    |
| non-digit                |
