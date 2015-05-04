using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class ImageBuilder : BootstrapBasicBuilder<ImageBuilder>
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

        public ImageBuilder Style(ImageStyle style)
        {
            return AddClass(Lookups.Lookup(style));
        }

        public ImageBuilder Rounded()
        {
            return Style(ImageStyle.Rounded);
        }

        public ImageBuilder Circle()
        {
            return Style(ImageStyle.Circle);
        }

        public ImageBuilder Thumbnail()
        {
            return Style(ImageStyle.Thumbnail);
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
