@all
Feature: Open New window functionality

This feature cover tests for Open New Window tab

Background: 
	Given I navigate to application via url

@critical
Scenario: 1. Verify whole functionality of open new window 
	When I click on Open New Window tab
	And I get text from Open New Window frame
	Then I verify text from frame is equal to New Browser Tab
	When I click on New Browser Tab in Frame
	Then I verify new tab is opened with url https://www.way2automation.com/way2auto_jquery/frames-windows/defult1.html#
	And I verify New Browser Tab text is displayed
	When I click on New Browser Tab in Frame
	Then I verify new tab is opened with url https://www.way2automation.com/way2auto_jquery/frames-windows/defult1.html#
	When I close previously opened tab
	Then I verify home page is displayed

@smoke
Scenario: 2. Verify text in frame from Open New Window tab
	When I click on Open New Window tab
	And I get text from Open New Window frame
	Then I verify text from frame is equal to New Browser Tab

@smoke
Scenario: 3. Verify new tab is opened after click on text in frame
	When I click on Open New Window tab
	When I click on New Browser Tab in Frame
	Then I verify new tab is opened with url https://www.way2automation.com/way2auto_jquery/frames-windows/defult1.html#
	