using System.IO;
using System.Web;
using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public static class RenderingClientExtensions
    {
        internal static void RenderItem(this TextWriter tw, RenderingItem item)
        {
            if (item.RenderingClient != null)
            {
                if (item.WrappingTag != null)
                {
                    tw.Write('<');
                    tw.Write(item.WrappingTag);

                    if (item.WrappingTagAttrs != null)
                    {
                        tw.ChainWrite(' ').Write(item.WrappingTagAttrs);
                    }
                    tw.Write('>');
                }

                RenderClient(tw, item.RenderingClient);

                if (item.WrappingTag != null)
                {
                    tw.Write("</");
                    tw.Write(item.WrappingTag);
                    tw.Write('>');
                }
            }

            if (item.StringContent != null)
            {
                if (item.WrappingTag != null)
                {
                    tw.Write('<');
                    tw.Write(item.WrappingTag);
                    if (item.WrappingTagAttrs != null)
                    {
                        tw.ChainWrite(' ').Write(item.WrappingTagAttrs);
                    }
                    tw.Write('>');
                }

                tw.Write(item.Encode ? HttpUtility.HtmlEncode(item.StringContent) : item.StringContent);

                if (item.WrappingTag != null)
                {
                    tw.Write("</");
                    tw.Write(item.WrappingTag);
                    tw.Write('>');
                }
            }
        }
        public static void RenderClient(this TextWriter tw, IRenderingClient client)
        {
            client.RenderBeforeOpenTag(tw);
            client.RenderOpeningTag(tw);
            client.RenderAfterOpeningTag(tw);

            client.RenderContent(tw);

            client.RenderBeforeClosingTag(tw);
            client.RenderClosingTag(tw);
            client.RenderAfterClosingTag(tw);
        }

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
