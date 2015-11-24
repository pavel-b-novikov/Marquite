using Marquite.Core;
using Marquite.Core.Elements;

namespace Marquite.Bootstrap.Elements
{
    public class BootstrapButtonBuilder : ButtonBuilder, IBootstrapped
    {
        public BootstrapButtonBuilder(Core.IMarquite marquite, string tagName)
            : base(marquite, tagName)
        {
            this.AddClass("btn");
            this.AddClass(Lookups.Lookup(ButtonColor.Default));
            /*
             * If the <a> elements are used to act as buttons – triggering in-page functionality, 
             * rather than navigating to another document or section within the current page – 
             * they should also be given an appropriate role="button".
             */
            if (tagName == "a")
            {
                this.Attr("role", "button");
            }
            Bootstrap = marquite.ResolvePlugin<BootstrapPlugin>();
        }

        public BootstrapPlugin Bootstrap { get; private set; }
    }
}
