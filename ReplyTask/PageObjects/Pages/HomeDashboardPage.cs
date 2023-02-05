using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.Pages
{
    public class HomeDashboardPage : AbstractMainPage
    {
        private By mainTitleLocator = By.Id("main-title");

        public HomeDashboardPage()
        {
            wait.Until(ExpectedConditions.ElementExists(mainTitleLocator));
        }

        public IWebElement mainTitle => driver.FindElement(mainTitleLocator);
    }
}