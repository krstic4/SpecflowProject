@all
Feature: Frameset functionality

This feature cover tests for Frameset tab

Background: 
	Given I navigate to application via url

@critical
Scenario: 1. Verify whole functionality of frameset 
	When I click on Frameset tab
	And I get text from Open Frameset Window frame
	Then I verify text from frame is equal to Open Frameset Window
	When I click on Open Frameset Window in Frame
	Then I verify new tab is opened with url https://www.way2automation.com/way2auto_jquery/frames-windows/frameset.html
	And I verify first and second frames are displayed
	And I verify in first frame Title is www.way2automation.com
	And I verify in first frame Content is matching	
	And I verify in second frame Title is www.way2automation.com
	And I verify in second frame Content is matching
	When I close previously opened tab
	Then I verify home page is displayed

@smoke
Scenario: 2. Verify text in frame from Frameset tab
	When I click on Frameset tab
	And I get text from Open Frameset Window frame
	Then I verify text from frame is equal to Open Frameset Window

@smoke
Scenario: 3. Verify titles and contents inside frame from new Frame tab
	When I click on Frameset tab
	When I click on Open Frameset Window in Frame
	And I wait for frame to load
	Then I verify in first frame Title is www.way2automation.com
	And I verify in first frame Content is matching	
	And I verify in second frame Title is www.way2automation.com
	And I verify in second frame Content is matching