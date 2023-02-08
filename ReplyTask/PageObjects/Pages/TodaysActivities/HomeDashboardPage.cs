using ReplyTask.PageObjects.Pages.AbstractPages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects.Pages.TodaysActivities
{
    public class HomeDashboardPage : AbstractMainPage
    {
        public HomeDashboardPage()
        {
            wait.Until(ExpectedConditions.UrlContains("Home&action=index"));
        }
    }
}