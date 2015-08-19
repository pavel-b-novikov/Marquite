namespace Marquite.Core.ElementBuilders
{
    public class UnorderedListBuilder : ListBuilder<UnorderedListBuilder>
    {
        public UnorderedListBuilder(IMarquite m) : base(m, "ul")
        {
        }
    }
}