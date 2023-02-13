using OpenQA.Selenium;
using ReplyTask.Drivers;
using ReplyTask.Enums;
using ReplyTask.Extensions;
using ReplyTask.PageObjects.Pages.AbstractPages;

namespace ReplyTask.PageObjects.Components
{
    public class SidebarMenuComponent : AbstractCRMPageObject
    {
        private string menuItemLocatorPattern = "//div[contains(@class, '{0}')]//ancestor::a";

        public SidebarMenuComponent(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        public T ClickSidebarItem<T>(SidebarMenuItem item)
        {
            var elementLocator = By.XPath(string.Format(menuItemLocatorPattern, item.GetDescription()));
            IWebElement element = driver.FindElement(elementLocator);
            element.Click();
            return (T)Activator.CreateInstance(typeof(T), scenarioContext);
        }
    }
}
