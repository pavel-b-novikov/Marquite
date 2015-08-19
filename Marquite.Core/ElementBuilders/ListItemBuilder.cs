using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class ListItemBuilder : ElementHtmlBuilder<ListItemBuilder>
    {
        public ListItemBuilder(IMarquite m) : base(m, "li")
        {
        }
    }
}