using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Marquite.Core;

namespace Marquite.Bootstrap.Extensions
{
    public static class TickTacksExtensions
    {
        public static SimpleHtmlBuilder Clearfix(this Core.Marquite t)
        {
            return new SimpleHtmlBuilder(t,"div").AddClass("clearfix");
        }

        public static SimpleHtmlBuilder Caret(this Core.Marquite t)
        {
            return new SimpleHtmlBuilder(t, "span").AddClass("caret");
        }

        public static SimpleHtmlBuilder CloseButton(this Core.Marquite t,string label = "Close")
        {
            return new SimpleHtmlBuilder(t, "button")
                .Attr("type","button")
                .AddClass("close")
                .Attr("aria-label",label)
                .TrailingHtml("<span aria-hidden=\"true\">&times;</span>")
                ;
        }

        private static readonly Dictionary<GlyphIcon, string> CompiledGlyphIcons = new Dictionary<GlyphIcon, string>();

        static TickTacksExtensions()
        {
            CompileGlyphicons();
        }

        private static void CompileGlyphicons()
        {
            var vals = Enum.GetValues(typeof (GlyphIcon));
            foreach (var v in vals)
            {
                CompiledGlyphIcons[(GlyphIcon) v] =
                    (string.Format("<span class=\"{0}\" aria-hidden=\"true\"></span>",
                        Lookups.Lookup((GlyphIcon)v)));
            }
        }

        public static string CompiledGlyphIcon(this Core.Marquite t, GlyphIcon icon)
        {
            return CompiledGlyphIcons[icon];
        }

        public static BootstrapElementBuilder GlyphIcon(this Core.Marquite t, GlyphIcon icon)
        {
            return new BootstrapElementBuilder(t,"span").AddClass(Lookups.Lookup(icon)).Aria("hidden","true");
        }
    }
}
