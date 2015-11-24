using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Elements
{
    public class ListItemBuilder : ElementHtmlBuilder
    {
        public ListItemBuilder(IMarquite m) : base(m, "li")
        {
        }
    }
}