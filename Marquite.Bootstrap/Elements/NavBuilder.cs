using System;
using System.Collections.Generic;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class NavBuilder : ElementHtmlBuilder<NavBuilder>
    {
        public NavBuilder(Core.IMarquite marquite)
            : base(marquite, "ul")
        {
            AddClass("nav");
            AddClass("nav-tabs");
        }

        public NavBuilder Stacked()
        {
            RemoveClass("nav-justified");
            AddClass("nav-stacked");
            return this;
        }

        public NavBuilder Justified()
        {
            RemoveClass("nav-stacked");
            AddClass("nav-justified");
            return this;
        }

        public NavBuilder Pills()
        {
            RemoveClass("nav-tabs");
            AddClass("nav-pills");
            return this;
        }
        
    }
}
