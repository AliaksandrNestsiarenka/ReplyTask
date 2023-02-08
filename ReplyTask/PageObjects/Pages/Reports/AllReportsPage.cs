using OpenQA.Selenium;
using ReplyTask.PageObjects.Pages.AbstractPages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects.Pages.Reports
{
    public class AllReportsPage : AbstractMainPage
    {
        private string reportLinkItemLocatorPattern = "//a[@class = 'listViewNameLink' and text() = '{0}']";

        private By filterInputLocator = By.Id("filter_text");

        public AllReportsPage()
        {
            wait.Until(ExpectedConditions.UrlContains("Reports&action=index"));
        }
        
        public void FilterReports(string reportName)
        {
            IWebElement filterInputElement = driver.FindElement(filterInputLocator);
            filterInputElement.SendKeys(reportName);
            actions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(3000);
        }

        public ProjectReportsPage OpenReport(string reportName)
        {
            IWebElement element = driver.FindElement(By.XPath(string.Format(reportLinkItemLocatorPattern, reportName)));
            element.Click();
            Thread.Sleep(2000);

            return new ProjectReportsPage();
        }
    }
}
