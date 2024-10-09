Feature: Times

Times Modex

Scenario Outline: a match of a Modex for 3 word characters
	Given '<InputString>' as an input string
	When the input string is matched against a <TokenType> Modex property matching 3 <SubexpressionType> word characters
	Then the Modex matches 'a_8'
Examples:
| InputString | TokenType                                | SubexpressionType |
| a_8$^Su     | Literal                                  | Direct            |
| a_8$^Su     | Const in non-nested namespaced class     | Direct            |
| a_8$^Su     | Const in nested namespaced class         | Direct            |
| a_8$^Su     | Const in another class in same namespace | Direct            |
| a_8$^Su     | Const in another namespace               | Direct            |
| a_8$^Su     | Const in global class                    | Direct            |
| a_8$^Su     | Literal                                  | Indirect          |
| a_8$^Su     | Const in non-nested namespaced class     | Indirect          |
| a_8$^Su     | Const in nested namespaced class         | Indirect          |
| a_8$^Su     | Const in another class in same namespace | Indirect          |
| a_8$^Su     | Const in another namespace               | Indirect          |
| a_8$^Su     | Const in global class                    | Indirect          |
| a_8B^Su     | Literal                                  | Direct            |
| a_8B^Su     | Const in non-nested namespaced class     | Direct            |
| a_8B^Su     | Const in nested namespaced class         | Direct            |
| a_8B^Su     | Const in another class in same namespace | Direct            |
| a_8B^Su     | Const in another namespace               | Direct            |
| a_8B^Su     | Const in global class                    | Direct            |
| a_8B^Su     | Literal                                  | Indirect          |
| a_8B^Su     | Const in non-nested namespaced class     | Indirect          |
| a_8B^Su     | Const in nested namespaced class         | Indirect          |
| a_8B^Su     | Const in another class in same namespace | Indirect          |
| a_8B^Su     | Const in another namespace               | Indirect          |
| a_8B^Su     | Const in global class                    | Indirect          |

Scenario Outline: a non-match of a Modex for 3 word characters
	Given 'a_@$^Su' as an input string
	When the input string is matched against a <TokenType> Modex property matching 3 <SubexpressionType> word characters
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
