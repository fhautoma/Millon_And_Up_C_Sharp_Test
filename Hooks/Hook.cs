using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow.Infrastructure;
using Ninject;

namespace NewDesignMillionAndUpTest.Hooks
{
    [Binding]
    public class Hook
    {
        public static IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--incognito");
            option.AddArguments("--headless");
            option.AddArguments("--disable-gpu");

            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(option);           
        }
        /*
        [AfterStep()]
        public void TakeScreenAfterStep()
        {
            if(driver.Current is ITakesScreenshot takesScreenshot)
            {

            }
        }
        */

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Dispose();            
        }


    }
}
