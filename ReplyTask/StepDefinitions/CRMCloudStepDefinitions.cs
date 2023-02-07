using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using ReplyTask.Drivers;
using ReplyTask.Enums;
using ReplyTask.Extensions;
using ReplyTask.Infrastructure;
using ReplyTask.PageObjects.Models;
using ReplyTask.PageObjects.Pages;
using ReplyTask.Pages;

namespace ReplyTask.StepDefinitions
{
    [Binding]
    public sealed class CRMCloudStepDefinitions
    {
        private string userName = "admin";
        private string userPassword = "admin";
        private ContactModel? newContactModel;
      
        private IWebDriver driver => DriverFactory.Driver;

        [Given(@"I am an admin user")]
        public void GivenIAmAnAdminUser()
        {
            userName = "admin";
            userPassword = "admin";
        }

        [When(@"I log in")]
        public void WhenILogIn()
        {
            driver.Navigate().GoToUrl("https://demo.1crmcloud.com");
            LoginPage page = new LoginPage();
            page.Login(userName, userPassword);
        }

        [When(@"I navigate to Sales&Marketing tab")]
        public void WhenINavigateToSalesAndMarketingTab()
        {
            new HomeDashboardPage().MainHeader.ClickTab<SalesAndMarketingPage>(MainHeaderTab.SalesAndMarketing);
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
            CreateContactPage createContactPage = new SalesAndMarketingPage().SidebarMenuComponent.ClickSidebarItem<CreateContactPage>(SidebarMenuItem.CreateContact);
            createContactPage.SetFirstName(newContactModel?.FirstName ?? "");
            createContactPage.SetLastName(newContactModel?.LastName ?? "");
            createContactPage.SetCategories(newContactModel?.ContactCategories ?? new List<ContactCategory>());
            createContactPage.SetBusinessRole(newContactModel?.BusinessRole ?? ContactBusinessRole.CEO);
            createContactPage.ClickSaveButton<ContactDetailsViewPage>();
        }

        [Then(@"Created contact details matches with the contact information")]
        public void ThenCreatedContactDetailsMatchesWithTheContactInformation()
        {
            ContactDetailsViewPage contactDetailsViewPage = new ContactDetailsViewPage();
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