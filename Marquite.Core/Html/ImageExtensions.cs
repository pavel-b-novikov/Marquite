using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Marquite.Core.Elements;
using Marquite.Core.Rendering;

namespace Marquite.Core.Html
{
    public static class ImageExtensions
    {
        public static ImageBuilder Image(this HtmlHelper h, string src = null, string alt = null)
        {
            return new ImageBuilder(h.Marq(), src, alt);
        }

        public static T Source<T>(this T b, string src) where T : ImageBuilder
        {
            return b.Attr("src", src);
        }

        public static T AltText<T>(this T b, string alt) where T : ImageBuilder
        {
            return b.Attr("alt", alt);
        }

        public static ImageBuilder TrailingHtml(this ImageBuilder b, string html)
        {
            throw new Exception(Messages.Error_InvalidImage);
        }

        public static ImageBuilder TrailingHtml(this ImageBuilder b, IRenderingClient content)
        {
            throw new Exception(Messages.Error_InvalidImage);
        }
        
    }
}
