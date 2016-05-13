using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Extensions
{
    public static class DropdownExtensions
    {
        public static DropdownBuilder Dropdown<T>(this T element, 
            Action<DropdownMenuBuilder> menu = null,
            Action<SimpleHtmlBuilder> caret = null )
            where T : BasicHtmlBuilder
        {
            element.AddClass("dropdown-toggle")
                .Data("toggle", "dropdown")
                .Aria("haspopup", "true")
                .Aria("expanded", "true")
                .Append(element.Marquite.Bs().Caret().Mixin(caret));

            DropdownBuilder ddb = new DropdownBuilder(element.Marquite, "div");
            ddb.Append(element.Detached());

            DropdownMenuBuilder dmb = new DropdownMenuBuilder(element.Marquite).Mixin(menu);

            ddb.Append(dmb).Aria("labelledby",element.EnsureId().IdVal);

            return ddb;
        }

        public static DropdownBuilder Dropdown<T>(this BootstrapPlugin bs,
            Action<BootstrapButtonBuilder> button = null,
            Action<DropdownMenuBuilder> menu = null,
            Action<SimpleHtmlBuilder> caret = null)
            where T : BasicHtmlBuilder
        {
            var btn = bs.Button().Mixin(button)
                .AddClass("dropdown-toggle")
                .Data("toggle", "dropdown")
                .Aria("haspopup", "true")
                .Aria("expanded", "true")
                .Append(bs.Caret().Mixin(caret));

            DropdownBuilder ddb = new DropdownBuilder(bs.Marquite, "div");
            ddb.Append(btn.Detached());

            DropdownMenuBuilder dmb = new DropdownMenuBuilder(bs.Marquite).Mixin(menu);

            ddb.Append(dmb).Aria("labelledby", btn.EnsureId().IdVal);

            return ddb;
        }
    }
}
