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
        List<ActivityLogItem> activityLogItemsToBeDeleted;
        List<string> deletedActivityLogItemsContent;

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

        [When(@"I navigate to activity log")]
        public void WhenINavigateToActivityLog()
        {
            new HomeDashboardPage().MainHeader.ClickSubTab<ActivityLogPage>(MainHeaderTab.ReportsAndSettings, MainHeaderSubTab.ActivityLog);
        }

        [When(@"I remove first (.*) items")]
        public void WhenIRemoveItems(int numberOfItems)
        {
            activityLogItemsToBeDeleted = new List<ActivityLogItem>();
            ActivityLogPage activityLogPage = new ActivityLogPage();
            var currentActivityLogItems = activityLogPage.GetActivityLogItems();
            deletedActivityLogItemsContent = new List<string>();

            for (int i = 0; i < numberOfItems; i++)
            {
                deletedActivityLogItemsContent.Add(currentActivityLogItems.ElementAt(i).GetElementText());
            }

            new ActivityLogPage().DeleteItems(numberOfItems);
        }

        [Then(@"The items are not displayed")]
        public void ThenTheItemsAreNotDisplayed()
        {
            ActivityLogPage activityLogPage = new ActivityLogPage();
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
