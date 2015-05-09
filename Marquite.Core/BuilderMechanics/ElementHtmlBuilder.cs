namespace Marquite.Core.BuilderMechanics
{
    public abstract class ElementHtmlBuilder<T> : BasicHtmlBuilder<T>
    {
        protected ElementHtmlBuilder(Marquite marquite, string tagName) : base(marquite, tagName)
        {
        }
        public virtual T Tabindex(int idx)
        {
            return Attr("tabindex", idx.ToString());
        }

        public virtual T Accesskey(char c)
        {
            return Attr("accesskey", c.ToString());
        }

        public virtual T Lang(string lang)
        {
            return Attr("hreflang", lang);
        }

        public virtual T Title(string title)
        {
            return Attr("title", title);
        }

        public virtual T Id(string id)
        {
            Attr("id", id);
            return This;
        }

        public virtual T ContextMenu(string menuId)
        {
            return Attr("contextmenu", menuId);
        }

        public virtual T ContentEditable(bool editable = true)
        {
            return Attr("contenteditable", editable?"true":"false");
        }
    }
}
