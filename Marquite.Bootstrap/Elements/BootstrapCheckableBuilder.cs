using System;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class BootstrapCheckableBuilder : BasicHtmlBuilder<BootstrapCheckableBuilder>
    {
        public BootstrapCheckableBuilder(Core.IMarquite marquite) : base(marquite, "div")
        {
            AddClass("checkbox");
        }


        public BootstrapCheckableBuilder(InputElementBuilder checkbox) : this(checkbox.Marquite)
        {
        }

        public BootstrapCheckableBuilder Disabled()
        {
            return AddClass("disabled");
        }

        public BootstrapCheckableBuilder Inline()
        {
            return AddClass("inline");
        }
    }
}
