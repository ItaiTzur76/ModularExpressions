Feature: Source Generation

Modex source generated in various types

Scenario: a match of a Modex generated in a generic
	Given an input string containing a digit
	When the input string is matched against a digit Modex declared in a generic
	Then the Modex matches

Scenario: a non-match of a Modex generated in a generic
	Given an input string not containing a digit
	When the input string is matched against a digit Modex declared in a generic
	Then the Modex does not match

Scenario: a match of a Modex generated in a global class
	Given an input string containing a digit
	When the input string is matched against a digit Modex declared in a global class
	Then the Modex matches

Scenario: a non-match of a Modex generated in a global class
	Given an input string not containing a digit
	When the input string is matched against a digit Modex declared in a global class
	Then the Modex does not match

Scenario: a match of a Modex declared and generated in a partial class spread over two different files
	Given an input string containing a digit
	When the input string is matched against a digit Modex declared and generated in a partial class spread over two different files
	Then the Modex matches

Scenario: a non-match of a Modex declared and generated in a partial class spread over two different files
	Given an input string not containing a digit
	When the input string is matched against a digit Modex declared and generated in a partial class spread over two different files
	Then the Modex does not match

Scenario: a match of a Modex generated in a statically-used class
	Given an input string containing a digit
	When the input string is matched against a digit Modex declared in a statically-used class
	Then the Modex matches

Scenario: a non-match of a Modex generated in a statically-used class
	Given an input string not containing a digit
	When the input string is matched against a digit Modex declared in a statically-used class
	Then the Modex does not match
