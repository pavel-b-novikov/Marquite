using System.IO;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class PanelBuilder : ElementHtmlBuilder<PanelBuilder>
    {
        public PanelBuilder(Core.IMarquite marquite) : base(marquite, "div")
        {
            AddClass("panel");
        }

        public PanelBuilder Color(PanelColor color)
        {
            CategorizedCssClasses.CleanupAndAdd("panelColor",Lookups.Lookup(color));
            return this;
        }
        private readonly RenderingQueue _panelHeading = new RenderingQueue();

        public PanelBuilder AppendToHeading(IRenderingClient content)
        {
            _panelHeading.Trail(content);
            return this;
        }

        public PanelBuilder PanelTitle(string title,string tag = "h3")
        {
            _panelHeading.Trail(title, tag, wrappingTagAttrs: HtmlText.Class("panel-title"));
            return this;
        }

        public override void RenderAfterOpeningTag(TextWriter tw)
        {
            base.RenderAfterOpeningTag(tw);
            if (_panelHeading.Count > 0)
            {
                tw.Write(HtmlText.OpenTag("div", HtmlText.Class("panel-heading")));
                _panelHeading.RenderQueue(tw);
                tw.Write(HtmlText.ClosingTag("div"));
            }
            tw.Write(HtmlText.OpenTag("div", HtmlText.Class("panel-body")));
        }

        public override void RenderBeforeClosingTag(TextWriter tw)
        {
            tw.Write(HtmlText.ClosingTag("div"));
            _afterBodyQueue.RenderQueue(tw);
        }

        private readonly RenderingQueue _afterBodyQueue = new RenderingQueue();

        public virtual PanelBuilder AfterBodyLeadingHtml(string html)
        {
            _afterBodyQueue.Lead(html);
            return this;
        }

        public virtual PanelBuilder AfterBodyLeadingText(string text)
        {
            _afterBodyQueue.Lead(text, encode: true);
            return this;
        }

        public virtual PanelBuilder AfterBodyLeadingHtml(IRenderingClient content)
        {
            _afterBodyQueue.Lead(content);
            return this;
        }

        public virtual PanelBuilder AfterBodyTrailingHtml(string html)
        {
            _afterBodyQueue.Trail(html);
            return this;
        }

        public virtual PanelBuilder AfterBodyTrailingText(string text)
        {
            _afterBodyQueue.Trail(text, encode: true);
            return this;
        }

        public virtual PanelBuilder AfterBodyTrailingHtml(IRenderingClient content)
        {
            _afterBodyQueue.Trail(content);
            return this;
        }

    }

    [LookupEnum]
    public enum PanelColor
    {
        [LookupString("panel-default")]
        Default,
        [LookupString("panel-primary")]
        Primary,
        [LookupString("panel-success")]
        Success,
        [LookupString("panel-info")]
        Info,
        [LookupString("panel-warning")]
        Warning,
        [LookupString("panel-danger")]
        Danger
    }
}
