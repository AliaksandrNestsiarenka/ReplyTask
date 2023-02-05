using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplyTask.Components;
using ReplyTask.PageObjects.Components;

namespace ReplyTask.Pages
{
    public abstract class AbstractMainPage : AbstractCRMPageObject
    {
        public MainHeaderComponent MainHeader => new MainHeaderComponent();

        public SidebarMenuComponent SidebarMenuComponent => new SidebarMenuComponent();
    }
}
