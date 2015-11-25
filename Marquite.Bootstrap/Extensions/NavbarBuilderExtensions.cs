using Marquite.Bootstrap.Elements;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;
using Marquite.Core.Html;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    public static class NavbarBuilderExtensions
    {
        public static T Inverse<T>(this T b) where T :  NavbarBuilder 
        {
            b.RemoveClass("navbar-default");
            b.AddClass("navbar-inverse");
            return b;
        }

        public static T Fix<T>(this T b,NavbarFix fix) where T :  NavbarBuilder 
        {
            b.CategorizedCssClasses.CleanupAndAdd("navbar_fix", Lookups.Lookup(fix));
            return b;
        }

        public static T AddItem<T>(this T b,IHtmlBuilder builder, NavbarPlacement placement = NavbarPlacement.None) where T :  NavbarBuilder 
        {
            builder.Detached().AddClass(Lookups.Lookup(placement));
            b.RenderingQueue.Trail(builder);
            return b;
        }

        public static T AddNavigation<T>(this T b,NavBuilder nav, NavbarPlacement placement = NavbarPlacement.None) where T :  NavbarBuilder 
        {
            nav.Detached()
                .RemoveClass("nav-justified")
                .RemoveClass("nav-stacked")
                .RemoveClass("nav-tabs")
                .RemoveClass("nav-pills")
                .AddClass("navbar-nav");
            return AddItem(b,nav, placement);
        }

        public static T AddButton<T>(this T b,BootstrapButtonBuilder button, NavbarPlacement placement = NavbarPlacement.None) where T :  NavbarBuilder 
        {
            button.Detached().AddClass("navbar-btn");
            return AddItem(b,button, placement);
        }

        public static T AddForm<T>(this T b,FormBuilder form, NavbarPlacement placement = NavbarPlacement.None) where T :  NavbarBuilder 
        {
            form.Detached().AddClass("navbar-form");
            return AddItem(b, form, placement);
        }

        public static T AddText<T>(this T b, string text, NavbarPlacement placement = NavbarPlacement.None) where T : NavbarBuilder 
        {
            SimpleHtmlBuilder pElement = new SimpleHtmlBuilder(b.Marquite, "p");
            BasicHtmlBuilderExtensions.AppendText(pElement, text);
            pElement.AddClass("navbar-text");
            return AddItem(b, pElement, placement);
        }

        private static LinkBuilder BrandLink<T>(this T b) where T :  NavbarBuilder 
        {
            return new LinkBuilder(b.Marquite).AddClass("navbar-brand");
        }

        public static T Brand<T>(this T b,string brandName, string navUrl) where T :  NavbarBuilder 
        {
            if (b._brandLink == null) b._brandLink = BrandLink(b);
            b._brandLink.Href(navUrl);
            BasicHtmlBuilderExtensions.AppendText(b._brandLink, brandName);

            return b;
        }

        public static T Brand<T>(this T b,IRenderingClient brandElement, string navUrl) where T :  NavbarBuilder 
        {
            if (b._brandLink == null) b._brandLink = BrandLink(b);
            b._brandLink.Href(navUrl);
            b._brandLink.Append(brandElement.Detached());
            return b;
        }

        public static T ToggleButton<T>(this T b,NavbarToggleButton toggleButton) where T :  NavbarBuilder 
        {
            NavbarToggleButton.SetToggleButtonAttributes(toggleButton, b._collapseId);
            b._toggleButton = toggleButton.Detached();
            return b;
        }

        public static T ToggleButton<T>(this T b,ButtonBuilder toggleButton) where T :  NavbarBuilder 
        {
            NavbarToggleButton.SetToggleButtonAttributes(toggleButton, b._collapseId);
            b._toggleButton = toggleButton.Detached();
            return b;
        }
    }
}