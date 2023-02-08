using NUnit.Framework;
using OpenQA.Selenium;
using ReplyTask.PageObjects.Items;
using ReplyTask.PageObjects.Pages.AbstractPages;

namespace ReplyTask.PageObjects.Pages.Reports
{
    public class ActivityLogPage : AbstractMainPage
    {
        private By ActivityLogItemLocator = By.XPath("//tr[@data-id]");
        private By ActionsButtonLocator = By.XPath("//button[contains(@id, 'ActionButtonHead')]");
        private By DeleteOptionLocator = By.XPath("//div[text()='Delete']");
    
        public List<ActivityLogItem> GetActivityLogItems()
        {
            List<ActivityLogItem> items = new List<ActivityLogItem>();
            List<IWebElement> elements = driver.FindElements(ActivityLogItemLocator).ToList();
            
            foreach(var element in elements)
            {
                items.Add(new ActivityLogItem(element));
            }

            return items;
        }

        public void DeleteItems(int numberOfElements)
        {
            Thread.Sleep(2000);
            List<ActivityLogItem> items = GetActivityLogItems();

            for (int i = 0; i < numberOfElements; i++)
            {
                items.ElementAt(i).Check();
            }

            driver.FindElement(ActionsButtonLocator).Click();
            driver.FindElement(DeleteOptionLocator).Click();
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
