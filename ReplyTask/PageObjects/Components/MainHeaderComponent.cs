using OpenQA.Selenium;
using ReplyTask.Drivers;
using ReplyTask.Enums;
using ReplyTask.Extensions;
using ReplyTask.PageObjects.Pages.AbstractPages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.Components
{
    public class MainHeaderComponent : AbstractCRMPageObject
    {
        private string tabLocatorPattern = "//a[@id='grouptab-{0}']";
        private string subLocatorPattern = "//a[@class = 'menu-tab-sub-list' and text()= ' {0}']";
  
        public T ClickSubTab<T>(MainHeaderTab tab, MainHeaderSubTab tabTab)
        {
            By tabLocator = By.XPath(string.Format(tabLocatorPattern, (int)tab));
            IWebElement tabElement = driver.FindElement(tabLocator);
            actions.MoveToElement(tabElement).Perform();
            IWebElement subTabElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(String.Format(subLocatorPattern, tabTab.GetDescription()))));
            subTabElement.Click();
            return Activator.CreateInstance<T>();
        }
    }
}
