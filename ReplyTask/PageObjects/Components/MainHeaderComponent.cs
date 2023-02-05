using OpenQA.Selenium;
using ReplyTask.Drivers;
using ReplyTask.Enums;
using ReplyTask.Pages;

namespace ReplyTask.Components
{
    public class MainHeaderComponent : AbstractCRMPageObject
    {
        private string tabLocatorPattern = "//a[@id='grouptab-{0}']";

        public T ClickTab<T>(MainHeaderTab tab)
        {
            By tabLocator = By.XPath(string.Format(tabLocatorPattern, (int)tab));
            IWebElement tabElement = driver.FindElement(tabLocator);
            tabElement.Click();

            return Activator.CreateInstance<T>();
        }
    }
}
