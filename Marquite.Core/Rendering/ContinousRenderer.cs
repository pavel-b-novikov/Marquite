using System.IO;
using System.Text;

namespace Marquite.Core.Rendering
{
    public static class ContinousRenderer
    {
        public static string Render(IRenderingClient client)
        {
            StringBuilder sb = new StringBuilder();
            using (var tw = new StringWriter(sb))
            {
                client.RenderBeforeOpenTag(tw);
                client.RenderOpeningTag( tw);
                client.RenderAfterOpeningTag(tw);

                client.RenderContent( tw);

                client.RenderBeforeClosingTag( tw);
                client.RenderClosingTag( tw);
                client.RenderAfterClosingTag( tw);
            }
            return sb.ToString();
        }
    }
}
