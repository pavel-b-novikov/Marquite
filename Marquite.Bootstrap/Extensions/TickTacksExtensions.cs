using System;
using System.Collections.Generic;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Extensions
{
    public static class TickTacksExtensions
    {
        /// <summary>
        /// Easily clear floats by adding .clearfix to the parent element. 
        /// Utilizes the micro clearfix as popularized by Nicolas Gallagher. Can also be used as a mixin.
        /// </summary>
        /// <param name="t">Bootstrap</param>
        /// <returns>SimpleHtmlBuilder</returns>
        public static SimpleHtmlBuilder Clearfix(this BootstrapPlugin t)
        {
            return new SimpleHtmlBuilder(t.Marquite,"div").AddClass("clearfix");
        }

        /// <summary>
        /// Use carets to indicate dropdown functionality and direction. 
        /// Note that the default caret will reverse automatically in dropup menus.
        /// </summary>
        /// <param name="t">Bootstrap</param>
        /// <returns>SimpleHtmlBuilder</returns>
        public static SimpleHtmlBuilder Caret(this BootstrapPlugin t)
        {
            return new SimpleHtmlBuilder(t.Marquite, "span").AddClass("caret");
        }

        /// <summary>
        /// Use the generic close icon for dismissing content like modals and alerts.
        /// </summary>
        /// <param name="t">Bootstrap</param>
        /// <param name="label">Close button label</param>
        /// <returns>SimpleHtmlBuilder</returns>
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

        /// <summary>
        /// Produces compiled to string Twitter Bootstrap Glyphicon
        /// Includes over 250 glyphs in font format from the Glyphicon Halflings set. 
        /// Glyphicons Halflings are normally not available for free, but their creator has made them available 
        /// for Bootstrap free of cost. 
        /// As a thank you, we only ask that you include a link back to Glyphicons whenever possible.
        /// Don't mix with other components.
        /// Only for use on empty elements.
        /// This method automatically adds aria-hidden="true" to generated glyphicon to avoit its automated reading by SR
        /// </summary>
        /// <param name="t"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static string CompiledGlyphIcon(this BootstrapPlugin t, GlyphIcon icon)
        {
            return CompiledGlyphIcons[icon];
        }

        /// <summary>
        /// Produces Twitter Bootstrap Glyphicon
        /// Includes over 250 glyphs in font format from the Glyphicon Halflings set. 
        /// Glyphicons Halflings are normally not available for free, but their creator has made them available 
        /// for Bootstrap free of cost. 
        /// As a thank you, we only ask that you include a link back to Glyphicons whenever possible.
        /// Don't mix with other components.
        /// Only for use on empty elements.
        /// This method automatically adds aria-hidden="true" to generated glyphicon to avoit its automated reading by SR
        /// </summary>
        /// <param name="t"></param>
        /// <param name="icon">Glyph icon</param>
        /// <returns></returns>
        public static SimpleHtmlBuilder GlyphIcon(this BootstrapPlugin t, GlyphIcon icon)
        {
            return new SimpleHtmlBuilder(t.Marquite, "span").AddClass(Lookups.Lookup(icon)).Aria("hidden", "true");
        }

        /// <summary>
        /// Easily highlight new or unread items by using this methow within, Bootstrap navs, and more.
        /// </summary>
        /// <param name="t">Bootstrap</param>
        /// <param name="badgeText">Badge text</param>
        /// <returns>SimpleHtmlBuilder</returns>
        public static SimpleHtmlBuilder Badge(this BootstrapPlugin t, string badgeText)
        {
            return new SimpleHtmlBuilder(t.Marquite, "span").AddClass("badge").TrailingText(badgeText);
        }

        /// <summary>
        /// Inspired by the excellent jQuery.tipsy plugin written by Jason Frame; Tooltips are an updated version, which don't rely on images, use CSS3 for animations, and data-attributes for local title storage.
        /// Tooltips with zero-length titles are never displayed.
        /// For performance reasons, the Tooltip and Popover data-apis are opt-in, meaning you must initialize them yourself.
        /// One way to initialize all tooltips on a page would be to select them by their data-toggle attribute:
        /// $(function () {
        ///     $('[data-toggle="tooltip"]').tooltip()
        /// })
        /// Don't try to show tooltips on hidden elements
        /// Tooltips on disabled elements require wrapper elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">Element</param>
        /// <param name="placement">Tooltip placement</param>
        /// <param name="tooltipText">Tooltip text</param>
        /// <returns>ElementHtmlBuilder</returns>
        public static T Tooltip<T>(this T t, TooltipPlacement placement, string tooltipText)
            where T:ElementHtmlBuilder
        {
            return t.Data("toggle", "tooltip").Data("placement", Lookups.Lookup(placement)).Title(tooltipText);
        }


        /// <summary>
        /// Add small overlays of content, like those on the iPad, to any element for housing secondary information.
        /// Popovers whose both title and content are zero-length are never displayed.
        /// One way to initialize all popovers on a page would be to select them by their data-toggle attribute:
        /// $(function () {
        ///     $('[data-toggle="tooltip"]').tooltip()
        /// })
        /// Popovers on disabled elements require wrapper elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="placement">Four options are available: top, right, bottom, and left aligned.</param>
        /// <param name="title">Popover title</param>
        /// <param name="content">Popover content</param>
        /// <param name="dismissive">Dismiss popovers on the next click that the user makes</param>
        /// <returns></returns>
        public static T Popover<T>(this T t, TooltipPlacement placement, string title, string content, bool dismissive = true)
            where T : ElementHtmlBuilder
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
