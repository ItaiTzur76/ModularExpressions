Feature: NamedGroup

NamedGroup Modex

Scenario Outline: a match of a Modex for a named digit
	Given '_$R7e `' as an input string
	When the input string is matched against a <TokenType> Modex property matching a digit with the <SubexpressionType> name 'myDigitGroup'
	Then the Modex matches '7' as 'myDigitGroup'
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

Scenario Outline: a non-match of a Modex for a named digit
	Given '_$R&e `' as an input string
	When the input string is matched against a <TokenType> Modex property matching a digit with the <SubexpressionType> name 'myDigitGroup'
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
