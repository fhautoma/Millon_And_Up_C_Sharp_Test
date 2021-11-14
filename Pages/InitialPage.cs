using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NewDesignMillionAndUpTest.Hooks;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using NewDesignMillionAndUpTest.Utilities;
using System.Threading.Tasks;


namespace NewDesignMillionAndUpTest.Pages
{
    class InitialPage
    {
        readonly IWebDriver driver;
        private readonly Actions action;
        private readonly Constants constants;
        readonly WebDriverWait wait;
        readonly IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)Hook.driver;
        
        public InitialPage()
        {
            driver = Hook.driver;
            action = new Actions(driver);
            constants = new Constants();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(constants.WaitSeconds));
            
        }

        IWebElement scheduleButton => driver.FindElement(By.Id("addressBtn"));
        IWebElement scheduleDateContainer => driver.FindElement(By.XPath("//*[@class='input-icon mx-1']"));
        IWebElement rightCalendarArrow => driver.FindElement(By.XPath("//*[@class='fc-icon fc-icon-chevron-right']"));
        IList<IWebElement> calendarDays => driver.FindElements(By.XPath("//tr/td/div/div/a"));
        IList<IWebElement> hours => driver.FindElements(By.XPath("//*[@class='initial-time']"));
        IWebElement zoomCallButton => driver.FindElement(By.XPath("//*[@class='p-0 schedule-type schedule-type-right']"));
        IWebElement emailAddress => driver.FindElement(By.XPath("//*[@class='clean-txt email show-schedule']"));
        IWebElement sendSchedulePresentationButton => driver.FindElement(By.Id("btnSendModal"));
        string calendarTableXpath = "//*[@class='fc-scrollgrid-sync-table']";
        IWebElement nameTextBox => driver.FindElement(By.XPath("//*[@class='clean-txt show-schedule' and @id='name']"));
        IList<IWebElement> phoneNumberTextBox => driver.FindElements(By.XPath("//input[@type='tel' and @name='phone']"));
        IWebElement scheduledPresentationDay => driver.FindElement(By.XPath("//div[@class='d-flex align-items-center pr-m']/span[@class='schedule-response-day mt-n2 day-number']"));
        IWebElement scheduledPresentationMonth => driver.FindElement(By.XPath("//*[@class='schedule-response-bold ml-3 month']"));
        IWebElement scheduledPresentationHour => driver.FindElement(By.XPath("//*[@class='schedule-response-bold hour-init']"));
        string scheduleResponseDate = "//*[@class='schedule-response-date mx-0']";


        //This method opens the browser and ref to MillonAndUp initial page
        public void NavigateToWebSite(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        //This method executes a script to verify if the page is loaded and return a true or false value
        public bool PageLoadValidation()
        {
            return javaScriptExecutor.ExecuteScript("return document.readyState")
                .ToString() == "complete";
        }

        //This method makes scroll until the end of the page
        public void ScrollDownPage()
        {
            for(int i = 0; i < 2; i++)
            {
                action.SendKeys(Keys.End)
                    .Build()
                    .Perform();
                Thread.Sleep(800);
            }
        }

        //This method waits until the schedule button to be clickable and does click 
        public void ClickScheduleButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(scheduleButton));
            scheduleButton.Click();           
        }

        //This method waits until the 
        public void SelectDateTime(int month, int day, string hour)
        {
            DateProcessor dateProcessor = new DateProcessor();
            wait.Until(ExpectedConditions.ElementToBeClickable(scheduleDateContainer));
            scheduleDateContainer.Click();

            int clicks = dateProcessor.ClicksQuantityToSelectMonth(month, day);
            if(clicks > 0)
            {
                for (int i = 0; i < clicks; i++)
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(rightCalendarArrow));
                    rightCalendarArrow.Click();
                }
            } 
            else
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(rightCalendarArrow));
                rightCalendarArrow.Click();
            }

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(calendarTableXpath)));

            for(int i = 0; i < calendarDays.Count; i++)
            {
                if(calendarDays[i].Text == Convert.ToString(day))
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(calendarDays[i]));
                    calendarDays[i].Click();
                }
            }
            
            for(int i = 0; i < hours.Count; i++)
            {
                if(hours[i].Text == hour)
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(hours[i]));
                    hours[i].Click();
                }
            }
        }

        //This method
        public void ClickZoomCallButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(zoomCallButton));
            zoomCallButton.Click();
        }

        //This method
        public static async Task FillEmailAddress()
        {
            InitialPage initialPage = new InitialPage();
            var mockData = await MockDataProcessor.ProcessData();
            initialPage.emailAddress.SendKeys(mockData[0].EmailAddress);   
        }

        public void ClickSendSchedulePresentationButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(sendSchedulePresentationButton));
            sendSchedulePresentationButton.Click();
        }

        public static async Task FillContactInformation()
        {
            InitialPage initialPage = new InitialPage();
            var mockData = await MockDataProcessor.ProcessData();

            initialPage.nameTextBox.SendKeys(string.Format("{0} {1}", 
                mockData[0].FirstName, mockData[0].LastName));

            initialPage.phoneNumberTextBox[1].SendKeys(string.Format("{0}", 
                mockData[0].Phone));
        }

        public Dictionary<string, dynamic> ValidateScheduledPresentationData()
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(scheduleResponseDate)));

            var scheduledPresentationData = new Dictionary<string, dynamic>(){
                {"Day", Int32.Parse(scheduledPresentationDay.Text)},
                {"Month", string.Format("{0}", scheduledPresentationMonth.Text)},
                {"Hour", string.Format("{0}", scheduledPresentationHour.Text)} 
            };

            return scheduledPresentationData;
        }

    }
}
