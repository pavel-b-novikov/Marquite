using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public abstract class ListBuilder<T> : ElementHtmlBuilder<T> where T : ListBuilder<T>
    {
        protected ListBuilder(Marquite m, string tagName)
            : base(m, tagName)
        {
        }

        public T AddItem(string itemContent)
        {
            Trail(itemContent, "li");
            return This;
        }

        public T AddItems(params string[] itemContent)
        {
            itemContent.ForEach(c => Trail(c, "li"));
            return This;
        }

        public T AddItem(IRenderingClient item)
        {
            Trail(item, "li");
            return This;
        }

        public T AddItem(ListItemBuilder listItem)
        {
            Trail(listItem);
            return This;
        }

        public T AddItems(params IRenderingClient[] items)
        {
            items.ForEach(c => Trail(c, "li"));
            return This;
        }
    }
}