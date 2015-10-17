using System.IO;
using System.Web;

namespace Marquite.Core.Rendering
{
    public interface IRenderingClient: IHtmlString
    {
        Core.IMarquite Marquite { get; }
        void PrepareForRender();
        void RenderBeforeOpenTag(TextWriter tw);
        void RenderOpeningTag( TextWriter tw);
        void RenderAfterOpeningTag( TextWriter tw);
        void RenderContent( TextWriter tw);
        void RenderBeforeClosingTag( TextWriter tw);
        void RenderClosingTag( TextWriter tw);
        void RenderAfterClosingTag( TextWriter tw);
    }
}
