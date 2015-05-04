using Marquite.Bootstrap.Lists;

namespace Marquite.Bootstrap.Extensions
{
    public static class ListExtensions
    {
        public static OrderedListBuilder OrderedList(this Core.Marquite b)
        {
            return new OrderedListBuilder(b);
        }

        public static UnorderedListBuilder UnorderedList(this Core.Marquite b)
        {
            return new UnorderedListBuilder(b);
        }
    }
}
