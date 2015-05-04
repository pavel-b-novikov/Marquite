using System.IO;

namespace Marquite.Core.Rendering
{
    public interface IRenderingClient
    {
        Core.Marquite Marquite { get; }
        void RenderBeforeOpenTag(TextWriter tw);
        void RenderOpeningTag( TextWriter tw);
        void RenderAfterOpeningTag( TextWriter tw);
        void RenderContent( TextWriter tw);
        void RenderBeforeClosingTag( TextWriter tw);
        void RenderClosingTag( TextWriter tw);
        void RenderAfterClosingTag( TextWriter tw);
    }
}
