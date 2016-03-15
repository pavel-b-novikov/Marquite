using System;
using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;
using Marquite.Core.Html;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class DropdownMenuBuilderExtensions
    {
        public static T Divider<T>(this T b, Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            ListItemBuilder lb = new ListItemBuilder(b.Marquite).AddClass("divider").Mixin(listItemOptions);
            b.Append(lb);
            return b;
        }
        public static T Item<T>(this T b, Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            ListItemBuilder lb = new ListItemBuilder(b.Marquite).Mixin(listItemOptions);
            b.Append(lb);
            return b;
        }
        public static T Item<T>(this T b, string text, Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            ListItemBuilder lb = new ListItemBuilder(b.Marquite).Append(text).Mixin(listItemOptions);
            b.Append(lb);
            return b;
        }

        public static T LinkItem<T>(this T b, string text, string href,
            Action<LinkBuilder> linkOptions = null,
            Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            LinkBuilder lb = new LinkBuilder(b.Marquite)
                .AppendText(text)
                .Href(href)
                .Tabindex(-1)
                .Mixin(linkOptions);

            return Item(b, c => c.Append(lb).Mixin(listItemOptions));
        }

        public static T Header<T>(this T b, string header, Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            ListItemBuilder lb = new ListItemBuilder(b.Marquite)
                .Append(header)
                .AddClass("dropdown-header")
                .Mixin(listItemOptions);
            b.Append(lb);
            return b;
        }
    }
}