using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class TabPanelBuilder : ElementHtmlBuilder<TabPanelBuilder>
    {
        private string _previousActiveTab;
        private BootstrapPlugin _bs;
        private NavBuilder _navBuilder;

        public TabPanelBuilder(Core.IMarquite marquite) : base(marquite, "div")
        {
            this.Role("tabpanel");
            _bs = marquite.ResolvePlugin<BootstrapPlugin>();
            _previousActiveTab = _bs.CurrentActiveTab;
            _navBuilder = new NavBuilder(marquite).Detached();
        }

        

    }
}
