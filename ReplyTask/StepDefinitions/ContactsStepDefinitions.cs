using NUnit.Framework;
using ReplyTask.Enums;
using ReplyTask.Extensions;
using ReplyTask.Infrastructure;
using ReplyTask.PageObjects.Models;
using ReplyTask.PageObjects.Pages.Contacts;
using ReplyTask.PageObjects.Pages.TodaysActivities;

namespace ReplyTask.StepDefinitions
{
    [Binding]
    public sealed class ContactsStepDefinitions
    {   
        private ContactModel? newContactModel;
        private ScenarioContext _scenarioContext;

        public ContactsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I navigate to contacts")]
        public void WhenINavigateToContacts()
        {
            new HomeDashboardPage(_scenarioContext).MainHeader.ClickSubTab<ContactsPage>(MainHeaderTab.SalesAndMarketing, MainHeaderSubTab.Contacts);
            Thread.Sleep(2000);
        }

        [Given(@"I have a new contact information")]
        public void IHaveANewContactInformation()
        {
            newContactModel = new()
            {
                FirstName = RandomStringGenerator.GenerateRandomAlphabeticalString(),
                LastName = RandomStringGenerator.GenerateRandomAlphabeticalString(),
                ContactCategories = new() { ContactCategory.Customers, ContactCategory.Suppliers },
                BusinessRole = ContactBusinessRole.CEO
            };     
        }

        [When(@"I create a new contact")]
        public void WhenICreateANewContact()
        {
            CreateContactPage createContactPage = new ContactsPage(_scenarioContext).SidebarMenuComponent.ClickSidebarItem<CreateContactPage>(SidebarMenuItem.CreateContact);
            createContactPage.SetFirstName(newContactModel?.FirstName ?? "");
            createContactPage.SetLastName(newContactModel?.LastName ?? "");
            createContactPage.SetCategories(newContactModel?.ContactCategories ?? new List<ContactCategory>());
            createContactPage.SetBusinessRole(newContactModel?.BusinessRole ?? ContactBusinessRole.CEO);
            createContactPage.ClickSaveButton<ContactDetailsViewPage>();
        }

        [Then(@"Created contact details matches with the contact information")]
        public void ThenCreatedContactDetailsMatchesWithTheContactInformation()
        {
            ContactDetailsViewPage contactDetailsViewPage = new ContactDetailsViewPage(_scenarioContext);
            var actualFullName = contactDetailsViewPage.ContactDetailViewComponent.GetFullName();
            var actualCategories = contactDetailsViewPage.ContactDetailViewComponent.GetCategory();
            var actualBusinessRole = contactDetailsViewPage.ContactDetailViewComponent.GetBusinessRole();

            var expectedFullName = newContactModel?.FirstName + " " + newContactModel?.LastName;
            var expectedCategories = newContactModel?.ContactCategories.ElementAt(0).GetDescription() + ", " + newContactModel?.ContactCategories.ElementAt(1).GetDescription();
            var expectedBusinessRole = newContactModel?.BusinessRole.GetDescription();

            Assert.AreEqual(expectedFullName, actualFullName, "Contact full name does not match with expected value.");
            Assert.AreEqual(expectedCategories, actualCategories, "Contact categories name do not match with expected value.");
            Assert.AreEqual(expectedBusinessRole, actualBusinessRole, "Contact business role does not match with expected value.");
        }
    }
}