using Marquite.Core;
using Marquite.Core.Elements;

namespace Marquite.Bootstrap.Extensions
{
    public static class ListExtensions
    {
        public static T InlineList<T>(this T list, bool inline = true) where T : ListBuilder
        {
            if (inline) list.RemoveClass(Lookups.Lookup(ListStyles.Inline));
            else list.AddClass(Lookups.Lookup(ListStyles.Inline));
            return list;
        }

        public static T UnstyledList<T>(this T list, bool unstyled = true) where T : ListBuilder
        {
            if (unstyled) list.RemoveClass(Lookups.Lookup(ListStyles.Unstyled));
            else list.AddClass(Lookups.Lookup(ListStyles.Unstyled));
            return list;
        }
    }
}
