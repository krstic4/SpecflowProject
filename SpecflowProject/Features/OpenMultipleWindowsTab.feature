@all
Feature: Open Multiple windows

This feature cover tests for Open Multiple windows tab

Background: 
	Given I navigate to application via url

@critical
Scenario: 1. Verify whole functionality of open multiple windows
	When I click on Open Multiple Windows tab
	And I get text from Open Multiple Windows frame
	Then I verify text from frame is equal to Open multiple pages
	When I click on Open Multiple Pages in Frame
	Then I verify new windows are opened
	And I verify text in first opened instance window is Open Window-1
	And I verify url in first opened instance window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html
	When I click in first opened instance window on Open Window-1
	Then I verify text in second instance of first browser window is Open Window-1
	And I verify url in second instance of first browser window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html#
	Then I close all window of first opened instance

	And I verify text in second opened instance window is Open Window-2
	And I verify url in second opened instance window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html
	When I click in second opened instance window on Open Window-2
	Then I verify text in second instance of second browser window is Open Window-2
	And I verify url in second instance of second browser window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html#
	Then I close all window of second opened instance

	And I verify text in third opened instance window is Open Window-3
	And I verify url in third opened instance window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html
	When I click in third opened instance window on Open Window-3
	Then I verify text in second instance of third browser window is Open Window-3
	And I verify url in second instance of third browser window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html#
	Then I close all window of second instance of third browser

	When I close all opened windows
	Then I verify home page is displayed


@smoke
Scenario: 2. Verify window 2 functionality
	When I click on Open Multiple Windows tab
	And I get text from Open Multiple Windows frame
	Then I verify text from frame is equal to Open multiple pages
	When I click on Open Multiple Pages in Frame
	Then I verify new windows are opened
	And I close all windows which are not second opened instance
	And I verify text in second opened instance window is Open Window-2
	And I verify url in second opened instance window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html
	When I click in second opened instance window on Open Window-2
	Then I verify text in second instance of second browser window is Open Window-2
	And I verify url in second instance of second browser window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html#
	When I close all opened windows
	Then I verify home page is displayed


@smoke
Scenario: 3. Verify window 3 functionality
	When I click on Open Multiple Windows tab
	And I get text from Open Multiple Windows frame
	Then I verify text from frame is equal to Open multiple pages
	When I click on Open Multiple Pages in Frame
	Then I verify new windows are opened
	And I close all windows which are not third opened instance
	And I verify text in third opened instance window is Open Window-3
	And I verify url in third opened instance window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html
	When I click in third opened instance window on Open Window-3
	Then I verify text in second instance of third browser window is Open Window-3
	And I verify url in second instance of third browser window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html#
	When I close all opened windows
	Then I verify home page is displayed

@smoke
Scenario: 4. Verify window 1 functionality
	When I click on Open Multiple Windows tab
	And I get text from Open Multiple Windows frame
	Then I verify text from frame is equal to Open multiple pages
	When I click on Open Multiple Pages in Frame
	Then I verify new windows are opened
	And I close all windows which are not first opened instance
	And I verify text in first opened instance window is Open Window-1
	And I verify url in first opened instance window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html
	When I click in first opened instance window on Open Window-1
	Then I verify text in second instance of first browser window is Open Window-1
	And I verify url in second instance of first browser window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html#
	When I close all opened windows
	Then I verify home page is displayed


