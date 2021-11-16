using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using NewDesignMillionAndUpTest.Pages;
using System.Threading.Tasks;
using System.Collections.Generic;
using NewDesignMillionAndUpTest.Utilities;

namespace NewDesignMillionAndUpTest.Features
{
    [Binding]
    public class ScheduleProjectPresentationFlowSteps
    {
        ScenarioContext _scenarioContext;

        public ScheduleProjectPresentationFlowSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        InitialPage initialPage = new InitialPage();
        
        [Given(@"Navigate to the website ""(.*)""")]
        public void GivenNavigateToTheWebsite(string url)
        {
            initialPage.NavigateToWebSite(url);
        }
        
        [Given(@"Validate if the page is loaded")]
        public void GivenWaitUntilThePageIsLoaded()
        {
            Assert.IsTrue(initialPage.PageLoadValidation());
        }
        
        [Given(@"I go to finish page")]
        public void GivenIGoToFinishPage()
        {
            initialPage.ScrollDownPage();

        }
        
        [Given(@"I make click to schedule a project presentation button")]
        public void GivenIMakeClickToScheduleAProjectPresentationButton()
        {
            initialPage.ClickScheduleButton();
        }
        
        [Given(@"I select month (.*) day (.*) hour ""(.*)""")]
        public void GivenISelectDateTime(int month, int day, string hour)
        {
            _scenarioContext.Add("SelectMonth", month);
            _scenarioContext.Add("SelectDay", day);
            _scenarioContext.Add("SelectHour", hour);

            initialPage.SelectDateTime(month, day, hour);
        }
        
        [Given(@"I click zoom call button")]
        public void GivenIClickZoomCallButton()
        {
            initialPage.ClickZoomCallButton();
        }

        [Given(@"I fill email address")]
        public static async Task GivenIFillEmailAddress()
        {
            await Task.Run(() => InitialPage.FillEmailAddress());          
        }
        
        [Given(@"I click schedule presentation button")]
        public void GivenIClickSchedulePresentationButton()
        {
            initialPage.ClickSendSchedulePresentationButton();
        }
        
        [Given(@"I fill contact information")]
        public static async Task GivenIFillContactInformation()
        {
            await Task.Run(() => InitialPage.FillContactInformation());
        }
        
        [When(@"I click schedule presentation button")]
        public void WhenIClickSchedulePresentationButton()
        {
            initialPage.ClickSendSchedulePresentationButton();
        }
        
        [Then(@"I see a popup that contains correct project presentation data")]
        public void ThenISeeAPopupThatContainsCorrectProjectPresentationData()
        {
            DateProcessor dateProcessor = new DateProcessor();
            var scheduledPresentationData = new Dictionary<string, dynamic>(initialPage.ValidateScheduledPresentationData());
            
            var actualMonthValue = scheduledPresentationData.GetValueOrDefault("Month");    
            var expectMonthValue = dateProcessor.MonthConverter(_scenarioContext.Get<int>("SelectMonth"));
            Assert.AreEqual(expectMonthValue, actualMonthValue);

            var actualDayValue = scheduledPresentationData.GetValueOrDefault("Day");
            var expectDayValue = _scenarioContext.Get<int>("SelectDay");
            Assert.AreEqual(expectDayValue, actualDayValue);

            var actualHourValue = scheduledPresentationData.GetValueOrDefault("Hour");
            var expectHourValue = _scenarioContext.Get<string>("SelectHour");
            Assert.AreEqual(expectHourValue, actualHourValue);

        }
    }
}
