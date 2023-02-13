using OpenQA.Selenium;
using ReplyTask.ConfigurationModels;
using ReplyTask.Drivers;
using ReplyTask.Hooks;
using ReplyTask.PageObjects.Pages.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplyTask.StepDefinitions
{
    [Binding]
    public sealed class LoginStepsDefinitions
    {
        private ScenarioContext scenarioContext;
        private User? testUser;

        public LoginStepsDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I am an admin user")]
        public void GivenIAmAnAdminUser()
        {
            testUser = scenarioContext.Get<MainConfigModel>("Config").Users.Admin;
        }

        [When(@"I log in")]
        public void WhenILogIn()
        {
            LoginPage page = new LoginPage(scenarioContext);
            page.Login(testUser.UserName, testUser.Password);
        }
    }
}
