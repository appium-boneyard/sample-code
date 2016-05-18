Feature:
	As a user
	I want to sum two numbers

Scenario: Sum two numbers
	Given I open the app
	When I wants to add number 5 and 9
	Then I should see the result is 14
	When I check the alert dialog
    Then I should see its content

