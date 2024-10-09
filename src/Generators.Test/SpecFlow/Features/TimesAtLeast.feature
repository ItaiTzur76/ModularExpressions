Feature: TimesAtLeast

TimesAtLeast Modex

Scenario Outline: a match of a Modex for 3 or more non-digits
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 3 or more <SubexpressionType> non-digits
	Then the Modex matches '<MatchedSubstring>'
Examples:
| InputString | TokenType                                | SubexpressionType | MatchedSubstring |
| wTx4567     | Literal                                  | Direct            | wTx              |
| wTx4567     | Const in non-nested namespaced class     | Direct            | wTx              |
| wTx4567     | Const in nested namespaced class         | Direct            | wTx              |
| wTx4567     | Const in another class in same namespace | Direct            | wTx              |
| wTx4567     | Const in another namespace               | Direct            | wTx              |
| wTx4567     | Const in global class                    | Direct            | wTx              |
| wTx4567     | Literal                                  | Indirect          | wTx              |
| wTx4567     | Const in non-nested namespaced class     | Indirect          | wTx              |
| wTx4567     | Const in nested namespaced class         | Indirect          | wTx              |
| wTx4567     | Const in another class in same namespace | Indirect          | wTx              |
| wTx4567     | Const in another namespace               | Indirect          | wTx              |
| wTx4567     | Const in global class                    | Indirect          | wTx              |
| wTx_567     | Literal                                  | Direct            | wTx_             |
| wTx_567     | Const in non-nested namespaced class     | Direct            | wTx_             |
| wTx_567     | Const in nested namespaced class         | Direct            | wTx_             |
| wTx_567     | Const in another class in same namespace | Direct            | wTx_             |
| wTx_567     | Const in another namespace               | Direct            | wTx_             |
| wTx_567     | Const in global class                    | Direct            | wTx_             |
| wTx_567     | Literal                                  | Indirect          | wTx_             |
| wTx_567     | Const in non-nested namespaced class     | Indirect          | wTx_             |
| wTx_567     | Const in nested namespaced class         | Indirect          | wTx_             |
| wTx_567     | Const in another class in same namespace | Indirect          | wTx_             |
| wTx_567     | Const in another namespace               | Indirect          | wTx_             |
| wTx_567     | Const in global class                    | Indirect          | wTx_             |
| wTx_A67     | Literal                                  | Direct            | wTx_A            |
| wTx_A67     | Const in non-nested namespaced class     | Direct            | wTx_A            |
| wTx_A67     | Const in nested namespaced class         | Direct            | wTx_A            |
| wTx_A67     | Const in another class in same namespace | Direct            | wTx_A            |
| wTx_A67     | Const in another namespace               | Direct            | wTx_A            |
| wTx_A67     | Const in global class                    | Direct            | wTx_A            |
| wTx_A67     | Literal                                  | Indirect          | wTx_A            |
| wTx_A67     | Const in non-nested namespaced class     | Indirect          | wTx_A            |
| wTx_A67     | Const in nested namespaced class         | Indirect          | wTx_A            |
| wTx_A67     | Const in another class in same namespace | Indirect          | wTx_A            |
| wTx_A67     | Const in another namespace               | Indirect          | wTx_A            |
| wTx_A67     | Const in global class                    | Indirect          | wTx_A            |
| wTx_Aq7     | Literal                                  | Direct            | wTx_Aq           |
| wTx_Aq7     | Const in non-nested namespaced class     | Direct            | wTx_Aq           |
| wTx_Aq7     | Const in nested namespaced class         | Direct            | wTx_Aq           |
| wTx_Aq7     | Const in another class in same namespace | Direct            | wTx_Aq           |
| wTx_Aq7     | Const in another namespace               | Direct            | wTx_Aq           |
| wTx_Aq7     | Const in global class                    | Direct            | wTx_Aq           |
| wTx_Aq7     | Literal                                  | Indirect          | wTx_Aq           |
| wTx_Aq7     | Const in non-nested namespaced class     | Indirect          | wTx_Aq           |
| wTx_Aq7     | Const in nested namespaced class         | Indirect          | wTx_Aq           |
| wTx_Aq7     | Const in another class in same namespace | Indirect          | wTx_Aq           |
| wTx_Aq7     | Const in another namespace               | Indirect          | wTx_Aq           |
| wTx_Aq7     | Const in global class                    | Indirect          | wTx_Aq           |

Scenario Outline: a non-match of a Modex for 3 or more non-digits
	Given 'wT34567' as an input string
	When the input string is matched against a <TokenType> Modex property matching 3 or more <SubexpressionType> non-digits
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
