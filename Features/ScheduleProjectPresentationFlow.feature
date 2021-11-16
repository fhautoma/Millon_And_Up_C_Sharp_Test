Feature: ScheduleProjectPresentationFlow
	Schedule A Project Presentation On A MillionAndUp Initial Page

Background: 
		Given Navigate to the website "https://newdesign.millionandup.com/"
		And Validate if the page is loaded
#@runBrowserStack
@runChromeLocal
Scenario: Schedule Presentation
	Given I go to finish page
	* I make click to schedule a project presentation button
	* I select month 2 day 2 hour "1 PM"
	* I fill email address
	* I click zoom call button
	* I click schedule presentation button
	* I fill contact information
	When I click schedule presentation button
	Then I see a popup that contains correct project presentation data
