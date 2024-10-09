Feature: AnyCharacterIn

AnyCharacterIn Modex

Scenario Outline: a match of a Modex for any character in a list starting with a caret
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching '^', 'W' or '5'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| ab^346UVX   | Literal                                  | ^                |
| ab^346UVX   | Const in non-nested namespaced class     | ^                |
| ab^346UVX   | Const in nested namespaced class         | ^                |
| ab^346UVX   | Const in another class in same namespace | ^                |
| ab^346UVX   | Const in another namespace               | ^                |
| ab^346UVX   | Const in global class                    | ^                |
| abc346UVW   | Literal                                  | W                |
| abc346UVW   | Const in non-nested namespaced class     | W                |
| abc346UVW   | Const in nested namespaced class         | W                |
| abc346UVW   | Const in another class in same namespace | W                |
| abc346UVW   | Const in another namespace               | W                |
| abc346UVW   | Const in global class                    | W                |
| abc345UVX   | Literal                                  | 5                |
| abc345UVX   | Const in non-nested namespaced class     | 5                |
| abc345UVX   | Const in nested namespaced class         | 5                |
| abc345UVX   | Const in another class in same namespace | 5                |
| abc345UVX   | Const in another namespace               | 5                |
| abc345UVX   | Const in global class                    | 5                |

Scenario Outline: a non-match of a Modex for any character in a list starting with a caret
	Given an input string not containing '^', 'W' or '5'
	When the input string is matched against a <TokenType> Modex property matching '^', 'W' or '5'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a backslash
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching '8', '\' or 'D'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| 678+-sBCE   | Literal                                  | 8                |
| 678+-sBCE   | Const in non-nested namespaced class     | 8                |
| 678+-sBCE   | Const in nested namespaced class         | 8                |
| 678+-sBCE   | Const in another class in same namespace | 8                |
| 678+-sBCE   | Const in another namespace               | 8                |
| 678+-sBCE   | Const in global class                    | 8                |
| 679+\sBCE   | Literal                                  | \                |
| 679+\sBCE   | Const in non-nested namespaced class     | \                |
| 679+\sBCE   | Const in nested namespaced class         | \                |
| 679+\sBCE   | Const in another class in same namespace | \                |
| 679+\sBCE   | Const in another namespace               | \                |
| 679+\sBCE   | Const in global class                    | \                |
| 679+-sBCD   | Literal                                  | D                |
| 679+-sBCD   | Const in non-nested namespaced class     | D                |
| 679+-sBCD   | Const in nested namespaced class         | D                |
| 679+-sBCD   | Const in another class in same namespace | D                |
| 679+-sBCD   | Const in another namespace               | D                |
| 679+-sBCD   | Const in global class                    | D                |

Scenario Outline: a non-match of a Modex for any character in a list containing a backslash
	Given an input string not containing '8', '\' or 'D'
	When the input string is matched against a <TokenType> Modex property matching '8', '\' or 'D'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a double-quote
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'P', '"' or '6'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| NOP-_+457   | Literal                                  | P                |
| NOP-_+457   | Const in non-nested namespaced class     | P                |
| NOP-_+457   | Const in nested namespaced class         | P                |
| NOP-_+457   | Const in another class in same namespace | P                |
| NOP-_+457   | Const in another namespace               | P                |
| NOP-_+457   | Const in global class                    | P                |
| NOQ-"+457   | Literal                                  | "                |
| NOQ-"+457   | Const in non-nested namespaced class     | "                |
| NOQ-"+457   | Const in nested namespaced class         | "                |
| NOQ-"+457   | Const in another class in same namespace | "                |
| NOQ-"+457   | Const in another namespace               | "                |
| NOQ-"+457   | Const in global class                    | "                |
| NOQ-_+456   | Literal                                  | 6                |
| NOQ-_+456   | Const in non-nested namespaced class     | 6                |
| NOQ-_+456   | Const in nested namespaced class         | 6                |
| NOQ-_+456   | Const in another class in same namespace | 6                |
| NOQ-_+456   | Const in another namespace               | 6                |
| NOQ-_+456   | Const in global class                    | 6                |

Scenario Outline: a non-match of a Modex for any character in a list containing a double-quote
	Given an input string not containing 'P', '"' or '6'
	When the input string is matched against a <TokenType> Modex property matching 'P', '"' or '6'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a right-bracket
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching '9', ']' or 'M'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| 789#$%KLN   | Literal                                  | 9                |
| 789#$%KLN   | Const in non-nested namespaced class     | 9                |
| 789#$%KLN   | Const in nested namespaced class         | 9                |
| 789#$%KLN   | Const in another class in same namespace | 9                |
| 789#$%KLN   | Const in another namespace               | 9                |
| 789#$%KLN   | Const in global class                    | 9                |
| 780#]%KLN   | Literal                                  | ]                |
| 780#]%KLN   | Const in non-nested namespaced class     | ]                |
| 780#]%KLN   | Const in nested namespaced class         | ]                |
| 780#]%KLN   | Const in another class in same namespace | ]                |
| 780#]%KLN   | Const in another namespace               | ]                |
| 780#]%KLN   | Const in global class                    | ]                |
| 780#$%KLM   | Literal                                  | M                |
| 780#$%KLM   | Const in non-nested namespaced class     | M                |
| 780#$%KLM   | Const in nested namespaced class         | M                |
| 780#$%KLM   | Const in another class in same namespace | M                |
| 780#$%KLM   | Const in another namespace               | M                |
| 780#$%KLM   | Const in global class                    | M                |

Scenario Outline: a non-match of a Modex for any character in a list containing a right-bracket
	Given an input string not containing '9', ']' or 'M'
	When the input string is matched against a <TokenType> Modex property matching '9', ']' or 'M'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list starting with a minus
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching '-', '4' or 'J'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| xy-235HIK   | Literal                                  | -                |
| xy-235HIK   | Const in non-nested namespaced class     | -                |
| xy-235HIK   | Const in nested namespaced class         | -                |
| xy-235HIK   | Const in another class in same namespace | -                |
| xy-235HIK   | Const in another namespace               | -                |
| xy-235HIK   | Const in global class                    | -                |
| xy+234HIK   | Literal                                  | 4                |
| xy+234HIK   | Const in non-nested namespaced class     | 4                |
| xy+234HIK   | Const in nested namespaced class         | 4                |
| xy+234HIK   | Const in another class in same namespace | 4                |
| xy+234HIK   | Const in another namespace               | 4                |
| xy+234HIK   | Const in global class                    | 4                |
| xy+235HIJ   | Literal                                  | J                |
| xy+235HIJ   | Const in non-nested namespaced class     | J                |
| xy+235HIJ   | Const in nested namespaced class         | J                |
| xy+235HIJ   | Const in another class in same namespace | J                |
| xy+235HIJ   | Const in another namespace               | J                |
| xy+235HIJ   | Const in global class                    | J                |

Scenario Outline: a non-match of a Modex for any character in a list starting with a minus
	Given an input string not containing '-', '4' or 'J'
	When the input string is matched against a <TokenType> Modex property matching '-', '4' or 'J'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list ending with a minus
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'C', '7' or '-'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| ABC568uv*   | Literal                                  | C                |
| ABC568uv*   | Const in non-nested namespaced class     | C                |
| ABC568uv*   | Const in nested namespaced class         | C                |
| ABC568uv*   | Const in another class in same namespace | C                |
| ABC568uv*   | Const in another namespace               | C                |
| ABC568uv*   | Const in global class                    | C                |
| ABD567uv*   | Literal                                  | 7                |
| ABD567uv*   | Const in non-nested namespaced class     | 7                |
| ABD567uv*   | Const in nested namespaced class         | 7                |
| ABD567uv*   | Const in another class in same namespace | 7                |
| ABD567uv*   | Const in another namespace               | 7                |
| ABD567uv*   | Const in global class                    | 7                |
| ABD568uv-   | Literal                                  | -                |
| ABD568uv-   | Const in non-nested namespaced class     | -                |
| ABD568uv-   | Const in nested namespaced class         | -                |
| ABD568uv-   | Const in another class in same namespace | -                |
| ABD568uv-   | Const in another namespace               | -                |
| ABD568uv-   | Const in global class                    | -                |

Scenario Outline: a non-match of a Modex for any character in a list ending with a minus
	Given an input string not containing 'C', '7' or '-'
	When the input string is matched against a <TokenType> Modex property matching 'C', '7' or '-'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a non-peripheral minus
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching '2', '-' or 'S'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| 012gh$QRT   | Literal                                  | 2                |
| 012gh$QRT   | Const in non-nested namespaced class     | 2                |
| 012gh$QRT   | Const in nested namespaced class         | 2                |
| 012gh$QRT   | Const in another class in same namespace | 2                |
| 012gh$QRT   | Const in another namespace               | 2                |
| 012gh$QRT   | Const in global class                    | 2                |
| 013gh-QRT   | Literal                                  | -                |
| 013gh-QRT   | Const in non-nested namespaced class     | -                |
| 013gh-QRT   | Const in nested namespaced class         | -                |
| 013gh-QRT   | Const in another class in same namespace | -                |
| 013gh-QRT   | Const in another namespace               | -                |
| 013gh-QRT   | Const in global class                    | -                |
| 013gh$QRS   | Literal                                  | S                |
| 013gh$QRS   | Const in non-nested namespaced class     | S                |
| 013gh$QRS   | Const in nested namespaced class         | S                |
| 013gh$QRS   | Const in another class in same namespace | S                |
| 013gh$QRS   | Const in another namespace               | S                |
| 013gh$QRS   | Const in global class                    | S                |

Scenario Outline: a non-match of a Modex for any character in a list containing a non-peripheral minus
	Given an input string not containing '2', '-' or 'S'
	When the input string is matched against a <TokenType> Modex property matching '2', '-' or 'S'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a word character
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching '@', a word character or '!'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| +-@^?*#     | @                |
| +-&b?*#     | b                |
| +-&y?*#     | y                |
| +-&C?*#     | C                |
| +-&X?*#     | X                |
| +-&_?*#     | _                |
| +-&^?*!     | !                |

Scenario: a non-match of a Modex for any character in a list containing a word character
	Given an input string not containing '@', a word character or '!'
	When the input string is matched against a Modex property matching '@', a word character or '!'
	Then the Modex does not match

Scenario Outline: a match of a Modex for any character in a list containing a non-word character
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching 'C', a non-word character or '1'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| ABC7902     | C                |
| ABD!902     | !                |
| ABD$902     | $                |
| ABD/902     | /                |
| ABDf901     | 1                |

Scenario: a non-match of a Modex for any character in a list containing a non-word character
	Given an input string not containing 'C', a non-word character or '1'
	When the input string is matched against a Modex property matching 'C', a non-word character or '1'
	Then the Modex does not match

Scenario Outline: a match of a Modex for any character in a list containing a whitespace character
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching 'Q', a whitespace character or '2'
	Then the Modex matches the text surrounded by single-quote characters in '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| OPQ7013     | 'Q'              |
| OPR 013     | ' '              |
| OPRA012     | '2'              |

Scenario: a non-match of a Modex for any character in a list containing a whitespace character
	Given an input string not containing 'Q', a whitespace character or '2'
	When the input string is matched against a Modex property matching 'Q', a whitespace character or '2'
	Then the Modex does not match

Scenario: a match of a Modex for any character in a list containing a non-whitespace character
	Given an input string containing a non-whitespace character
	When the input string is matched against a Modex property matching a non-whitespace character or a tab
	Then the Modex matches

Scenario: a non-match of a Modex for any character in a list containing a non-whitespace character
	Given an input string not containing a non-whitespace character
	When the input string is matched against a Modex property matching a non-whitespace character or a tab
	Then the Modex does not match

Scenario Outline: a match of a Modex for any character in a list containing a digit
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching 'X', a digit or '%'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| VWXB-![     | X                |
| VWY2-!}     | 2                |
| VWY6-!\     | 6                |
| VWY0-!/     | 0                |
| VWYZ-!%     | %                |

Scenario: a non-match of a Modex for any character in a list containing a digit
	Given an input string not containing 'X', a digit or '%'
	When the input string is matched against a Modex property matching 'X', a digit or '%'
	Then the Modex does not match

Scenario Outline: a match of a Modex for any character in a list containing a non-digit
	Given '<InputString>' as an input string
	When the input string is matched against a Modex property matching '3', a non-digit or '8'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | MatchedSubstring |
| 1230679     | 3                |
| 124D679     | D                |
| 124_679     | _                |
| 124y679     | y                |
| 1245678     | 8                |

Scenario: a non-match of a Modex for any character in a list containing a non-digit
	Given an input string not containing '3', a non-digit or '8'
	When the input string is matched against a Modex property matching '3', a non-digit or '8'
	Then the Modex does not match

Scenario Outline: a match of a Modex for any character in a list starting with a character-range from caret
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching '^' to '`', or 'B'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| ab^ZAC      | Literal                                  | ^                |
| ab^ZAC      | Const in non-nested namespaced class     | ^                |
| ab^ZAC      | Const in nested namespaced class         | ^                |
| ab^ZAC      | Const in another class in same namespace | ^                |
| ab^ZAC      | Const in another namespace               | ^                |
| ab^ZAC      | Const in global class                    | ^                |
| ab_ZAC      | Literal                                  | _                |
| ab_ZAC      | Const in non-nested namespaced class     | _                |
| ab_ZAC      | Const in nested namespaced class         | _                |
| ab_ZAC      | Const in another class in same namespace | _                |
| ab_ZAC      | Const in another namespace               | _                |
| ab_ZAC      | Const in global class                    | _                |
| ab`ZAC      | Literal                                  | `                |
| ab`ZAC      | Const in non-nested namespaced class     | `                |
| ab`ZAC      | Const in nested namespaced class         | `                |
| ab`ZAC      | Const in another class in same namespace | `                |
| ab`ZAC      | Const in another namespace               | `                |
| ab`ZAC      | Const in global class                    | `                |
| ab]ZAB      | Literal                                  | B                |
| ab]ZAB      | Const in non-nested namespaced class     | B                |
| ab]ZAB      | Const in nested namespaced class         | B                |
| ab]ZAB      | Const in another class in same namespace | B                |
| ab]ZAB      | Const in another namespace               | B                |
| ab]ZAB      | Const in global class                    | B                |

Scenario Outline: a non-match of a Modex for any character in a list starting with a character-range from caret
	Given an input string not containing '^' to '`', or 'B'
	When the input string is matched against a <TokenType> Modex property matching '^' to '`', or 'B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a character-range from backslash
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'Z', '\' to '_', or '0'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| XYZuv/891   | Literal                                  | Z                |
| XYZuv/891   | Const in non-nested namespaced class     | Z                |
| XYZuv/891   | Const in nested namespaced class         | Z                |
| XYZuv/891   | Const in another class in same namespace | Z                |
| XYZuv/891   | Const in another namespace               | Z                |
| XYZuv/891   | Const in global class                    | Z                |
| XYAuv\891   | Literal                                  | \                |
| XYAuv\891   | Const in non-nested namespaced class     | \                |
| XYAuv\891   | Const in nested namespaced class         | \                |
| XYAuv\891   | Const in another class in same namespace | \                |
| XYAuv\891   | Const in another namespace               | \                |
| XYAuv\891   | Const in global class                    | \                |
| XYAuv]891   | Literal                                  | ]                |
| XYAuv]891   | Const in non-nested namespaced class     | ]                |
| XYAuv]891   | Const in nested namespaced class         | ]                |
| XYAuv]891   | Const in another class in same namespace | ]                |
| XYAuv]891   | Const in another namespace               | ]                |
| XYAuv]891   | Const in global class                    | ]                |
| XYAuv_891   | Literal                                  | _                |
| XYAuv_891   | Const in non-nested namespaced class     | _                |
| XYAuv_891   | Const in nested namespaced class         | _                |
| XYAuv_891   | Const in another class in same namespace | _                |
| XYAuv_891   | Const in another namespace               | _                |
| XYAuv_891   | Const in global class                    | _                |
| XYAuvw890   | Literal                                  | 0                |
| XYAuvw890   | Const in non-nested namespaced class     | 0                |
| XYAuvw890   | Const in nested namespaced class         | 0                |
| XYAuvw890   | Const in another class in same namespace | 0                |
| XYAuvw890   | Const in another namespace               | 0                |
| XYAuvw890   | Const in global class                    | 0                |

Scenario Outline: a non-match of a Modex for any character in a list containing a character-range from backslash
	Given an input string not containing 'Z', '\' to '_', or '0'
	When the input string is matched against a <TokenType> Modex property matching 'Z', '\' to '_', or '0'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a character-range to backslash
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'R', 'Z' to '\', or '5'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| PQRef+346   | Literal                                  | R                |
| PQRef+346   | Const in non-nested namespaced class     | R                |
| PQRef+346   | Const in nested namespaced class         | R                |
| PQRef+346   | Const in another class in same namespace | R                |
| PQRef+346   | Const in another namespace               | R                |
| PQRef+346   | Const in global class                    | R                |
| PQSefZ346   | Literal                                  | Z                |
| PQSefZ346   | Const in non-nested namespaced class     | Z                |
| PQSefZ346   | Const in nested namespaced class         | Z                |
| PQSefZ346   | Const in another class in same namespace | Z                |
| PQSefZ346   | Const in another namespace               | Z                |
| PQSefZ346   | Const in global class                    | Z                |
| PQSef[346   | Literal                                  | [                |
| PQSef[346   | Const in non-nested namespaced class     | [                |
| PQSef[346   | Const in nested namespaced class         | [                |
| PQSef[346   | Const in another class in same namespace | [                |
| PQSef[346   | Const in another namespace               | [                |
| PQSef[346   | Const in global class                    | [                |
| PQSef\346   | Literal                                  | \                |
| PQSef\346   | Const in non-nested namespaced class     | \                |
| PQSef\346   | Const in nested namespaced class         | \                |
| PQSef\346   | Const in another class in same namespace | \                |
| PQSef\346   | Const in another namespace               | \                |
| PQSef\346   | Const in global class                    | \                |
| PQSef=345   | Literal                                  | 5                |
| PQSef=345   | Const in non-nested namespaced class     | 5                |
| PQSef=345   | Const in nested namespaced class         | 5                |
| PQSef=345   | Const in another class in same namespace | 5                |
| PQSef=345   | Const in another namespace               | 5                |
| PQSef=345   | Const in global class                    | 5                |

Scenario Outline: a non-match of a Modex for any character in a list containing a character-range to backslash
	Given an input string not containing 'R', 'Z' to '\', or '5'
	When the input string is matched against a <TokenType> Modex property matching 'R', 'Z' to '\', or '5'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a character-range from double-quote
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'Y', '"' to '$', or '1'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| WXY&*@902   | Literal                                  | Y                |
| WXY&*@902   | Const in non-nested namespaced class     | Y                |
| WXY&*@902   | Const in nested namespaced class         | Y                |
| WXY&*@902   | Const in another class in same namespace | Y                |
| WXY&*@902   | Const in another namespace               | Y                |
| WXY&*@902   | Const in global class                    | Y                |
| WXZ&*"902   | Literal                                  | "                |
| WXZ&*"902   | Const in non-nested namespaced class     | "                |
| WXZ&*"902   | Const in nested namespaced class         | "                |
| WXZ&*"902   | Const in another class in same namespace | "                |
| WXZ&*"902   | Const in another namespace               | "                |
| WXZ&*"902   | Const in global class                    | "                |
| WXZ&*#902   | Literal                                  | #                |
| WXZ&*#902   | Const in non-nested namespaced class     | #                |
| WXZ&*#902   | Const in nested namespaced class         | #                |
| WXZ&*#902   | Const in another class in same namespace | #                |
| WXZ&*#902   | Const in another namespace               | #                |
| WXZ&*#902   | Const in global class                    | #                |
| WXZ&*$902   | Literal                                  | $                |
| WXZ&*$902   | Const in non-nested namespaced class     | $                |
| WXZ&*$902   | Const in nested namespaced class         | $                |
| WXZ&*$902   | Const in another class in same namespace | $                |
| WXZ&*$902   | Const in another namespace               | $                |
| WXZ&*$902   | Const in global class                    | $                |
| WXZ&*@901   | Literal                                  | 1                |
| WXZ&*@901   | Const in non-nested namespaced class     | 1                |
| WXZ&*@901   | Const in nested namespaced class         | 1                |
| WXZ&*@901   | Const in another class in same namespace | 1                |
| WXZ&*@901   | Const in another namespace               | 1                |
| WXZ&*@901   | Const in global class                    | 1                |

Scenario Outline: a non-match of a Modex for any character in a list containing a character-range from double-quote
	Given an input string not containing 'Y', '"' to '$', or '1'
	When the input string is matched against a <TokenType> Modex property matching 'Y', '"' to '$', or '1'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a character-range to double-quote
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'E', '!' to '"', or '7'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| CDEpo?568   | Literal                                  | E                |
| CDEpo?568   | Const in non-nested namespaced class     | E                |
| CDEpo?568   | Const in nested namespaced class         | E                |
| CDEpo?568   | Const in another class in same namespace | E                |
| CDEpo?568   | Const in another namespace               | E                |
| CDEpo?568   | Const in global class                    | E                |
| CDFpo!568   | Literal                                  | !                |
| CDFpo!568   | Const in non-nested namespaced class     | !                |
| CDFpo!568   | Const in nested namespaced class         | !                |
| CDFpo!568   | Const in another class in same namespace | !                |
| CDFpo!568   | Const in another namespace               | !                |
| CDFpo!568   | Const in global class                    | !                |
| CDFpo"568   | Literal                                  | "                |
| CDFpo"568   | Const in non-nested namespaced class     | "                |
| CDFpo"568   | Const in nested namespaced class         | "                |
| CDFpo"568   | Const in another class in same namespace | "                |
| CDFpo"568   | Const in another namespace               | "                |
| CDFpo"568   | Const in global class                    | "                |
| CDFpo?567   | Literal                                  | 7                |
| CDFpo?567   | Const in non-nested namespaced class     | 7                |
| CDFpo?567   | Const in nested namespaced class         | 7                |
| CDFpo?567   | Const in another class in same namespace | 7                |
| CDFpo?567   | Const in another namespace               | 7                |
| CDFpo?567   | Const in global class                    | 7                |

Scenario Outline: a non-match of a Modex for any character in a list containing a character-range to double-quote
	Given an input string not containing 'E', '!' to '"', or '7'
	When the input string is matched against a <TokenType> Modex property matching 'E', '!' to '"', or '7'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a character-range from right-bracket
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A', ']' to '`', or '2'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| YZA%.,013   | Literal                                  | A                |
| YZA%.,013   | Const in non-nested namespaced class     | A                |
| YZA%.,013   | Const in nested namespaced class         | A                |
| YZA%.,013   | Const in another class in same namespace | A                |
| YZA%.,013   | Const in another namespace               | A                |
| YZA%.,013   | Const in global class                    | A                |
| YZB%.]013   | Literal                                  | ]                |
| YZB%.]013   | Const in non-nested namespaced class     | ]                |
| YZB%.]013   | Const in nested namespaced class         | ]                |
| YZB%.]013   | Const in another class in same namespace | ]                |
| YZB%.]013   | Const in another namespace               | ]                |
| YZB%.]013   | Const in global class                    | ]                |
| YZB%._013   | Literal                                  | _                |
| YZB%._013   | Const in non-nested namespaced class     | _                |
| YZB%._013   | Const in nested namespaced class         | _                |
| YZB%._013   | Const in another class in same namespace | _                |
| YZB%._013   | Const in another namespace               | _                |
| YZB%._013   | Const in global class                    | _                |
| YZB%.`013   | Literal                                  | `                |
| YZB%.`013   | Const in non-nested namespaced class     | `                |
| YZB%.`013   | Const in nested namespaced class         | `                |
| YZB%.`013   | Const in another class in same namespace | `                |
| YZB%.`013   | Const in another namespace               | `                |
| YZB%.`013   | Const in global class                    | `                |
| YZB%.,012   | Literal                                  | 2                |
| YZB%.,012   | Const in non-nested namespaced class     | 2                |
| YZB%.,012   | Const in nested namespaced class         | 2                |
| YZB%.,012   | Const in another class in same namespace | 2                |
| YZB%.,012   | Const in another namespace               | 2                |
| YZB%.,012   | Const in global class                    | 2                |

Scenario Outline: a non-match of a Modex for any character in a list containing a character-range from right-bracket
	Given an input string not containing 'A', ']' to '`', or '2'
	When the input string is matched against a <TokenType> Modex property matching 'A', ']' to '`', or '2'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list containing a character-range to right-bracket
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'H', '[' to ']', or '8'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| FGH/?!679   | Literal                                  | H                |
| FGH/?!679   | Const in non-nested namespaced class     | H                |
| FGH/?!679   | Const in nested namespaced class         | H                |
| FGH/?!679   | Const in another class in same namespace | H                |
| FGH/?!679   | Const in another namespace               | H                |
| FGH/?!679   | Const in global class                    | H                |
| FGI/?[679   | Literal                                  | [                |
| FGI/?[679   | Const in non-nested namespaced class     | [                |
| FGI/?[679   | Const in nested namespaced class         | [                |
| FGI/?[679   | Const in another class in same namespace | [                |
| FGI/?[679   | Const in another namespace               | [                |
| FGI/?[679   | Const in global class                    | [                |
| FGI/?\679   | Literal                                  | \                |
| FGI/?\679   | Const in non-nested namespaced class     | \                |
| FGI/?\679   | Const in nested namespaced class         | \                |
| FGI/?\679   | Const in another class in same namespace | \                |
| FGI/?\679   | Const in another namespace               | \                |
| FGI/?\679   | Const in global class                    | \                |
| FGI/?]679   | Literal                                  | ]                |
| FGI/?]679   | Const in non-nested namespaced class     | ]                |
| FGI/?]679   | Const in nested namespaced class         | ]                |
| FGI/?]679   | Const in another class in same namespace | ]                |
| FGI/?]679   | Const in another namespace               | ]                |
| FGI/?]679   | Const in global class                    | ]                |
| FGI/?!678   | Literal                                  | 8                |
| FGI/?!678   | Const in non-nested namespaced class     | 8                |
| FGI/?!678   | Const in nested namespaced class         | 8                |
| FGI/?!678   | Const in another class in same namespace | 8                |
| FGI/?!678   | Const in another namespace               | 8                |
| FGI/?!678   | Const in global class                    | 8                |

Scenario Outline: a non-match of a Modex for any character in a list containing a character-range to right-bracket
	Given an input string not containing 'H', '[' to ']', or '8'
	When the input string is matched against a <TokenType> Modex property matching 'H', '[' to ']', or '8'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list starting with a character-range to minus
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching '+' to '-', or 'L'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| ef+JKM      | Literal                                  | +                |
| ef+JKM      | Const in non-nested namespaced class     | +                |
| ef+JKM      | Const in nested namespaced class         | +                |
| ef+JKM      | Const in another class in same namespace | +                |
| ef+JKM      | Const in another namespace               | +                |
| ef+JKM      | Const in global class                    | +                |
| ef,JKM      | Literal                                  | ,                |
| ef,JKM      | Const in non-nested namespaced class     | ,                |
| ef,JKM      | Const in nested namespaced class         | ,                |
| ef,JKM      | Const in another class in same namespace | ,                |
| ef,JKM      | Const in another namespace               | ,                |
| ef,JKM      | Const in global class                    | ,                |
| ef-JKM      | Literal                                  | -                |
| ef-JKM      | Const in non-nested namespaced class     | -                |
| ef-JKM      | Const in nested namespaced class         | -                |
| ef-JKM      | Const in another class in same namespace | -                |
| ef-JKM      | Const in another namespace               | -                |
| ef-JKM      | Const in global class                    | -                |
| ef%JKL      | Literal                                  | L                |
| ef%JKL      | Const in non-nested namespaced class     | L                |
| ef%JKL      | Const in nested namespaced class         | L                |
| ef%JKL      | Const in another class in same namespace | L                |
| ef%JKL      | Const in another namespace               | L                |
| ef%JKL      | Const in global class                    | L                |

Scenario Outline: a non-match of a Modex for any character in a list starting with a character-range to minus
	Given an input string not containing '+' to '-', or 'L'
	When the input string is matched against a <TokenType> Modex property matching '+' to '-', or 'L'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex for any character in a list ending with a character-range from minus
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'T', or '-' to '0'
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | MatchedSubstring |
| RST(]+      | Literal                                  | T                |
| RST(]+      | Const in non-nested namespaced class     | T                |
| RST(]+      | Const in nested namespaced class         | T                |
| RST(]+      | Const in another class in same namespace | T                |
| RST(]+      | Const in another namespace               | T                |
| RST(]+      | Const in global class                    | T                |
| RSU(]-      | Literal                                  | -                |
| RSU(]-      | Const in non-nested namespaced class     | -                |
| RSU(]-      | Const in nested namespaced class         | -                |
| RSU(]-      | Const in another class in same namespace | -                |
| RSU(]-      | Const in another namespace               | -                |
| RSU(]-      | Const in global class                    | -                |
| RSU(]0      | Literal                                  | 0                |
| RSU(]0      | Const in non-nested namespaced class     | 0                |
| RSU(]0      | Const in nested namespaced class         | 0                |
| RSU(]0      | Const in another class in same namespace | 0                |
| RSU(]0      | Const in another namespace               | 0                |
| RSU(]0      | Const in global class                    | 0                |

Scenario Outline: a non-match of a Modex for any character in a list ending with a character-range from minus
	Given an input string not containing 'T', or '-' to '0'
	When the input string is matched against a <TokenType> Modex property matching 'T', or '-' to '0'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |
