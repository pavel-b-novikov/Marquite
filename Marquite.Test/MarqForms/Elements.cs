using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marquite.Angular;
using Marquite.Bootstrap;
using Marquite.Bootstrap.Elements;
using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;
using Marquite.Core.Rendering;
using Marquite.Test.Models;

namespace Marquite.Test.MarqForms
{
    public static class Elements
    {
        public static MvcHtmlString AppNavbar(this WebViewPage h)
        {

            var nav = h.Html.Bs().Navigation(
                h.Html.ActionLink("Grids", "Grids", "Home")
                );


            var navbar = h.Html.Bs().Navbar("Marquite TestSite", h.Url.Action("Index", "Home"))
                .AddNavigation(nav, NavbarPlacement.Left)
                ;

            return navbar.Render();

        }

        public static IHtmlString FirstColumn(this WebViewPage h)
        {
            var html = h.Html;
            var m = html.Marq();
            var bs = html.Marq().Bs();

            using (var mScope = new TagScope(m))
            {
                using (bs.Column(3).Open())
                {
                    bs.Button("Hello!");
                    using (m.Table("A", "B", "C").Open())
                    {
                        m.Tr(html.ActionLink("Download", h.Url.Action("Index", "Home")),
                            html.ActionLink("Download", h.Url.Action("Index", "Home")),
                            html.ActionLink("Download", h.Url.Action("Index", "Home")));
                        m.Tr("C", "D", "E");
                        m.Tr("C", "D", "E");
                        m.Tr("C", "D", "E");
                        m.Tr("C", "D", "E");
                    }
                }
                return mScope.Scope;
            }
        }

        public static IHtmlBuilder GenderGropdown(this HtmlHelper<SampleFormModel> h)
        {
            return  h.DropDownListFor(c => c.Gender, new SelectListItem[]
            {
                new SelectListItem() {Text = "Male", Value = "0"},
                new SelectListItem() {Text = "Female", Value = "1"},
            });
        }


    }
}