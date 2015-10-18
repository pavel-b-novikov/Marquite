﻿using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class DropdownBuilder : ElementHtmlBuilder<DropdownBuilder>
    {
        public DropdownBuilder(Core.IMarquite marquite, string tagName) : base(marquite, tagName)
        {
            AddClass("dropdown");
        }

        public DropdownBuilder(Core.IMarquite marquite, string tagName, IHtmlBuilder triggeringElement, DropdownMenuBuilder menu)
            : base(marquite, tagName)
        {
            _triggeringElement = triggeringElement.Detached();
            _menu = menu.Detached();
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
            _triggeringElement = element.Detached();
            return this;
        }

        public DropdownBuilder Menu(DropdownMenuBuilder menu)
        {
            _menu = menu.Detached();
            return this;
        }

        public override void PrepareForRender()
        {
            RenderingQueue.Trail(_triggeringElement);
            RenderingQueue.Trail(_menu);
            base.PrepareForRender();
        }
    }
}
