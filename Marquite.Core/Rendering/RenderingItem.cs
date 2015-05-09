using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core.Rendering
{
    internal struct RenderingItem
    {
        public string WrappingTag;

        public IRenderingClient RenderingClient;

        public string StringContent;

        public bool Encode;

        public RenderingItem(string wrappingTag, IRenderingClient renderingClient, string stringContent,bool encode = false)
        {
            WrappingTag = wrappingTag;
            RenderingClient = renderingClient;
            StringContent = stringContent;
            Encode = encode;
        }
    }
}
