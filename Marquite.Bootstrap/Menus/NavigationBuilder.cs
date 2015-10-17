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
        public NavigationBuilder(Core.IMarquite marquite) : base(marquite, "nav")
        {
            CategorizedCssClasses.Add("navtype","nav-tabs");
        }

        public NavigationBuilder Stacked()
        {
            return AddClass("nav-stacked");
        }

        public NavigationBuilder Pills()
        {
            CategorizedCssClasses.CleanupAndAdd("navtype", "nav-pills");
            return This;
        }

        public NavigationBuilder Tabs()
        {
            CategorizedCssClasses.CleanupAndAdd("navtype", "nav-tabs");
            return This;
        }

        public NavigationBuilder Justified()
        {
            return AddClass("nav-justified");
        }
    }
}
