using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReplyTask.Drivers;

namespace ReplyTask.Pages
{
    public abstract class AbstractCRMPageObject
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public AbstractCRMPageObject()
        {
            driver = DriverFactory.Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
