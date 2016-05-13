using System;
using System.Web.Mvc;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;
using Marquite.Core.Html;

namespace Marquite.Bootstrap.Extensions
{
    public static class GlobalExtensions
    {

        public static BootstrapPlugin Bs(this HtmlHelper h)
        {
            return h.Marq().ResolvePlugin<BootstrapPlugin>();
        }

        public static BootstrapPlugin Bs(this Core.IMarquite m)
        {
            return m.ResolvePlugin<BootstrapPlugin>();
        }

        public static T TextLeft<T>(this T t) where T : ElementHtmlBuilder
        {
            return BootstrapTextAlign(t, TextAlign.Left);
        }

        public static T TextNowrap<T>(this T t) where T : ElementHtmlBuilder
        {
            t.AddClass("text-nowrap");
            return t;
        }

        public static T TextRight<T>(this T t) where T : ElementHtmlBuilder
        {
            return BootstrapTextAlign(t, TextAlign.Right);
        }

        public static T Role<T>(this T t, string role) where T : ElementHtmlBuilder
        {
            return t.Attr("role", role);
        }

        public static T TextCenter<T>(this T t) where T : ElementHtmlBuilder
        {
            return BootstrapTextAlign(t, TextAlign.Center);
        }

        public static T BootstrapTextAlign<T>(this T t, TextAlign align) where T : ElementHtmlBuilder
        {
            t.CategorizedCssClasses.CleanupAndAdd("bs-text-a", Lookups.Lookup(align));
            return t;
        }

        public static T Pull<T>(this T elem, BootstrapPull pull) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("pulls", Lookups.Lookup(pull));
            return elem;
        }

        public static T Background<T>(this T elem, Background color) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("bg-color", Lookups.Lookup(color));
            return elem;
        }

        public static T TextColor<T>(this T elem, TextColor color) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("text-color", Lookups.Lookup(color));
            return elem;
        }

        public static T ShowHide<T>(this T elem, Hiding hiding) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("hiding", Lookups.Lookup(hiding));
            return elem;
        }

        public static T VisibleOn<T>(this T elem, Device device, Display displayType) where T : ElementHtmlBuilder
        {
            var dev = "visible-" + Lookups.Lookup(device);
            elem.CategorizedCssClasses.CleanupAndAdd(dev, dev + "-" + Lookups.Lookup(displayType));

            return elem;
        }

        public static T VisibleOn<T>(this T elem, Device device) where T : ElementHtmlBuilder
        {
            return VisibleOn(elem, device, Display.Block);
        }

        public static T VisibleOn<T>(this T elem, params Device[] devices) where T : ElementHtmlBuilder
        {
            foreach (var device in devices)
            {
                return VisibleOn(elem, device, Display.Block);
            }
            return elem;
        }

        public static T HiddenOn<T>(this T elem, Device device) where T : ElementHtmlBuilder
        {
            var dev = "visible-" + Lookups.Lookup(device);
            elem.CategorizedCssClasses.CleanupAndAdd(dev, ("hidden-" + Lookups.Lookup(device)).Intern());
            return elem;
        }

        public static T HiddenOn<T>(this T elem, params Device[] devices) where T : ElementHtmlBuilder
        {
            foreach (var device in devices)
            {
                HiddenOn(elem, device);
            }
            return elem;
        }

        public static T TextCase<T>(this T elem, TextCasing casing) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("txt-casing", Lookups.Lookup(casing));
            return elem;
        }

        public static T AddCaret<T>(this T elem) where T : ElementHtmlBuilder
        {
            elem.Content(c => c.Append(elem.Marquite.Bs().Caret().Compile()));
            return elem;
        }

        public static T TrailIcon<T>(this T elem, GlyphIcon icon) where T : ElementHtmlBuilder
        {
            if (elem.TagName == "input")
            {
                throw new Exception("Cannot place icons inside input element");
            }
            elem.Content(c => c.Append(elem.Marquite.Bs().CompiledGlyphIcon(icon)));
            return elem;
        }

        public static T LeadIcon<T>(this T elem, GlyphIcon icon) where T : ElementHtmlBuilder
        {
            if (elem.TagName == "input")
            {
                throw new Exception("Cannot place icons inside input element");
            }
            elem.Content(c => c.Prepend(elem.Marquite.Bs().CompiledGlyphIcon(icon)));
            return elem;
        }

        public static T Color<T>(this T elem, Color c) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("el-color", Lookups.Lookup(c));
            return elem;
        }

        public static T Success<T>(this T elem) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Success));
            return elem;
        }

        public static T Danger<T>(this T elem) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Danger));
            return elem;
        }

        public static T Info<T>(this T elem) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Info));
            return elem;
        }

        public static T Warning<T>(this T elem) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Warning));
            return elem;
        }

        public static T Primary<T>(this T elem) where T : ElementHtmlBuilder
        {
            elem.CategorizedCssClasses.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Primary));
            return elem;
        }

        public static T SrOnly<T>(this T elem) where T : LabelBuilder
        {
            return elem.AddClass("sr-only");
        }

        #region Internal
        public static T MdWidth<T>(this T elem, int width) where T : BasicHtmlBuilder
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            elem.AddClass("col-md-" + width);
            return elem;
        }

        public static T XsWidth<T>(this T elem, int width) where T : BasicHtmlBuilder
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            elem.AddClass("col-xs-" + width);
            return elem;
        }

        public static T SmWidth<T>(this T elem, int width) where T : BasicHtmlBuilder
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            elem.AddClass("col-sm-" + width);
            return elem;
        }

        public static T LgWidth<T>(this T elem, int width) where T : BasicHtmlBuilder
        {
            if (width <= 0 || width > 12) throw new ArgumentException(Messages.Error_InvalidWidth, "width");
            elem.AddClass("col-lg-" + width);
            return elem;
        }

        public static T AllWidth<T>(this T elem, int width) where T : BasicHtmlBuilder
        {
            LgWidth(elem, width);
            SmWidth(elem, width);
            XsWidth(elem, width);
            MdWidth(elem, width);
            return elem;
        }

        public static T MdOffset<T>(this T elem, int offset) where T : BasicHtmlBuilder
        {
            if (offset <= 0 || offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "offset");
            elem.AddClass("col-md-offset-" + offset);
            return elem;
        }

        public static T XsOffset<T>(this T elem, int offset) where T : BasicHtmlBuilder
        {
            if (offset <= 0 || offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "offset");
            elem.AddClass("col-xs-offset-" + offset);
            return elem;
        }

        public static T SmOffset<T>(this T elem, int offset) where T : BasicHtmlBuilder
        {
            if (offset <= 0 || offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "offset");
            elem.AddClass("col-sm-offset-" + offset);
            return elem;
        }

        public static T LgOffset<T>(this T elem, int offset) where T : BasicHtmlBuilder
        {
            if (offset <= 0 || offset > 12) throw new ArgumentException(Messages.Error_InvalidOffset, "offset");
            elem.AddClass("col-lg-offset-" + offset);
            return elem;
        }

        public static T AllOffset<T>(this T elem, int offset) where T : BasicHtmlBuilder
        {
            LgOffset(elem, offset);
            SmOffset(elem, offset);
            XsOffset(elem, offset);
            MdOffset(elem, offset);
            return elem;
        }
        #endregion

    }
}
