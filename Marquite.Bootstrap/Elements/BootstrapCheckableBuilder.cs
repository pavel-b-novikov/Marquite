using System;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;
using Marquite.Core.Html;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class BootstrapCheckableBuilder : BasicHtmlBuilder, IDisableable
    {
        public BootstrapCheckableBuilder(Core.IMarquite marquite) : base(marquite, "div")
        {
            this.AddClass("checkbox");
        }

        public BootstrapCheckableBuilder(InputElementBuilder checkbox) : this(checkbox.Marquite)
        {
        }
        
        
    }
}
