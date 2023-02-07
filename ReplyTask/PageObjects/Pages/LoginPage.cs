using OpenQA.Selenium;
using ReplyTask.Enums;
using ReplyTask.Extensions;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.Pages
{
    public class LoginPage : AbstractCRMPageObject
    {
        private By loginUserLocator = By.Id("login_user");

        public IWebElement loginPassword => driver.FindElement(By.Id("login_pass"));

        public IWebElement loginButton => driver.FindElement(By.Id("login_button"));

        public HomeDashboardPage Login(string userName, string password)
        {
            IWebElement loginUser = wait.Until(ExpectedConditions.ElementExists(loginUserLocator));
            loginUser.SendKeys(userName);
            loginPassword.SendKeys(userName);
            loginButton.Click();

            return new HomeDashboardPage();
        }
    }
}

