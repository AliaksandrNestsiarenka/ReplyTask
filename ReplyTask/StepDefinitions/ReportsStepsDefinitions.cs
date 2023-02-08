using NUnit.Framework;
using ReplyTask.Enums;
using ReplyTask.PageObjects.Pages.Reports;
using ReplyTask.PageObjects.Pages.TodaysActivities;

namespace ReplyTask.StepDefinitions
{
    [Binding]
    public sealed class ReportsStepsDefinitions
    {
        [When(@"I navigate to reports")]
        public void WhenINavigateToReports()
        {
            new HomeDashboardPage().MainHeader.ClickSubTab<AllReportsPage>(MainHeaderTab.ReportsAndSettings, MainHeaderSubTab.Reports);
        }

        [When(@"I open '([^']*)' report")]
        public void WhenIOpenReport(string reportName)
        {
            AllReportsPage allReportsPage = new AllReportsPage();
            allReportsPage.FilterReports(reportName);
            var projectReportsPage = allReportsPage.OpenReport(reportName);
        }

        [When(@"I run the report")]
        public void WhenIRunTheReport()
        {
            new ProjectReportsPage().RunReport();
        }

        [Then(@"Report's resuls are displayed")]
        public void ThenReportsResulsAreDisplayed()
        {
            bool areAnyItems = new ProjectReportsPage().GetReportResultsItems().Any();

            Assert.IsTrue(areAnyItems, "There are no results.");
        }
    }
}
