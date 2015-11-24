using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class TabPanelBuilder : ElementHtmlBuilder, IBootstrapped
    {
        private string _previousActiveTab;
        private NavBuilder _navBuilder;

        public TabPanelBuilder(Core.IMarquite marquite) : base(marquite, "div")
        {
            this.Role("tabpanel");
            Bootstrap = marquite.ResolvePlugin<BootstrapPlugin>();
            _previousActiveTab = Bootstrap.CurrentActiveTab;
            _navBuilder = new NavBuilder(marquite).Detached();
        }


        public BootstrapPlugin Bootstrap { get; private set; }
    }
}
