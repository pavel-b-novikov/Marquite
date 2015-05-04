using Marquite.Core;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Lists
{
    public abstract class ListBuilder<T> : BootstrapBasicBuilder<T>
    {
        protected ListBuilder(Core.Marquite m,string tagName)
            : base(m,tagName)
        {
        }

        public T InlineList(bool inline = true)
        {
            if (inline) RemoveClass(Lookups.Lookup(ListStyles.Inline));
            else AddClass(Lookups.Lookup(ListStyles.Inline));
            return This;
        }

        public T UnstyledList(bool unstyled = true)
        {
            if (unstyled) RemoveClass(Lookups.Lookup(ListStyles.Unstyled));
            else AddClass(Lookups.Lookup(ListStyles.Unstyled));
            return This;
        }

        public T AddItem(string itemContent)
        {
            Trail(itemContent,"li");
            return This;
        }

        public T AddItems(params string[] itemContent)
        {
            itemContent.ForEach(c => Trail(c,"li"));
            return This;
        }

        public T AddItem(IRenderingClient item)
        {
            Trail(item,"li");
            return This;
        }

        public T AddItems(params IRenderingClient[] items)
        {
            items.ForEach(c => Trail(c,"li"));
            return This;
        }
    }
}
