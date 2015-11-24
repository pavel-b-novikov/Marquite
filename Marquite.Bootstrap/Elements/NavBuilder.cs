using System;
using System.Collections.Generic;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class NavBuilder : ElementHtmlBuilder
    {
        public NavBuilder(Core.IMarquite marquite)
            : base(marquite, "ul")
        {
            this.AddClass("nav");
            this.AddClass("nav-tabs");
        }

        
    }
}
