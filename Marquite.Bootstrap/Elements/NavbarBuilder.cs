using System;
using System.IO;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class NavbarToggleButton : ButtonBuilder
    {
        public NavbarToggleButton(Core.IMarquite marquite)
            : base(marquite, "button")
        {

        }

        public NavbarToggleButton Default(string navId, string text = "Toggle navigation")
        {
            RenderingQueue.Trail(text, "span", wrappingTagAttrs: HtmlText.Class("sr-only"));
            RenderingQueue.Trail(String.Empty, "span", wrappingTagAttrs: HtmlText.Class("icon-bar"));
            RenderingQueue.Trail(String.Empty, "span", wrappingTagAttrs: HtmlText.Class("icon-bar"));
            RenderingQueue.Trail(String.Empty, "span", wrappingTagAttrs: HtmlText.Class("icon-bar"));
            SetToggleButtonAttributes(this, navId);
            return this;
        }

        public static void SetToggleButtonAttributes(IHtmlBuilder toggleButton, string navId)
        {
            toggleButton.AddClass("navbar-toggle");
            toggleButton.AddClass("collapsed");
            toggleButton.Data("toggle", "collapse");
            if (string.IsNullOrEmpty(navId)) return;
            toggleButton.Data("target", "#" + navId);
        }
    }
    public class NavbarBuilder : ElementHtmlBuilder
    {

        internal IHtmlBuilder _toggleButton;
        internal string _collapseId;
        internal LinkBuilder _brandLink;

        public NavbarBuilder(Core.IMarquite marquite)
            : base(marquite, "nav")
        {
            this.AddClass("navbar");
            this.AddClass("navbar-default");
            _collapseId = marquite.GenerateNewId();
            _toggleButton = new NavbarToggleButton(marquite).Detached().Default(_collapseId);

            _brandLink = null;
        }

        

        public override void RenderAfterOpeningTag(TextWriter tw)
        {
            tw.Write(HtmlText.OpenTag("div", HtmlText.Class("container-fluid")));
            tw.Write(HtmlText.OpenTag("div", HtmlText.Class("navbar-header")));
            Renderer.Render(tw, _toggleButton);
            if (_brandLink != null) Renderer.Render(tw, _brandLink);
            tw.Write(HtmlText.ClosingTag("div")); // /.navbar-header
            tw.Write(HtmlText.OpenTag("div", HtmlText.Classes("collapse", "navbar-collapse"), HtmlText.Id(_collapseId)));
            base.RenderAfterOpeningTag(tw);
        }

        public override void RenderBeforeClosingTag(TextWriter tw)
        {
            tw.Write(HtmlText.ClosingTag("div")); // /.navbar-collapse
            tw.Write(HtmlText.ClosingTag("div")); // /.container-fluid
            base.RenderBeforeClosingTag(tw);
        }
    }

    [LookupEnum]
    public enum NavbarFix
    {
        [LookupString("navbar-fixed-top")]
        Top,
        [LookupString("navbar-fixed-bottom")]
        Bottom,
        [LookupString("navbar-static-top")]
        StaticTop
    }

    [LookupEnum]
    public enum NavbarPlacement
    {
        [LookupString("")]
        None,

        [LookupString("navbar-left")]
        Left,

        [LookupString("navbar-right")]
        Right
    }
}
