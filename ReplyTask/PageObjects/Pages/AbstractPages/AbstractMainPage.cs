using OpenQA.Selenium;
using ReplyTask.Components;
using ReplyTask.PageObjects.Components;

namespace ReplyTask.PageObjects.Pages.AbstractPages
{
    public abstract class AbstractMainPage : AbstractCRMPageObject
    {
        protected By mainTitleLocator = By.Id("main-title");
        protected By leftSidebarLocator = By.Id("left-sidebar");

        public MainHeaderComponent MainHeader => new MainHeaderComponent();

        public SidebarMenuComponent SidebarMenuComponent => new SidebarMenuComponent();
    }
}
