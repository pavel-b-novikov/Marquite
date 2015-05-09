using Marquite.Core.ElementBuilders;

namespace Marquite.Core.Html
{
    public static class ListExtensions
    {
        public static OrderedListBuilder OrderedList(this Marquite b)
        {
            return new OrderedListBuilder(b);
        }

        public static UnorderedListBuilder UnorderedList(this Marquite b)
        {
            return new UnorderedListBuilder(b);
        }
    }
}