namespace Marquite.Core.ElementBuilders
{
    public class OrderedListBuilder : ListBuilder<OrderedListBuilder>
    {
        public OrderedListBuilder(IMarquite m) : base(m, "ol")
        {
        }
    }
}