Feature: Tab

Tab Modex

Scenario: a match of a tab Modex
	Given an input string containing a tab character
	When the input string is matched against a tab Modex property
	Then the Modex matches

Scenario: a non-match of a tab Modex
	Given an input string not containing a tab character
	When the input string is matched against a tab Modex property
	Then the Modex does not match
