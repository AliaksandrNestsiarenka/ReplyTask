using OpenQA.Selenium;
using ReplyTask.PageObjects.Components;
using ReplyTask.Pages;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplyTask.PageObjects.Pages
{
    public class ContactDetailsViewPage : AbstractMainPage
    {
        private By DetailViewComponentLocator = By.XPath("//div[@id = '_form_header']//h3");

        public ContactDetailsViewPage()
        {
            wait.Until(ExpectedConditions.ElementExists(DetailViewComponentLocator));
        }

        public ContactDetailViewComponent ContactDetailViewComponent => new ContactDetailViewComponent();
    }
}
