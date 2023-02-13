using ReplyTask.PageObjects.Pages.AbstractPages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects.Pages.Contacts
{
    public class ContactsPage : AbstractMainPage
    {
        public ContactsPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            // wait.Until(ExpectedConditions.ElementIsVisible(mainTitleLocator));
            wait.Until(ExpectedConditions.UrlContains("Contacts&action=index"));
        }
    }
}
