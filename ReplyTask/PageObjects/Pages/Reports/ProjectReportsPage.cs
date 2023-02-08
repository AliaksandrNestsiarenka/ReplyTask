using OpenQA.Selenium;
using ReplyTask.PageObjects.Pages.AbstractPages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects.Pages.Reports
{
    public class ProjectReportsPage : AbstractMainPage
    {
        private By runReportButtonLocator = By.XPath("//span[text() = 'Run Report']//parent::button");
        private By reportResultsItemLocator = By.XPath("//table[@class='listView']//tr[@data-id]");

        public IWebElement RunReportButton;

        public ProjectReportsPage()
        {
            RunReportButton = wait.Until(ExpectedConditions.ElementIsVisible(runReportButtonLocator));
        }

        public void RunReport()
        {
            RunReportButton.Click();
            Thread.Sleep(3000);
        }

        public List<IWebElement> GetReportResultsItems()
        {
            return driver.FindElements(reportResultsItemLocator).ToList();
        }
    }
}
