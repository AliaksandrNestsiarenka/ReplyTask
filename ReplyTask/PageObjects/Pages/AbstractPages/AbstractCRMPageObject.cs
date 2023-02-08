using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ReplyTask.Drivers;

namespace ReplyTask.PageObjects.Pages.AbstractPages
{
    public abstract class AbstractCRMPageObject
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Actions actions;

        public AbstractCRMPageObject()
        {
            driver = DriverFactory.Driver;
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
