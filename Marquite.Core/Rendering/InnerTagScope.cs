using System;
using System.IO;

namespace Marquite.Core.Rendering
{
    public class InnerTagScope : IDisposable
    {
        private readonly bool _renderContentAtTop;

        public InnerTagScope(bool renderContentAtTop)
        {
            _renderContentAtTop = renderContentAtTop;
        }

        private IRenderingClient _renderingClient;

        private TextWriter _writer;

        public void Render(IRenderingClient renderingClient)
        {
            _writer = renderingClient.Marquite.ViewContext.Writer;
            _renderingClient = renderingClient;
            _renderingClient.RenderBeforeOpenTag(_writer);
            _renderingClient.RenderOpeningTag(_writer);
            _renderingClient.RenderAfterOpeningTag(_writer);
            if (!_renderContentAtTop) _renderingClient.RenderContent(_writer); 
        }

        public void Dispose()
        {
            if (_renderContentAtTop) _renderingClient.RenderContent(_writer);
            _renderingClient.RenderBeforeClosingTag(_writer);
            _renderingClient.RenderClosingTag(_writer);
            _renderingClient.RenderAfterClosingTag(_writer);
        }
    }
}
