@ignore
Feature: ManualTests

This feature contains all manual tests which should be automated / keep this up-to-date 

Background: 
Given I navigate to application via url

@manual
Scenario: Verify Dynamic elements section in home page
	When Scroll down to the Dynamic elements section
	Then I verify Dynamic elements contains Submit button clicked, Dropdown
	When I click on Submit button clicked
	Then I verify new page is opened
	And I verify Starts tab is displayed
	And I verify input field is displayed
	And I verify submit button is displayed


@manual
Scenario: Verify Registration section in home page
	When Scroll down to the Registration section
	And I click on Registration
	Then I verify new page is opened
	And I verify Registration form is displayed

