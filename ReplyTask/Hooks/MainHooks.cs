using OpenQA.Selenium;
using ReplyTask.Drivers;

namespace ReplyTask.Hooks
{
    [Binding]
    public sealed class MainHooks
    {
        private IWebDriver? driver; 

        [BeforeScenario()]
        public void BeforeScenarioWithTag()
        {
            DriverFactory.InitDriver("Chrome");
            driver = DriverFactory.Driver;
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                DriverFactory.QuiteDriver();
            }
        }
    }
}