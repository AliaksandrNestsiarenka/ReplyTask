using OpenQA.Selenium;
using ReplyTask.Drivers;
using ReplyTask.Pages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects
{
    public class CreateContactPage : AbstractCRMPageObject
    {
        private By SaveButtonLocator = By.Id("DetailForm_save2");

        private By FirstNameLocator = By.Id("DetailFormfirst_name-input");

        private By LastNameLocator = By.Id("DetailFormlast_name-input");

        public CreateContactPage()
        {
            wait.Until(ExpectedConditions.ElementExists(FirstNameLocator));
        }

        public void SetFirstName(string firstName)
        {
            IWebElement saveButton = driver.FindElement(FirstNameLocator);
            saveButton.SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            IWebElement saveButton = driver.FindElement(LastNameLocator);
            saveButton.SendKeys(lastName);
        }

        public T ClickSaveButton<T>()
        {
            IWebElement saveButton = driver.FindElement(SaveButtonLocator);
            saveButton.Click();
            return Activator.CreateInstance<T>();  
        }
    }
}
