using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using ReplyTask.Drivers;
using ReplyTask.Enums;
using ReplyTask.PageObjects;
using ReplyTask.Pages;

namespace ReplyTask.StepDefinitions
{
    [Binding]
    public sealed class CRMCloudStepDefinitions
    {
        private string userName = "admin";
        private string userPassword = "admin";

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
        }

        [When(@"I create a new contact")]
        public void WhenICreateANewContact()
        {
            CreateContactPage createContactPage = new SalesAndMarketingPage().SidebarMenuComponent.ClickSidebarItem<CreateContactPage>(SidebarMenuItem.CreateContact);
            createContactPage.SetFirstName("Alex");
            createContactPage.SetLastName("Next");
            createContactPage.ClickSaveButton<SalesAndMarketingPage>();
        }

        [Then(@"Created contact details matches with the contact information")]
        public void ThenCreatedContactDetailsMatchesWithTheContactInformation()
        {
            
        }
    }
}