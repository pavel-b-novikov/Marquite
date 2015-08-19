using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public abstract class ListBuilder<T> : ElementHtmlBuilder<T> where T : ListBuilder<T>
    {
        protected ListBuilder(IMarquite m, string tagName)
            : base(m, tagName)
        {
        }

        public T AddItem(string itemContent)
        {
            RenderingQueue.Trail(itemContent, "li");
            return This;
        }

        public T AddItems(params string[] itemContent)
        {
            itemContent.ForEach(c => RenderingQueue.Trail(c, "li"));
            return This;
        }

        public T AddItem(IRenderingClient item)
        {
            RenderingQueue.Trail(item, "li");
            return This;
        }

        public T AddItem(ListItemBuilder listItem)
        {
            RenderingQueue.Trail(listItem);
            return This;
        }

        public T AddItems(params IRenderingClient[] items)
        {
            items.ForEach(c => RenderingQueue.Trail(c, "li"));
            return This;
        }
    }
}