using OpenQA.Selenium;
using ReplyTask.PageObjects.Pages.AbstractPages;
using ReplyTask.PageObjects.Pages.TodaysActivities;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects.Pages.Login
{
    public class LoginPage : AbstractCRMPageObject
    {
        private By loginUserLocator = By.Id("login_user");

        public LoginPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        public IWebElement loginPassword => driver.FindElement(By.Id("login_pass"));

        public IWebElement loginButton => driver.FindElement(By.Id("login_button"));

        public HomeDashboardPage Login(string userName, string password)
        {
            IWebElement loginUser = wait.Until(ExpectedConditions.ElementIsVisible(loginUserLocator));
            loginUser.SendKeys(userName);
            loginPassword.SendKeys(userName);
            loginButton.Click();

            return new HomeDashboardPage(scenarioContext);
        }
    }
}

