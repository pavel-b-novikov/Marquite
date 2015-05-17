﻿using System.Web.Mvc;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Html;

namespace Marquite.Bootstrap.Extensions
{
    public static class GlobalExtensions
    {
        public static BootstrapPlugin Bootstrap(this HtmlHelper h)
        {
            return h.Marquite().ResolvePlugin<BootstrapPlugin>();
        }

        public static BootstrapPlugin Bootstrap(this Core.Marquite m)
        {
            return m.ResolvePlugin<BootstrapPlugin>();
        }

        public static T TextLeft<T>(this T t) where T : ElementHtmlBuilder<T>
        {
            return BootstrapTextAlign(t, TextAlign.Left);
        }

        public static T TextNowrap<T>(this T t) where T : ElementHtmlBuilder<T>
        {
            t.AddClass("text-nowrap");
            return t;
        }

        public static T TextRight<T>(this T t) where T : ElementHtmlBuilder<T>
        {
            return BootstrapTextAlign(t, TextAlign.Right);
        }

        public static T Role<T>(this T t, string role) where T : ElementHtmlBuilder<T>
        {
            return t.Attr("role",role);
        }

        public static T TextCenter<T>(this T t) where T : ElementHtmlBuilder<T>
        {
            return BootstrapTextAlign(t, TextAlign.Center);
        }

        public static T BootstrapTextAlign<T>(this T t, TextAlign align) where T : ElementHtmlBuilder<T>
        {
            t.TagsCategory.CleanupAndAdd("bs-text-a",Lookups.Lookup(align));
            return t;
        }

        public static T Pull<T>(this T elem, BootstrapPull pull) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("pulls", Lookups.Lookup(pull));
            return elem;
        }

        public static T Background<T>(this T elem, Background color) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("bg-color", Lookups.Lookup(color));
            return elem;
        }

        public static T TextColor<T>(this T elem, TextColor color) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("text-color", Lookups.Lookup(color));
            return elem;
        }

        public static T ShowHide<T>(this T elem, Hiding hiding) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("hiding", Lookups.Lookup(hiding));
            return elem;
        }

        public static T VisibleOn<T>(this T elem, Device device, Display displayType) where T : ElementHtmlBuilder<T>
        {
            var dev = "visible-" + Lookups.Lookup(device);
            elem.TagsCategory.CleanupAndAdd(dev, dev + "-" + Lookups.Lookup(displayType));

            return elem;
        }

        public static T VisibleOn<T>(this T elem, Device device) where T : ElementHtmlBuilder<T>
        {
            return VisibleOn(elem, device, Display.Block);
        }

        public static T VisibleOn<T>(this T elem, params Device[] devices) where T : ElementHtmlBuilder<T>
        {
            foreach (var device in devices)
            {
                return VisibleOn(elem, device, Display.Block);
            }
            return elem;
        }

        public static T HiddenOn<T>(this T elem, Device device) where T : ElementHtmlBuilder<T>
        {
            var dev = "visible-" + Lookups.Lookup(device);
            elem.TagsCategory.CleanupAndAdd(dev, ("hidden-" + Lookups.Lookup(device)).Intern());
            return elem;
        }

        public static T HiddenOn<T>(this T elem, params Device[] devices) where T : ElementHtmlBuilder<T>
        {
            foreach (var device in devices)
            {
                HiddenOn(elem, device);
            }
            return elem;
        }

        public static T TextCase<T>(this T elem, TextCasing casing) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("txt-casing", Lookups.Lookup(casing));
            return elem;
        }

        public static T AddCaret<T>(this T elem) where T : ElementHtmlBuilder<T>
        {
            elem.TrailingHtml(elem.Marquite.Bootstrap().Caret().Compile());
            return elem;
        }

        public static T TrailIcon<T>(this T elem, GlyphIcon icon) where T : ElementHtmlBuilder<T>
        {
            elem.TrailingHtml(elem.Marquite.Bootstrap().CompiledGlyphIcon(icon));
            return elem;
        }

        public static T LeadIcon<T>(this T elem, GlyphIcon icon) where T : ElementHtmlBuilder<T>
        {
            elem.TrailingHtml(elem.Marquite.Bootstrap().CompiledGlyphIcon(icon));
            return elem;
        }

        public static T Color<T>(this T elem, Color c) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(c));
            return elem;
        }

        public static T Success<T>(this T elem) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Success));
            return elem;
        }

        public static T Danger<T>(this T elem) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Danger));
            return elem;
        }

        public static T Info<T>(this T elem) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Info));
            return elem;
        }

        public static T Warning<T>(this T elem) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Warning));
            return elem;
        }

        public static T Primary<T>(this T elem) where T : ElementHtmlBuilder<T>
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Marquite.Bootstrap.Color.Primary));
            return elem;
        }

        public static T SrOnly<T>(this T elem) where T : LabelBuilderBase<T>
        {
            return elem.AddClass("sr-only");
        }

    }
}
