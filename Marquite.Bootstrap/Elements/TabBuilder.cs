using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Extensions;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class TabPanelBuilder : ElementHtmlBuilder<TabPanelBuilder>
    {
        private string _previousActiveTab;
        private BootstrapPlugin _bs;
        private NavBuilder _navBuilder;

        public TabPanelBuilder(Core.Marquite marquite) : base(marquite, "div")
        {
            this.Role("tabpanel");
            _bs = marquite.ResolvePlugin<BootstrapPlugin>();
            _previousActiveTab = _bs.CurrentActiveTab;
            _navBuilder = new NavBuilder(marquite);
        }

        

    }
}
