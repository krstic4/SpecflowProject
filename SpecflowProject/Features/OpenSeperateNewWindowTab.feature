Feature: Seperate New window functionality

This feature cover tests for Open Seprate New Window tab

Background: 
	Given I navigate to application via url

@critical
Scenario: 1. Verify whole functionality of open new seperate window 
	When I click on Open Seprate New Window tab
	And I get text from Open New Seprate Window frame
	Then I verify text from frame is equal to Open New Seprate Window
	When I click on Open New Seprate Window in Frame
	Then I verify new window is opened via url https://www.way2automation.com/way2auto_jquery/frames-windows/defult2.html#
	And I verify Open New Seprate Window is displayed in new window
	When I close previously opened window
	Then I verify home page is displayed

@smoke
Scenario: 2. Verify text in frame from Open Seperate New Window
	When I click on Open Seprate New Window tab
	And I get text from Open New Seprate Window frame
	Then I verify text from frame is equal to Open New Seprate Window

@smoke
Scenario: 3. Verify new window is opened after click on text in frame
	When I click on Open Seprate New Window tab
	When I click on Open New Seprate Window in Frame
	Then I verify new window is opened via url https://www.way2automation.com/way2auto_jquery/frames-windows/defult2.html#
	And I verify Open New Seprate Window is displayed in new window

@smoke @ignore
Scenario: 4. Verify new window hyperlink opens new window [EXPECTED TO FAIL]
	When I click on Open Seprate New Window tab
	When I click on Open New Seprate Window in Frame
	Then I verify new window is opened via url https://www.way2automation.com/way2auto_jquery/frames-windows/defult2.html#
	And I verify Open New Seprate Window is displayed in new window
	Then I click on Open New Seprate Window in Frame
