using System;
using System.IO;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class ImageBuilder : ImageBuilderBase<ImageBuilder>
    {
        public ImageBuilder(IMarquite marquite, string src = null, string alt = null) : base(marquite, src, alt)
        {
        }
    }
    public class ImageBuilderBase<T> : ElementHtmlBuilder<T> where T : ImageBuilderBase<T>
    {
        public ImageBuilderBase(Core.IMarquite marquite, string src = null, string alt = null)
            : base(marquite, "img")
        {
            if (!string.IsNullOrEmpty(src)) Source(src);
            if (!string.IsNullOrEmpty(alt)) AltText(alt);
        }

        public T Source(string path)
        {
            return Attr("src", path);
        }

        public T AltText(string text)
        {
            return Attr("alt", text);
        }

        public override ITagScope Open(bool pullExistingContentAtTop = false)
        {
            throw new Exception(Messages.Error_InvalidImage);
        }

        public override T TrailingHtml(string html)
        {
            throw new Exception(Messages.Error_InvalidImage);
        }

        public override T TrailingHtml(IRenderingClient content)
        {
            throw new Exception(Messages.Error_InvalidImage);
        }

        public override void RenderContent(TextWriter tw) { }

        public override void RenderClosingTag(TextWriter tw) { }
    }
}
