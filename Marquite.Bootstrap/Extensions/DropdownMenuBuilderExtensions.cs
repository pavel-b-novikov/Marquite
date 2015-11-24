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
            ListItemBuilder lb = new ListItemBuilder(b.Marquite).AddClass("divider");
            if (listItemOptions != null) listItemOptions(lb);
            b.TrailingHtml(lb);
            return b;
        }

        public static T Item<T>(this T b, string text, Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            ListItemBuilder lb = new ListItemBuilder(b.Marquite).TrailingHtml(text);
            if (listItemOptions != null) listItemOptions(lb);
            b.TrailingHtml(lb);
            return b;
        }

        public static T Item<T>(this T b, IRenderingClient content, Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            ListItemBuilder lb = new ListItemBuilder(b.Marquite).TrailingHtml(content);
            if (listItemOptions != null) listItemOptions(lb);
            b.TrailingHtml(lb);
            return b;
        }

        public static T LinkItem<T>(this T b, string text, string href, Action<LinkBuilder> linkOptions = null, Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            LinkBuilder lb = new LinkBuilder(b.Marquite);
            lb.TrailingText(text).Href(href).Tabindex(-1);
            if (linkOptions != null) linkOptions(lb);
            return Item(b, lb, listItemOptions);
        }

        public static T RawItem<T>(this T b, IRenderingClient item) where T : DropdownMenuBuilder
        {
            b.RenderingQueue.Trail(item.Detached());
            return b;
        }

        public static T Header<T>(this T b, string header, Action<ListItemBuilder> listItemOptions = null) where T : DropdownMenuBuilder
        {
            ListItemBuilder lb = new ListItemBuilder(b.Marquite).TrailingHtml(header).AddClass("dropdown-header");
            if (listItemOptions != null) listItemOptions(lb);
            b.TrailingHtml(lb);
            return b;
        }
    }
}