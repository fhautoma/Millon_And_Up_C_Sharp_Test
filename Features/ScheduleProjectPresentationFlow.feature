Feature: ScheduleProjectPresentationFlow
	Schedule A Project Presentation On A MillionAndUp Initial Page

Background: 
		Given Navigate to the website "https://newdesign.millionandup.com/"
		And Validate if the page is loaded

Scenario: Schedule Presentation
	Given I go to finish page
	And I make click to schedule a project presentation button
	And I select month 4 day 2 hour "1 PM"
	And I click zoom call button
	And I fill email address
	And I click schedule presentation button
	And I fill contact information
	When I click schedule presentation button
	Then I see a popup that contains correct project presentation data
