using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Extensions
{
    public static class TabsExtensions
    {
        public static T TabHeader<T>(this T b,string tabId) where T : BasicHtmlBuilder
        {
            b.Attr("role", "tab");
            b.Data("toggle", "tab");
            b.Aria("controls", tabId);
            return b;
        }

        public static T TabContent<T>(this T b) where T : BasicHtmlBuilder
        {
            return b.AddClass("tab-content");
        }

        public static T TabPanel<T>(this T b, bool active) where T : BasicHtmlBuilder
        {
            b.AddClass("tab-pane").Attr("role", "tabpanel");
            if (active) b.AddClass("active");
            return b;
        }

        public static T TabPanelFade<T>(this T b, bool active) where T : BasicHtmlBuilder
        {
            b.AddClass("tab-pane").Attr("role", "tabpanel").AddClass("fade");
            if (active)
            {
                b.AddClass("in").AddClass("active");
            }

            return b;
        }

    }
}
