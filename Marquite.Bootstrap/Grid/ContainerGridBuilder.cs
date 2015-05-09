using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Grid
{
    public class ContainerGridBuilder : ElementHtmlBuilder<ContainerGridBuilder>
    {
        public ContainerGridBuilder(Core.Marquite m,bool fluid) : base(m,"div")
        {
            AddClass("container");
            if (fluid) AddClass("container-fluid");
        }

    }
}
