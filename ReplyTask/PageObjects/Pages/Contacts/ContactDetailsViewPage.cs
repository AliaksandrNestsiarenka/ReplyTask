using OpenQA.Selenium;
using ReplyTask.PageObjects.Components;
using ReplyTask.PageObjects.Pages.AbstractPages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects.Pages.Contacts
{
    public class ContactDetailsViewPage : AbstractMainPage
    {
        private By DetailViewComponentLocator = By.XPath("//div[@id = '_form_header']//h3");

        public ContactDetailsViewPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(DetailViewComponentLocator));
        }

        public ContactDetailViewComponent ContactDetailViewComponent => new ContactDetailViewComponent(scenarioContext);
    }
}
