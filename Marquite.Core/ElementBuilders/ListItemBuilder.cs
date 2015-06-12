using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class ListItemBuilder : ElementHtmlBuilder<ListItemBuilder>
    {
        public ListItemBuilder(Marquite m) : base(m, "li")
        {
        }
    }
}