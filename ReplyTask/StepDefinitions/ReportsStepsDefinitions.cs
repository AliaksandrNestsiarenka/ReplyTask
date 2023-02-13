using NUnit.Framework;
using ReplyTask.Enums;
using ReplyTask.PageObjects.Items;
using ReplyTask.PageObjects.Pages.Reports;
using ReplyTask.PageObjects.Pages.TodaysActivities;

namespace ReplyTask.StepDefinitions
{
    [Binding]
    public sealed class ReportsStepsDefinitions
    {
        private List<ActivityLogItem> activityLogItemsToBeDeleted;
        private List<string> deletedActivityLogItemsContent;

        private ScenarioContext _scenarioContext;

        public ReportsStepsDefinitions(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I navigate to reports")]
        public void WhenINavigateToReports()
        {
            new HomeDashboardPage(_scenarioContext).MainHeader.ClickSubTab<AllReportsPage>(MainHeaderTab.ReportsAndSettings, MainHeaderSubTab.Reports);
        }

        [When(@"I open '([^']*)' report")]
        public void WhenIOpenReport(string reportName)
        {
            AllReportsPage allReportsPage = new AllReportsPage(_scenarioContext);
            allReportsPage.FilterReports(reportName);
            allReportsPage.OpenReport(reportName);
        }

        [When(@"I run the report")]
        public void WhenIRunTheReport()
        {
            new ProjectReportsPage(_scenarioContext).RunReport();
        }

        [Then(@"Report's resuls are displayed")]
        public void ThenReportsResulsAreDisplayed()
        {
            bool areAnyItems = new ProjectReportsPage(_scenarioContext).GetReportResultsItems().Any();

            Assert.IsTrue(areAnyItems, "There are no results.");
        }

        [When(@"I navigate to activity log")]
        public void WhenINavigateToActivityLog()
        {
            new HomeDashboardPage(_scenarioContext).MainHeader.ClickSubTab<ActivityLogPage>(MainHeaderTab.ReportsAndSettings, MainHeaderSubTab.ActivityLog);
        }

        [When(@"I remove first (.*) items")]
        public void WhenIRemoveItems(int numberOfItems)
        {
            activityLogItemsToBeDeleted = new List<ActivityLogItem>();
            ActivityLogPage activityLogPage = new ActivityLogPage(_scenarioContext);
            var currentActivityLogItems = activityLogPage.GetActivityLogItems();
            deletedActivityLogItemsContent = new List<string>();

            for (int i = 0; i < numberOfItems; i++)
            {
                deletedActivityLogItemsContent.Add(currentActivityLogItems.ElementAt(i).GetElementText());
            }

            new ActivityLogPage(_scenarioContext).DeleteItems(numberOfItems);
        }

        [Then(@"The items are not displayed")]
        public void ThenTheItemsAreNotDisplayed()
        {
            ActivityLogPage activityLogPage = new ActivityLogPage(_scenarioContext);
            var currentActivityLogItems = activityLogPage.GetActivityLogItems();
            List<string> currentActivityLogContent = new List<string>();
           
            foreach (var item in currentActivityLogItems)
            {
                currentActivityLogContent.Add(item.GetElementText());
            }
             
            foreach(var deletedActivityLogContent in deletedActivityLogItemsContent)
            {
                bool isDeletedItemDisplayed = currentActivityLogContent.Any(item => item.Equals(deletedActivityLogContent));

                Assert.IsFalse(isDeletedItemDisplayed, "Deleted item is displayed");
            }
        }
    }
}
