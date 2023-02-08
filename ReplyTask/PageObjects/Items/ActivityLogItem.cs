using OpenQA.Selenium;

namespace ReplyTask.PageObjects.Items
{
    public class ActivityLogItem
    {
        private IWebElement rootElement;
        private By CheckBoxLocator = By.XPath(".//input[@type = 'checkbox' and not(@id)]");
        private By DetailLinkLocator = By.XPath(".//span[@class='detailLink' and not(@id)]//a[@class = 'listViewExtLink']");

        public bool Displayed => rootElement.Displayed;

        public ActivityLogItem(IWebElement element)
        {
            rootElement = element;
        }

        public void Check()
        {
            rootElement.FindElement(CheckBoxLocator).Click();
        }

        public string GetElementText()
        {
            return rootElement.FindElement(DetailLinkLocator).Text;
        }
    }
}
