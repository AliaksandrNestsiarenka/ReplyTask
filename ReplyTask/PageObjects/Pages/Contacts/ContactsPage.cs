using ReplyTask.PageObjects.Pages.AbstractPages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects.Pages.Contacts
{
    public class ContactsPage : AbstractMainPage
    {
        public ContactsPage()
        {
            // wait.Until(ExpectedConditions.ElementIsVisible(mainTitleLocator));
            wait.Until(ExpectedConditions.UrlContains("Contacts&action=index"));
        }
    }
}
