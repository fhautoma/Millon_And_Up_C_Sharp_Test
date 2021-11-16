using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace NewDesignMillionAndUpTest.Hooks
{
    [Binding]
    public class Hook
    {
        public static IWebDriver driver;
        ChromeOptions options = new ChromeOptions();

        [BeforeScenario("runBrowserStack") ]
        [Obsolete]
        public void BeforeScenario_runBrowserStack()
        {
            var userName = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            var accessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            options.AddAdditionalCapability("os", "Windows", true);
            options.AddAdditionalCapability("os_version", "10", true);
            options.AddAdditionalCapability("browser", "Chrome", true);
            options.AddAdditionalCapability("browser_version", "latest", true);
            options.AddExcludedArgument("disable-popup-blocking");
            options.AddAdditionalCapability("browserstack.user", "felipehenao2", true);
            options.AddAdditionalCapability("browserstack.key", "AEcZzcuK1nvH1QxSUnjR", true);
            options.AddArguments("start-maximized");
            options.AddArguments("--incognito");

            driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), options);
         
        }
        [BeforeScenario("runChromeLocal")]
        public void BeforeScenario_runChromeLocal()
        {
            options.AddArguments("start-maximized");
            options.AddArguments("--incognito");
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(options);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Dispose();            
        }


    }
}
