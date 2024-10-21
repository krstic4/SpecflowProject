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
	And I verify text in 1 window is Open Window-1
	And I verify text in 2 window is Open Window-2
	And I verify text in 3 window is Open Window-3
	And I verify url in 1 window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html
	And I verify url in 2 window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html
	And I verify url in 3 window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html
	When I click in 1 window on Open Window-1
	Then I verify text in 1 window is Open Window-1
	When I click in 2 window on Open Window-2
	Then I verify text in 2 window is Open Window-2
	When I click in 2 window on Open Window-3
	Then I verify text in 3 window is Open Window-3
	When I close all opened windows
	Then I verify home page is displayed


@smoke
Scenario: 2. Verify window 2 functionality
	When I click on Open Multiple Windows tab
	And I get text from Open Multiple Windows frame
	Then I verify text from frame is equal to Open multiple pages
	When I click on Open Multiple Pages in Frame
	Then I verify new windows are opened
	And I close all windows which are not 2
	And I verify text in 2 window is Open Window-2
	And I verify url in 2 window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window2.html
	When I click in 2 window on Open Window-2
	Then I verify new window 2 is opened
	And I verify text in 2 window is Open Window-2
	When I close all opened windows
	Then I verify home page is displayed


@smoke
Scenario: 3. Verify window 3 functionality
	When I click on Open Multiple Windows tab
	And I get text from Open Multiple Windows frame
	Then I verify text from frame is equal to Open multiple pages
	When I click on Open Multiple Pages in Frame
	Then I verify new windows are opened
	And I close all windows which are not 3
	And I verify text in 3 window is Open Window-3
	And I verify url in 3 window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window3.html
	When I click in 3 window on Open Window-3
	Then I verify new window 3 is opened
	And I verify text in 3 window is Open Window-3
	When I close all opened windows
	Then I verify home page is displayed

@smoke
Scenario: 4. Verify window 1 functionality
	When I click on Open Multiple Windows tab
	And I get text from Open Multiple Windows frame
	Then I verify text from frame is equal to Open multiple pages
	When I click on Open Multiple Pages in Frame
	Then I verify new windows are opened
	And I close all windows which are not 1
	And I verify text in 1 window is Open Window-1
	And I verify url in 1 window is https://www.way2automation.com/way2auto_jquery/frames-windows/defult4-window1.html
	When I click in 1 window on Open Window-1
	Then I verify new window 1 is opened
	And I verify text in 1 window is Open Window-1
	When I close all opened windows
	Then I verify home page is displayed


