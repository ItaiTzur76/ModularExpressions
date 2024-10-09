Feature: Parentheses

Parentheses and precedence in Modex

Scenario Outline: a match of a Modex (without parentheses) for a concatenation and then a bitwise-or
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching (with no parentheses) 'A' and a digit or '_'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| S $A9o#     | A9               |
| S $A_o#     | _                |

Scenario Outline: a match of a Modex (without parentheses) for a bitwise-or and then a concatenation
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching (with no parentheses) '^' or a word character and 'q'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| S $^qo#     | ^                |
| S $8qo#     | 8q               |

Scenario Outline: a match of a Modex (with parentheses) for a bitwise-or and then a concatenation
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching '@' or a word character (in parentheses) and then '#'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| S $@#o#     | @#               |
| S $8#o#     | 8#               |

Scenario Outline: a match of a Modex for a concatenation and then a quantifier
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching '%' and then one or more word characters
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| S%w%4%_%Q+  | %w               |
| S%w4%_%Q+-  | %w4              |
| S%wW4%_%Q+- | %wW4             |
| S%wW4_%Q.+- | %wW4_            |
| S%wW45_%Q.+ | %wW45_           |
| S%wW45_Q.+- | %wW45_Q          |

Scenario Outline: a match of a Modex for a concatenation inside a quantifier
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching one or more instances of '%' and a word character
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| S%wW45_Q.+- | %w               |
| S%w%45_Q.+- | %w%4             |
| S%w%4%_Q.+- | %w%4%_           |
| S%w%4%_%Q+- | %w%4%_%Q         |
