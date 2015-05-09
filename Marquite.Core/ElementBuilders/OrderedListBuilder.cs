namespace Marquite.Core.ElementBuilders
{
    public class OrderedListBuilder : ListBuilder<OrderedListBuilder>
    {
        public OrderedListBuilder(Marquite m) : base(m, "ol")
        {
        }
    }
}