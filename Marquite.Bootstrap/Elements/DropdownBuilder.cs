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

        public DropdownBuilder(Core.IMarquite marquite, string tagName, IHtmlBuilder triggeringElement, DropdownMenuBuilder menu)
            : base(marquite, tagName)
        {
            _triggeringElement = triggeringElement.Detached();
            _menu = menu.Detached();
            this.AddClass("dropdown");
        }

        internal IRenderingClient _triggeringElement;
        internal DropdownMenuBuilder _menu;

        public override void PrepareForRender()
        {
            RenderingQueue.Trail(_triggeringElement);
            RenderingQueue.Trail(_menu);
            base.PrepareForRender();
        }
    }
}
