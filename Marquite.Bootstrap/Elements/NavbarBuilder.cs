using System;
using System.IO;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class NavbarToggleButton : ButtonBuilderBase<NavbarToggleButton>
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
            toggleButton.NonGeneric_AddClass("navbar-toggle");
            toggleButton.NonGeneric_AddClass("collapsed");
            toggleButton.NonGeneric_Data("toggle", "collapse");
            if (string.IsNullOrEmpty(navId)) return;
            toggleButton.NonGeneric_Data("target", "#" + navId);
        }
    }
    public class NavbarBuilder : ElementHtmlBuilder<NavbarBuilder>
    {

        private IHtmlBuilder _toggleButton;
        private string _collapseId;
        private LinkBuilder _brandLink;

        public NavbarBuilder(Core.IMarquite marquite)
            : base(marquite, "nav")
        {
            AddClass("navbar");
            AddClass("navbar-default");
            _collapseId = marquite.GenerateNewId();
            _toggleButton = new NavbarToggleButton(marquite).Detached().Default(_collapseId);

            _brandLink = null;
        }

        public NavbarBuilder Inverse()
        {
            RemoveClass("navbar-default");
            AddClass("navbar-inverse");
            return this;
        }

        public NavbarBuilder Fix(NavbarFix fix)
        {
            CategorizedCssClasses.CleanupAndAdd("navbar_fix", Lookups.Lookup(fix));
            return this;
        }

        public NavbarBuilder AddItem(IHtmlBuilder builder, NavbarPlacement placement = NavbarPlacement.None)
        {
            builder.Detached().NonGeneric_AddClass(Lookups.Lookup(placement));
            RenderingQueue.Trail(builder);
            return this;
        }

        public NavbarBuilder AddNavigation(NavBuilder nav, NavbarPlacement placement = NavbarPlacement.None)
        {
            nav.Detached()
                .RemoveClass("nav-justified")
                .RemoveClass("nav-stacked")
                .RemoveClass("nav-tabs")
                .RemoveClass("nav-pills")
                .AddClass("navbar-nav");
            return AddItem(nav, placement);
        }

        public NavbarBuilder AddButton(BootstrapButtonBuilder button, NavbarPlacement placement = NavbarPlacement.None)
        {
            button.Detached().AddClass("navbar-btn");
            return AddItem(button, placement);
        }

        public NavbarBuilder AddForm(FormBuilder form, NavbarPlacement placement = NavbarPlacement.None)
        {
            form.Detached().AddClass("navbar-form");
            return AddItem(form, placement);
        }

        public NavbarBuilder AddText(string text, NavbarPlacement placement = NavbarPlacement.None)
        {
            SimpleHtmlBuilder pElement = new SimpleHtmlBuilder(Marquite, "p");
            pElement.TrailingText(text);
            pElement.AddClass("navbar-text");
            return AddItem(pElement, placement);
        }

        private LinkBuilder BrandLink()
        {
            return new LinkBuilder(Marquite).AddClass("navbar-brand");
        }

        public NavbarBuilder Brand(string brandName, string navUrl)
        {
            if (_brandLink == null) _brandLink = BrandLink();
            _brandLink.Href(navUrl);
            _brandLink.TrailingText(brandName);

            return this;
        }

        public NavbarBuilder Brand(IRenderingClient brandElement, string navUrl)
        {
            if (_brandLink == null) _brandLink = BrandLink();
            _brandLink.Href(navUrl);
            _brandLink.TrailingHtml(brandElement.Detached());
            return this;
        }

        public NavbarBuilder ToggleButton(NavbarToggleButton toggleButton)
        {
            NavbarToggleButton.SetToggleButtonAttributes(toggleButton, _collapseId);
            _toggleButton = toggleButton.Detached();
            return this;
        }

        public NavbarBuilder ToggleButton(ButtonBuilder toggleButton)
        {
            NavbarToggleButton.SetToggleButtonAttributes(toggleButton, _collapseId);
            _toggleButton = toggleButton.Detached();
            return this;
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
