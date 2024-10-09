Feature: TimesBetween

TimesBetween Modex

Scenario Outline: a match of a Modex for 3 to 5 non-word characters
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 3 to 5 <SubexpressionType> non-word characters
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | SubexpressionType | MatchedSubstring |
| (@+4567     | Literal                                  | Direct            | (@+              |
| (@+4567     | Const in non-nested namespaced class     | Direct            | (@+              |
| (@+4567     | Const in nested namespaced class         | Direct            | (@+              |
| (@+4567     | Const in another class in same namespace | Direct            | (@+              |
| (@+4567     | Const in another namespace               | Direct            | (@+              |
| (@+4567     | Const in global class                    | Direct            | (@+              |
| (@+4567     | Literal                                  | Indirect          | (@+              |
| (@+4567     | Const in non-nested namespaced class     | Indirect          | (@+              |
| (@+4567     | Const in nested namespaced class         | Indirect          | (@+              |
| (@+4567     | Const in another class in same namespace | Indirect          | (@+              |
| (@+4567     | Const in another namespace               | Indirect          | (@+              |
| (@+4567     | Const in global class                    | Indirect          | (@+              |
| (@+!567     | Literal                                  | Direct            | (@+!             |
| (@+!567     | Const in non-nested namespaced class     | Direct            | (@+!             |
| (@+!567     | Const in nested namespaced class         | Direct            | (@+!             |
| (@+!567     | Const in another class in same namespace | Direct            | (@+!             |
| (@+!567     | Const in another namespace               | Direct            | (@+!             |
| (@+!567     | Const in global class                    | Direct            | (@+!             |
| (@+!567     | Literal                                  | Indirect          | (@+!             |
| (@+!567     | Const in non-nested namespaced class     | Indirect          | (@+!             |
| (@+!567     | Const in nested namespaced class         | Indirect          | (@+!             |
| (@+!567     | Const in another class in same namespace | Indirect          | (@+!             |
| (@+!567     | Const in another namespace               | Indirect          | (@+!             |
| (@+!567     | Const in global class                    | Indirect          | (@+!             |
| (@+!.67     | Literal                                  | Direct            | (@+!.            |
| (@+!.67     | Const in non-nested namespaced class     | Direct            | (@+!.            |
| (@+!.67     | Const in nested namespaced class         | Direct            | (@+!.            |
| (@+!.67     | Const in another class in same namespace | Direct            | (@+!.            |
| (@+!.67     | Const in another namespace               | Direct            | (@+!.            |
| (@+!.67     | Const in global class                    | Direct            | (@+!.            |
| (@+!.67     | Literal                                  | Indirect          | (@+!.            |
| (@+!.67     | Const in non-nested namespaced class     | Indirect          | (@+!.            |
| (@+!.67     | Const in nested namespaced class         | Indirect          | (@+!.            |
| (@+!.67     | Const in another class in same namespace | Indirect          | (@+!.            |
| (@+!.67     | Const in another namespace               | Indirect          | (@+!.            |
| (@+!.67     | Const in global class                    | Indirect          | (@+!.            |
| (@+!.,7     | Literal                                  | Direct            | (@+!.            |
| (@+!.,7     | Const in non-nested namespaced class     | Direct            | (@+!.            |
| (@+!.,7     | Const in nested namespaced class         | Direct            | (@+!.            |
| (@+!.,7     | Const in another class in same namespace | Direct            | (@+!.            |
| (@+!.,7     | Const in another namespace               | Direct            | (@+!.            |
| (@+!.,7     | Const in global class                    | Direct            | (@+!.            |
| (@+!.,7     | Literal                                  | Indirect          | (@+!.            |
| (@+!.,7     | Const in non-nested namespaced class     | Indirect          | (@+!.            |
| (@+!.,7     | Const in nested namespaced class         | Indirect          | (@+!.            |
| (@+!.,7     | Const in another class in same namespace | Indirect          | (@+!.            |
| (@+!.,7     | Const in another namespace               | Indirect          | (@+!.            |
| (@+!.,7     | Const in global class                    | Indirect          | (@+!.            |

Scenario Outline: a non-match of a Modex for 3 to 5 non-word characters
	Given '(@34567' as an input string
	When the input string is matched against a <TokenType> Modex property matching 3 to 5 <SubexpressionType> non-word characters
	Then the Modex does not match
Examples:
| TokenType                                | SubexpressionType |
| Literal                                  | Direct            |
| Const in non-nested namespaced class     | Direct            |
| Const in nested namespaced class         | Direct            |
| Const in another class in same namespace | Direct            |
| Const in another namespace               | Direct            |
| Const in global class                    | Direct            |
| Literal                                  | Indirect          |
| Const in non-nested namespaced class     | Indirect          |
| Const in nested namespaced class         | Indirect          |
| Const in another class in same namespace | Indirect          |
| Const in another namespace               | Indirect          |
| Const in global class                    | Indirect          |
