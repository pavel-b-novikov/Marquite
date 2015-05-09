using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Menus
{
    public class NavigationBuilder : ElementHtmlBuilder<NavigationBuilder>
    {
        public NavigationBuilder(Core.Marquite marquite) : base(marquite, "nav")
        {
            TagsCategory.Add("navtype","nav-tabs");
        }

        public NavigationBuilder Stacked()
        {
            return AddClass("nav-stacked");
        }

        public NavigationBuilder Pills()
        {
            TagsCategory.CleanupAndAdd("navtype", "nav-pills");
            return This;
        }

        public NavigationBuilder Tabs()
        {
            TagsCategory.CleanupAndAdd("navtype", "nav-tabs");
            return This;
        }

        public NavigationBuilder Justified()
        {
            return AddClass("nav-justified");
        }
    }
}
