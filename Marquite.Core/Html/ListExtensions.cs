using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class ListExtensions
    {
        public static OrderedListBuilder OrderedList(this IMarquite b)
        {
            return new OrderedListBuilder(b);
        }

        public static UnorderedListBuilder UnorderedList(this IMarquite b)
        {
            return new UnorderedListBuilder(b);
        }
    }
}