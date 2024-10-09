Feature: Beginning

Beginning Modex

Scenario: a match of a Modex beginning
	Given an input string starting with at least 8 word characters
	When the input string is matched against a Modex property beginning with 4 word characters
	Then the Modex matches only the first 4 characters of the input string

Scenario: a non-match of a Modex beginning
	Given an input string starting with 3 word characters or fewer, then at least 1 non-word character, then at least 4 word characters
	When the input string is matched against a Modex property beginning with 4 word characters
	Then the Modex does not match
