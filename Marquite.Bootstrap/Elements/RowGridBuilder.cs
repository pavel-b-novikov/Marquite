using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class RowGridBuilder : ElementHtmlBuilder
    {
        public RowGridBuilder(Core.IMarquite m) : base(m,"div")
        {
            this.AddClass("row");
        }
    }
}
