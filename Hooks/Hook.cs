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
using OpenQA.Selenium.Remote;
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
        [Obsolete]
        public void BeforeScenario()
        {
            var userName = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            var accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");

            ChromeOptions options = new ChromeOptions();

            //options.AddArgument("incognito");  // ChromeOption to start chrome in incognito mode

            // Other capabilities are declared below
            options.AddAdditionalCapability("browser", "Chrome", true);
            options.AddAdditionalCapability("browser_version", "latest", true);
            options.AddAdditionalCapability("os", "Windows", true);
            options.AddAdditionalCapability("os_version", "10", true);
            options.AddAdditionalCapability("browserstack.user", "felipehenao2", true);
            options.AddAdditionalCapability("browserstack.key", "AEcZzcuK1nvH1QxSUnjR", true);
            options.AddAdditionalCapability("browserstack.timezone", "Bogota", true);
            //options.AddExcludedArgument("disable-popup-blocking", true);
            /*DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "10");
            capability.SetCapability("browser", "Chrome");
            capability.SetCapability("browser_version", "latest");
            capability.SetCapability("browserstack.local", "false");
            capability.SetCapability("browserstack.user", "felipehenao2");
            capability.SetCapability("browserstack.key", "AEcZzcuK1nvH1QxSUnjR");
            capability.SetCapability("browserstack.timezone", "Bogota");
            capability.SetCapability("browserstack.geoLocation", "CO");
            //capability.SetCapability("resolution", "1024x768");*/

            options.AddArguments("start-maximized");
            options.AddArguments("--incognito");
            //options.AddArguments("--disable-popup");
            //option.AddArguments("--headless");
            //option.AddArguments("--window-size=1280x1024");
            //option.AddArguments("--disable-gpu");

            /*option.AddAdditionalCapability("os", "Windows", true);
            option.AddAdditionalCapability("os_version", "10");
            option.AddAdditionalCapability("browser", "Chrome");
            option.AddAdditionalCapability("browser_version", "latest");
            option.AddAdditionalCapability("browserstack.local", "true");
            option.AddAdditionalCapability("browserstack.user", "felipehenao2");
            option.AddAdditionalCapability("browserstack.key", "AEcZzcuK1nvH1QxSUnjR");*/

            //new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), options);
            //driver.Manage().Window.Maximize();
            
            //driver = new ChromeDriver(options);           
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
