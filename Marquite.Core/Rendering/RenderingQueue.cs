using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core.Rendering
{
    /// <summary>
    /// More fast way to collect and render various items
    /// One-directional collection with rendering wrappers
    /// </summary>
    public class RenderingQueue
    {
        public int Count { get { return _renderingQueue.Count; } }

        private readonly LinkedList<RenderingItem> _renderingQueue = new LinkedList<RenderingItem>();

        public void Trail(string content, string wrapTag = null, bool encode = false, string wrappingTagAttrs = null)
        {
            _renderingQueue.AddLast(new RenderingItem(wrapTag, null, content, encode, wrappingTagAttrs));
        }

        public void Trail(IRenderingClient client, string wrapTag = null, string wrappingTagAttrs = null)
        {
            _renderingQueue.AddLast(new RenderingItem(wrapTag, client, null, wrappingTagAttrs: wrappingTagAttrs));
        }

        public void Lead(IRenderingClient client, string wrapTag = null, string wrappingTagAttrs = null)
        {
            _renderingQueue.AddFirst(new RenderingItem(wrapTag, client, null, wrappingTagAttrs: wrappingTagAttrs));
        }

        public void Lead(string content, string wrapTag = null, bool encode = false, string wrappingTagAttrs = null)
        {
            _renderingQueue.AddFirst(new RenderingItem(wrapTag, null, content, encode, wrappingTagAttrs: wrappingTagAttrs));
        }

        public virtual void ClearQueue()
        {
            _renderingQueue.Clear();
        }

        public virtual void RenderQueue(TextWriter tw)
        {
            foreach (var renderingItem in _renderingQueue)
            {
                tw.RenderItem(renderingItem);
            }
            _renderingQueue.Clear();
        }

        public virtual void LeadingHtml(string html)
        {
            Lead(html);
        }

        public virtual void LeadingText(string text)
        {
            Lead(text, encode: true);
        }

        public virtual void LeadingHtml(IRenderingClient content)
        {
            Lead(content);
        }

        public virtual void TrailingHtml(string html)
        {
            Trail(html);
        }

        public virtual void TrailingText(string text)
        {
            Trail(text, encode: true);
        }

        public virtual void TrailingHtml(IRenderingClient content)
        {
            Trail(content);
        }
    }
}
