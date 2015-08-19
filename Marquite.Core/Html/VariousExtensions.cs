using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.ElementBuilders;

namespace Marquite.Core.Html
{
    public static class VariousExtensions
    {
        public static ImageBuilder Image(this Core.IMarquite b, string src = null, string alternativeText = null)
        {
            return new ImageBuilder(b, src, alternativeText);
        }
    }
}
