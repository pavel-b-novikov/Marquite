using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class ContainerGridBuilder : ElementHtmlBuilder
    {
        public ContainerGridBuilder(Core.IMarquite m,bool fluid) : base(m,"div")
        {
            this.AddClass(!fluid ? "container" : "container-fluid");
        }
    }
}
