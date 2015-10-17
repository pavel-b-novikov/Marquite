using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Marquite.Core.ElementBuilders;

namespace Marquite.Core.Html
{
    public static class ImageExtensions
    {
        public static ImageBuilder Image(this HtmlHelper h, string src = null, string alt = null)
        {
            return new ImageBuilder(h.Marq(),src,alt);
        }
        
    }
}
