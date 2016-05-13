using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Core.Html
{
    public static class ListBuilderExtensions
    {
        public static T AddItem<T>(this T b, string itemContent) where T : ListBuilder
        {
            b.Content.Trail(itemContent, "li");
            return b;
        }

        public static T AddItems<T>(this T b, params string[] itemContent) where T : ListBuilder
        {
            itemContent.ForEach(c => b.Content.Trail(c, "li"));
            return b;
        }

        public static T AddItem<T>(this T b, IRenderingClient item) where T : ListBuilder
        {
            b.Content.Trail(item.Detached(), "li");
            return b;
        }

        public static T AddItem<T>(this T b, ListItemBuilder listItem) where T : ListBuilder
        {
            b.Content.Trail(listItem.Detached());
            return b;
        }

        public static T AddItems<T>(this T b, params IRenderingClient[] items) where T : ListBuilder
        {
            items.ForEach(c => b.Content.Trail(c.Detached(), "li"));
            return b;
        }
    }
}