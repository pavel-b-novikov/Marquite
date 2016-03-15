using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class DropdownMenuBuilder : ElementHtmlBuilder
    {
        public DropdownMenuBuilder(Core.IMarquite marquite)
            : base(marquite, "ul")
        {
            this.AddClass("dropdown-menu");
            this.Role("menu");
        }
    }
}
