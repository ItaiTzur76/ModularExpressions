Feature: Implicit

Implicit Modex

Scenario Outline: a match of a Modex from a string containing a dot
	Given 'a$A.B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A.B'
	Then the Modex matches 'A.B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a dot
	Given 'a$A_B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A.B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a plus
	Given 'a$A+B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A+B'
	Then the Modex matches 'A+B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a plus
	Given 'a$AAB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A+B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing an asterisk
	Given 'a$A*B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A*B'
	Then the Modex matches 'A*B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing an asterisk
	Given 'a$AAB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A*B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a question Mark
	Given 'a$A?B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A?B'
	Then the Modex matches 'A?B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a question Mark
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A?B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string starting with a caret
	Given '^a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching '^a'
	Then the Modex matches '^a'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string starting with a caret
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching '^a'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string ending with a dollar
	Given 'a$AB8_$' as an input string
	When the input string is matched against a <TokenType> Modex property matching '_$'
	Then the Modex matches '_$'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string ending with a dollar
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching '_$'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a left parenthesis
	Given 'a$A(B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A(B'
	Then the Modex matches 'A(B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a left parenthesis
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A(B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a right parenthesis
	Given 'a$A)B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A)B'
	Then the Modex matches 'A)B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a right parenthesis
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A)B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a left bracket
	Given 'a$A[B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A[B'
	Then the Modex matches 'A[B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a left bracket
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A[B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a right bracket
	Given 'a$A]B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A]B'
	Then the Modex matches 'A]B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a right bracket
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A]B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a left brace
	Given 'a$A{B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A{B'
	Then the Modex matches 'A{B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a left brace
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A{B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a right brace
	Given 'a$A}B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A}B'
	Then the Modex matches 'A}B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a right brace
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A}B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a match of a Modex from a string containing a vertical bar
	Given 'a$A|B8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A|B'
	Then the Modex matches 'A|B'
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |

Scenario Outline: a non-match of a Modex from a string containing a vertical bar
	Given 'a$AB8_' as an input string
	When the input string is matched against a <TokenType> Modex property matching 'A|B'
	Then the Modex does not match
Examples:
| TokenType                                |
| Literal                                  |
| Const in non-nested namespaced class     |
| Const in nested namespaced class         |
| Const in another class in same namespace |
| Const in another namespace               |
| Const in global class                    |
