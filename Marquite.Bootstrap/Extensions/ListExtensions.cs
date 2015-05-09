using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Extensions
{
    public static class ListExtensions
    {
        public static ListBuilder<T> InlineList<T>(this ListBuilder<T> list,bool inline = true)
        {
            if (inline) list.RemoveClass(Lookups.Lookup(ListStyles.Inline));
            else list.AddClass(Lookups.Lookup(ListStyles.Inline));
            return list;
        }

        public static ListBuilder<T> UnstyledList<T>(this ListBuilder<T> list, bool unstyled = true)
        {
            if (unstyled) list.RemoveClass(Lookups.Lookup(ListStyles.Unstyled));
            else list.AddClass(Lookups.Lookup(ListStyles.Unstyled));
            return list;
        }
    }
}
