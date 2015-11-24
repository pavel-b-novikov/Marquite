using System;
using System.IO;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class ImageBuilder : ElementHtmlBuilder
    {
        public ImageBuilder(Core.IMarquite marquite, string src = null, string alt = null)
            : base(marquite, "img")
        {
            if (!string.IsNullOrEmpty(src)) this.Source(src);
            if (!string.IsNullOrEmpty(alt)) this.AltText(alt);
        }
        
        public override ITagScope Open(bool pullExistingContentAtTop = false)
        {
            throw new Exception(Messages.Error_InvalidImage);
        }

        public override void RenderContent(TextWriter tw) { }

        public override void RenderClosingTag(TextWriter tw) { }
    }
}
