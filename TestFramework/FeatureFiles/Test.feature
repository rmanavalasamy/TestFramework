Feature: Test
	Simple calculator for adding two numbers

@smoke
Scenario: Verify DropDown
	Given I navigate to the site
	When I click "Dropdown" link
	And I select the "Option 1" text from the dropdown
	Then the "Option 1" in dropdown should have been selected
