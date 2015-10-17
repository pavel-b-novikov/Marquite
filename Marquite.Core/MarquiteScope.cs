using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public class MarquiteScope : RenderingClientBase
    {
        private readonly RenderingQueue _renderingQueue = new RenderingQueue();
        private readonly IMarquite _marquite;

        public MarquiteScope(IMarquite marquite)
        {
            _marquite = marquite;
        }

        public RenderingQueue RenderingQueue { get { return _renderingQueue; } }

        public void Append(IRenderingClient builder)
        {
            _renderingQueue.Trail(builder);
        }

        public override string ToHtmlString()
        {
            return Renderer.Render(_renderingQueue);
        }

        public override IMarquite Marquite { get { return _marquite; } }

        public override void RenderContent(TextWriter tw)
        {
            _renderingQueue.RenderQueue(tw);
        }
       
    }
}
