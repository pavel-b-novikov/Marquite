using System.IO;
using System.Web;
using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public static class RenderingClientExtensions
    {
        
        

        public static TextWriter ChainWrite(this TextWriter tw, string str)
        {
            tw.Write(str);
            return tw;
        }

        public static TextWriter ChainWrite(this TextWriter tw, char c)
        {
            tw.Write(c);
            return tw;
        }
    }
}
