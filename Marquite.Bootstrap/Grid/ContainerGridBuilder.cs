using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Grid
{
    public class ContainerGridBuilder : ElementHtmlBuilder<ContainerGridBuilder>
    {
        public ContainerGridBuilder(Core.IMarquite m,bool fluid) : base(m,"div")
        {
            AddClass(!fluid ? "container" : "container-fluid");
        }
    }
}
