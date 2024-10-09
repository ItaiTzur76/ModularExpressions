Feature: AnyCharacterNotIn

AnyCharacterNotIn Modex

Scenario Outline: a match of a Modex for any character not in a list starting with a caret
	Given 'W^5!5W^' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except '^', 'W' or '5'
	Then the Modex matches '!'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list starting with a caret
	Given an input string containing only '^', 'W' and '5'
	When the input string is matched against a <TokenType> Modex property matching any character except '^', 'W' or '5'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a backslash
	Given 'D8\8-DD\' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except '8', '\' or 'D'
	Then the Modex matches '-'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a backslash
	Given an input string containing only '8', '\' and 'D'
	When the input string is matched against a <TokenType> Modex property matching any character except '8', '\' or 'D'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a double-quote
	Given '""6P2P6"6' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'P', '"' or '6'
	Then the Modex matches '2'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a double-quote
	Given an input string containing only 'P', '"' and '6'
	When the input string is matched against a <TokenType> Modex property matching any character except 'P', '"' or '6'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a right-bracket
	Given 'M9[M]]9]' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except '9', ']' or 'M'
	Then the Modex matches '['
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a right-bracket
	Given an input string containing only '9', ']' and 'M'
	When the input string is matched against a <TokenType> Modex property matching any character except '9', ']' or 'M'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list starting with a minus
	Given '4-4J-\-4-' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except '-', '4' or 'J'
	Then the Modex matches '\'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list starting with a minus
	Given an input string containing only '-', '4' and 'J'
	When the input string is matched against a <TokenType> Modex property matching any character except '-', '4' or 'J'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list ending with a minus
	Given '-C7-877CC' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'C', '7' or '-'
	Then the Modex matches '8'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list ending with a minus
	Given an input string containing only 'C', '7' and '-'
	When the input string is matched against a <TokenType> Modex property matching any character except 'C', '7' or '-'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a non-peripheral minus
	Given '-S--S$22-' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except '2', '-' or 'S'
	Then the Modex matches '$'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a non-peripheral minus
	Given an input string containing only '2', '-' and 'S'
	When the input string is matched against a <TokenType> Modex property matching any character except '2', '-' or 'S'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario: a match of a Modex for any character not in a list containing a word character
	Given 'a@_!3?Q@' as an input string
	When the input string is matched against a Modex property matching any character except '@', word characters or '!'
	Then the Modex matches '?'

Scenario: a non-match of a Modex for any character not in a list containing a word character
	Given an input string containing only '@', word characters and '!'
	When the input string is matched against a Modex property matching any character except '@', word characters or '!'
	Then the Modex does not match

Scenario: a match of a Modex for any character not in a list containing a non-word character
	Given '(1)%C1#_[C]' as an input string
	When the input string is matched against a Modex property matching any character except 'C', non-word characters or '1'
	Then the Modex matches '_'

Scenario: a non-match of a Modex for any character not in a list containing a non-word character
	Given an input string containing only 'C', non-word characters and '1'
	When the input string is matched against a Modex property matching any character except 'C', non-word characters or '1'
	Then the Modex does not match

Scenario: a match of a Modex for any character not in a list containing a whitespace character
	Given ' 2  q2 2Q' as an input string
	When the input string is matched against a Modex property matching any character except 'Q', whitespace characters or '2'
	Then the Modex matches 'q'

Scenario: a non-match of a Modex for any character not in a list containing a whitespace character
	Given an input string containing only 'Q', whitespace characters and '2'
	When the input string is matched against a Modex property matching any character except 'Q', whitespace characters or '2'
	Then the Modex does not match

Scenario: a match of a Modex for any character not in a list containing a non-whitespace character
	Given an input string containing a non-whitespace character
	When the input string is matched against a Modex property matching any character except non-whitespace characters or a tab
	Then the Modex matches

Scenario: a non-match of a Modex for any character not in a list containing a non-whitespace character
	Given an input string containing only non-whitespace characters
	When the input string is matched against a Modex property matching any character except non-whitespace characters or a tab
	Then the Modex does not match

Scenario: a match of a Modex for any character not in a list containing a digit
	Given '%0X432I%X7' as an input string
	When the input string is matched against a Modex property matching any character except 'X', digits or '%'
	Then the Modex matches 'I'

Scenario: a non-match of a Modex for any character not in a list containing a digit
	Given an input string containing only 'X', digits and '%'
	When the input string is matched against a Modex property matching any character except 'X', digits or '%'
	Then the Modex does not match

Scenario: a match of a Modex for any character not in a list containing a non-digit
	Given '#8 )348~' as an input string
	When the input string is matched against a Modex property matching any character except '3', non-digits or '8'
	Then the Modex matches '4'

Scenario: a non-match of a Modex for any character not in a list containing a non-digit
	Given an input string containing only '3', non-digits and '8'
	When the input string is matched against a Modex property matching any character except '3', non-digits or '8'
	Then the Modex does not match

Scenario Outline: a match of a Modex for any character not in a list starting with a character-range from caret
	Given '_B^_~`B^' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except '^' to '`', or 'B'
	Then the Modex matches '~'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list starting with a character-range from caret
	Given an input string containing only '^' to '`', and 'B'
	When the input string is matched against a <TokenType> Modex property matching any character except '^' to '`', or 'B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a character-range from backslash
	Given '\^0Z_0[Z]\' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'Z', '\' to '_', or '0'
	Then the Modex matches '['
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a character-range from backslash
	Given an input string containing only 'Z', '\' to '_', and '0'
	When the input string is matched against a <TokenType> Modex property matching any character except 'Z', '\' to '_', or '0'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a character-range to backslash
	Given '5R\Z [5Z' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'R', 'Z' to '\', or '5'
	Then the Modex matches ' '
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a character-range to backslash
	Given an input string containing only 'R', 'Z' to '\', and '5'
	When the input string is matched against a <TokenType> Modex property matching any character except 'R', 'Z' to '\', or '5'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a character-range from double-quote
	Given '#1"Y"#12$' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'Y', '"' to '$', or '1'
	Then the Modex matches '2'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a character-range from double-quote
	Given an input string containing only 'Y', '"' to '$', and '1'
	When the input string is matched against a <TokenType> Modex property matching any character except 'Y', '"' to '$', or '1'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a character-range to double-quote
	Given '7 E! """7e ' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'E', ' ' to '"', or '7'
	Then the Modex matches 'e'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a character-range to double-quote
	Given an input string containing only 'E', ' ' to '"', and '7'
	When the input string is matched against a <TokenType> Modex property matching any character except 'E', ' ' to '"', or '7'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a character-range from right-bracket
	Given '^`A]_(2`]' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'A', ']' to '`', or '2'
	Then the Modex matches '('
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a character-range from right-bracket
	Given an input string containing only 'A', ']' to '`', and '2'
	When the input string is matched against a <TokenType> Modex property matching any character except 'A', ']' to '`', or '2'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list containing a character-range to right-bracket
	Given '8[H]\]|[8\' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'H', '[' to ']', or '8'
	Then the Modex matches '|'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list containing a character-range to right-bracket
	Given an input string containing only 'H', '[' to ']', and '8'
	When the input string is matched against a <TokenType> Modex property matching any character except 'H', '[' to ']', or '8'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list starting with a character-range to minus
	Given '-L+-L,L+L=-L' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except '+' to '-', or 'L'
	Then the Modex matches '='
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list starting with a character-range to minus
	Given an input string containing only '+' to '-', and 'L'
	When the input string is matched against a <TokenType> Modex property matching any character except '+' to '-', or 'L'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character not in a list ending with a character-range from minus
	Given '-T0T\0' as an input string
	When the input string is matched against a <TokenType> Modex property matching any character except 'T', or '-' to '0'
	Then the Modex matches '\'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex for any character not in a list ending with a character-range from minus
	Given an input string containing only 'T', and '-' to '0'
	When the input string is matched against a <TokenType> Modex property matching any character except 'T', or '-' to '0'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |
