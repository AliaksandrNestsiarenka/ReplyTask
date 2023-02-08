Feature: Reports

@tag1
Scenario: Run report
	  Given I am an admin user
	  When I log in
	  And I navigate to reports
	  And I open 'Project Profitability' report 
	  And I run the report 
	  Then Report's resuls are displayed

Scenario: Remove events from activity log
	  Given I am an admin user
	  When I log in
	  And I navigate to activity log
	  And I remove first 3 items
	  Then The items are not displayed
