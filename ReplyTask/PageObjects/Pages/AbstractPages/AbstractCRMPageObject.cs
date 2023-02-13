using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ReplyTask.Hooks;

namespace ReplyTask.PageObjects.Pages.AbstractPages
{
    public abstract class AbstractCRMPageObject
    {
        protected ScenarioContext scenarioContext;
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Actions actions;

        protected AbstractCRMPageObject(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            driver = scenarioContext.Get<IWebDriver>("WebDriver");
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
