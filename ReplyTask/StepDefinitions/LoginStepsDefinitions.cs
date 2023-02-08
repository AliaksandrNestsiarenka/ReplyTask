using OpenQA.Selenium;
using ReplyTask.ConfigurationModels;
using ReplyTask.Drivers;
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
        private User? testUser;

        [Given(@"I am an admin user")]
        public void GivenIAmAnAdminUser()
        {
            testUser = Hooks.MainHooks.mainConfigModel.Users.Admin;
        }

        [When(@"I log in")]
        public void WhenILogIn()
        {
            LoginPage page = new LoginPage();
            page.Login(testUser.UserName, testUser.Password);
        }
    }
}
