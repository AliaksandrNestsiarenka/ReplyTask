using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace ReplyTask.Drivers
{
    public class DriverFactory
    {
        private static IWebDriver? driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitDriver(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    if (driver == null)
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        Driver = new ChromeDriver();
                    }
                    break;
            }
        }

        public static void QuiteDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
