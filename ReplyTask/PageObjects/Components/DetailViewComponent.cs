using OpenQA.Selenium;
using ReplyTask.PageObjects.Pages.AbstractPages;

namespace ReplyTask.PageObjects.Components
{
    public class ContactDetailViewComponent : AbstractCRMPageObject
    {
        public IWebElement FullName => driver.FindElement(By.XPath("//div[@id = '_form_header']//h3"));

        public IWebElement Category => driver.FindElement(By.XPath("//ul[@class = 'summary-list']//p//parent::li"));

        public IWebElement BusinessRole => driver.FindElement(By.XPath("//div[contains(@class, 'cell-business_role')]//div[@class = 'form-value']"));

        public string GetFullName()
        {
            return FullName.Text.Replace("&nbsp", "").Trim();
        }

        public string GetBusinessRole()
        {
            return BusinessRole.Text;
        }

        public string GetCategory()
        {
            return Category.Text.Replace("Category\r\n", "");
        }

        public string GetContactFirstName()
        {
            return FullName.Text.Split(" ").First();
        }

        public string GetContactLastName()
        {
            return FullName.Text.Split(" ").Last().Replace("&nbsp", "");
        }
    }
}
