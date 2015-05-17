using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Extensions
{
    public static class TickTacksExtensions
    {
        public static SimpleHtmlBuilder Clearfix(this BootstrapPlugin t)
        {
            return new SimpleHtmlBuilder(t.Marquite,"div").AddClass("clearfix");
        }

        public static SimpleHtmlBuilder Caret(this BootstrapPlugin t)
        {
            return new SimpleHtmlBuilder(t.Marquite, "span").AddClass("caret");
        }

        public static SimpleHtmlBuilder CloseButton(this BootstrapPlugin t,string label = "Close")
        {
            return new SimpleHtmlBuilder(t.Marquite, "button")
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

        public static string CompiledGlyphIcon(this BootstrapPlugin t, GlyphIcon icon)
        {
            return CompiledGlyphIcons[icon];
        }

        public static SimpleHtmlBuilder GlyphIcon(this BootstrapPlugin t, GlyphIcon icon)
        {
            return new SimpleHtmlBuilder(t.Marquite, "span").AddClass(Lookups.Lookup(icon)).Aria("hidden", "true");
        }

        public static SimpleHtmlBuilder Badge(this BootstrapPlugin t, string badgeText)
        {
            return new SimpleHtmlBuilder(t.Marquite, "span").AddClass("badge").TrailingText(badgeText);
        }


        public static ElementHtmlBuilder<T> Tooltip<T>(this ElementHtmlBuilder<T> t, TooltipPlacement placement, string tooltipText)
            where T:ElementHtmlBuilder<T>
        {
            return t.Data("toggle", "tooltip").Data("placement", Lookups.Lookup(placement)).Title(tooltipText);
        }

        public static ElementHtmlBuilder<T> Popover<T>(this ElementHtmlBuilder<T> t, TooltipPlacement placement, string title, string content, bool dismissive = true)
            where T : ElementHtmlBuilder<T>
        {
            return t.Data("toggle", "popover")
                .Data("placement", Lookups.Lookup(placement))
                .Data("container","body")
                .Data("content",content)
                .Title(title)
                .When(dismissive, c => c.Data("trigger","focus"))
                ;
        }
    }
}
