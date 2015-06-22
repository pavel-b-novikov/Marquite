using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class DropdownBuilder : ElementHtmlBuilder<DropdownBuilder>
    {
        public DropdownBuilder(Core.Marquite marquite, string tagName) : base(marquite, tagName)
        {
            AddClass("dropdown");
        }

        public DropdownBuilder(Core.Marquite marquite, string tagName, IHtmlBuilder triggeringElement, DropdownMenuBuilder menu)
            : base(marquite, tagName)
        {
            _triggeringElement = triggeringElement;
            _menu = menu;
            AddClass("dropdown");
        }

        public void Dropup()
        {
            RemoveClass("dropdown");
            AddClass("dropup");
        }

        private IRenderingClient _triggeringElement;
        private DropdownMenuBuilder _menu;

        public DropdownBuilder TriggeringElement(IRenderingClient element)
        {
            _triggeringElement = element;
            return this;
        }

        public DropdownBuilder Menu(DropdownMenuBuilder menu)
        {
            _menu = menu;
            return this;
        }

        protected override void PrepareForRender()
        {
            Trail(_triggeringElement);
            Trail(_menu);
            base.PrepareForRender();
        }
    }
}
