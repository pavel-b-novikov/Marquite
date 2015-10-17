using System.IO;
using System.Text;
using System.Web;

namespace Marquite.Core.Rendering
{
    public static class Renderer
    {
        public static string Render(IRenderingClient client)
        {
            StringBuilder sb = new StringBuilder();
            using (var tw = new StringWriter(sb))
            {
                Render(tw, client);
            }
            return sb.ToString();
        }

        public static string Render(RenderingQueue queue)
        {
            StringBuilder sb = new StringBuilder();
            using (var tw = new StringWriter(sb))
            {
                queue.RenderQueue(tw);
            }
            return sb.ToString();
        }

        public static void Render(TextWriter tw, IRenderingClient client)
        {
            if (client == null) return;
            client.PrepareForRender();

            client.RenderBeforeOpenTag(tw);
            client.RenderOpeningTag(tw);
            client.RenderAfterOpeningTag(tw);

            client.RenderContent(tw);

            client.RenderBeforeClosingTag(tw);
            client.RenderClosingTag(tw);
            client.RenderAfterClosingTag(tw);
        }

        internal static void Render(TextWriter tw, RenderingItem item)
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

                Render(tw, item.RenderingClient);

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
    }
}
