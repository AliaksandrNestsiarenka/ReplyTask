using OpenQA.Selenium;
using ReplyTask.Components;
using ReplyTask.PageObjects.Components;

namespace ReplyTask.PageObjects.Pages.AbstractPages
{
    public abstract class AbstractMainPage : AbstractCRMPageObject
    {
        protected By mainTitleLocator = By.Id("main-title");
        protected By leftSidebarLocator = By.Id("left-sidebar");

        protected AbstractMainPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {

        }

        public MainHeaderComponent MainHeader => new MainHeaderComponent(scenarioContext);

        public SidebarMenuComponent SidebarMenuComponent => new SidebarMenuComponent(scenarioContext);
    }
}
