Feature: Example

Example test feature

@Local @NTR-364
Scenario: This should be an example
	Given this is an example
	When we validate that this is an example
	Then the validation result should confirm this is an example

@Internet @NTR-364
Scenario: example.com should be an example
	Given we surf to https://example.com
	When we view the page title
	Then we should see example