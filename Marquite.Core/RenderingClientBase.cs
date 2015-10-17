using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public abstract class RenderingClientBase : IRenderingClient
    {
        public abstract string ToHtmlString();
        public abstract IMarquite Marquite { get; }
        public virtual void PrepareForRender()
        {
            
        }

        public virtual void RenderBeforeOpenTag(TextWriter tw)
        {

        }

        public virtual void RenderOpeningTag(TextWriter tw)
        {

        }

        public virtual void RenderAfterOpeningTag(TextWriter tw)
        {

        }

        public virtual void RenderContent(TextWriter tw)
        {

        }

        public virtual void RenderBeforeClosingTag(TextWriter tw)
        {

        }

        public virtual void RenderClosingTag(TextWriter tw)
        {

        }

        public virtual void RenderAfterClosingTag(TextWriter tw)
        {

        }
    }
}
