Feature: End

End Modex

Scenario: a match of a Modex ending with 5 non-whitespace characters
	Given an input string ending with at least 10 non-whitespace characters
	When the input string is matched against a Modex property ending with 5 non-whitespace characters
	Then the Modex matches only the last 5 characters of the input string

Scenario: a non-match of a Modex ending with 5 non-whitespace characters
	Given an input string containing at least 5 non-whitespace characters, then at least 1 whitespace character, then ending with 4 non-whitespace characters or fewer
	When the input string is matched against a Modex property ending with 5 non-whitespace characters
	Then the Modex does not match
