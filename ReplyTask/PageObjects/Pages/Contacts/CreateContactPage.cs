using OpenQA.Selenium;
using ReplyTask.Enums;
using ReplyTask.Extensions;
using ReplyTask.PageObjects.Pages.AbstractPages;
using SeleniumExtras.WaitHelpers;

namespace ReplyTask.PageObjects.Pages.Contacts
{
    public class CreateContactPage : AbstractCRMPageObject
    {
        private string categoriesOptionLocatorPattern = "//div[@id = 'DetailFormcategories-input-search-list']//div[contains(@class, 'menu-option')]//div[text() = '{0}']";

        private string businessRoleLocatorPattern = "//div[@id = 'DetailFormbusiness_role-input-search-list']//div[contains(@class, 'menu-option')]//div[text() = '{0}']";

        private By businessRoleInputLocator = By.Id("DetailFormbusiness_role-input");

        private By categoriesSearchInputLocator = By.XPath("//div[@id = 'DetailFormcategories-input-search-text']//input");

        private By saveButtonLocator = By.Id("DetailForm_save2");

        private By firstNameLocator = By.Id("DetailFormfirst_name-input");

        private By lastNameLocator = By.Id("DetailFormlast_name-input");

        private By categoryInputLocator = By.Id("DetailFormcategories-input");

        public CreateContactPage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(firstNameLocator));
        }

        public void SetFirstName(string firstName)
        {
            IWebElement saveButton = driver.FindElement(firstNameLocator);
            saveButton.SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            IWebElement lastNameElement = driver.FindElement(lastNameLocator);
            lastNameElement.SendKeys(lastName);
            Thread.Sleep(2000);
        }

        public void SetCategories(List<ContactCategory> categories)
        {
            foreach (ContactCategory categoryItem in categories)
            {
                string categoryDescription = categoryItem.GetDescription();

                IWebElement categoryInput = driver.FindElement(categoryInputLocator);
                categoryInput.Click();
                IWebElement categoriesSearch = wait.Until(ExpectedConditions.ElementIsVisible(categoriesSearchInputLocator));
                categoriesSearch.SendKeys(categoryDescription);
                IWebElement categoryOption = driver.FindElement(By.XPath(string.Format(categoriesOptionLocatorPattern, categoryDescription)));
                categoryOption.Click();
                Thread.Sleep(1000);
            }
        }

        public void SetBusinessRole(ContactBusinessRole businessRole)
        {
            string businessRoleDescription = businessRole.GetDescription();
            IWebElement categoryInput = driver.FindElement(businessRoleInputLocator);
            categoryInput.Click();
            actions.SendKeys(businessRoleDescription).Perform();
            IWebElement categoryOption = wait.
                Until(ExpectedConditions.ElementExists(By.XPath(string.Format(businessRoleLocatorPattern, businessRoleDescription))));
            categoryOption.Click();
        }

        public T ClickSaveButton<T>()
        {
            IWebElement saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            return Activator.CreateInstance<T>();
        }
    }
}
