using System;
using System.IO;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.Rendering
{
    public class RenderingTagScope : ITagScope
    {
        private readonly IHtmlBuilder _parentTagBuilder;

        public RenderingTagScope(IHtmlBuilder parentTagBuilder, bool renderContentAtTop = false)
        {
            _parentTagBuilder = parentTagBuilder;
            _renderContentAtTop = renderContentAtTop;
        }

        private TextWriter _writer;
        private readonly bool _renderContentAtTop;

        public void Render()
        {
            _writer = _parentTagBuilder.Marquite.GetTopmostWriter();
            _parentTagBuilder.RenderBeforeOpenTag(_writer);
            _parentTagBuilder.RenderOpeningTag(_writer);
            _parentTagBuilder.RenderAfterOpeningTag(_writer);
            if (_renderContentAtTop) _parentTagBuilder.RenderContent(_writer); 
        }

        public void Dispose()
        {
            if (!_renderContentAtTop) _parentTagBuilder.RenderContent(_writer);
            _parentTagBuilder.RenderBeforeClosingTag(_writer);
            _parentTagBuilder.RenderClosingTag(_writer);
            _parentTagBuilder.RenderAfterClosingTag(_writer);
        }
    }
}
