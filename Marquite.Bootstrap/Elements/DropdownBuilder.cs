using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class DropdownBuilder : ElementHtmlBuilder
    {
        public DropdownBuilder(Core.IMarquite marquite, string tagName) : base(marquite, tagName)
        {
            this.AddClass("dropdown");
        }
    }
}
