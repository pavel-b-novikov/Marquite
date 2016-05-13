using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core.Rendering
{
    public interface IRenderingQueue
    {
        void Trail(string content, string wrapTag = null, bool encode = false, string wrappingTagAttrs = null);
        void Trail(IRenderingClient client, string wrapTag = null, string wrappingTagAttrs = null);
        void Lead(IRenderingClient client, string wrapTag = null, string wrappingTagAttrs = null);
        void Lead(string content, string wrapTag = null, bool encode = false, string wrappingTagAttrs = null);
        void ClearQueue();
    }
}
