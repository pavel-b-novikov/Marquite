using System;
using System.IO;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class ImageBuilder : ElementHtmlBuilder<ImageBuilder>
    {
        public ImageBuilder(Core.Marquite marquite,string src = null,string alt = null) : base(marquite, "img")
        {
            if (!string.IsNullOrEmpty(src)) Source(src);
            if (!string.IsNullOrEmpty(alt)) AltText(alt);
        }

        public ImageBuilder Source(string path)
        {
            return Attr("src", path);
        }

        public ImageBuilder AltText(string text)
        {
            return Attr("alt", text);
        }

        public override InnerTagScope Open()
        {
            throw new Exception(Messages.Error_InvalidImage);
        }

        public override ImageBuilder TrailingHtml(string html)
        {
            throw new Exception(Messages.Error_InvalidImage);
        }

        public override ImageBuilder TrailingHtml(IRenderingClient content)
        {
            throw new Exception(Messages.Error_InvalidImage);
        }

        protected override void RenderContent(TextWriter tw) { }

        protected override void RenderClosingTag(TextWriter tw) { }
    }
}
