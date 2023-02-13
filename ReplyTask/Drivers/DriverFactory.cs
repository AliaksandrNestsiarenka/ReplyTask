using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using NUnit.Framework;

namespace ReplyTask.Drivers
{
    public class DriverFactory
    {
        private IWebDriver? driver;
        private ScenarioContext _scenarioContext;

        public DriverFactory(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public void InitDriver(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    if (driver == null)
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        _scenarioContext.Set(driver, "WebDriver");
                    }
                    break;
            }
        }

        public void QuiteDriver()
        {
            if (driver != null)
            {
                _scenarioContext.Get<IWebDriver>("WebDriver").Quit();
            }
        }
    }
}
