namespace Marquite.Core.BuilderMechanics
{
    public abstract class ElementHtmlBuilder : BasicHtmlBuilder
    {
        protected ElementHtmlBuilder(IMarquite marquite, string tagName) : base(marquite, tagName)
        {
        }
    }

    public static class ElementHtmlBuilderExtensions
    {
        public static T Tabindex<T>(this T b,int idx) where T : ElementHtmlBuilder
        {
            return b.Attr("tabindex", idx.ToString());
        }

        public static T Accesskey<T>(this T b, char c) where T : ElementHtmlBuilder
        {
            return b.Attr("accesskey", c.ToString());
        }

        public static T Lang<T>(this T b, string lang) where T : ElementHtmlBuilder
        {
            return b.Attr("hreflang", lang);
        }

        public static T Title<T>(this T b, string title) where T : ElementHtmlBuilder
        {
            return b.Attr("title", title);
        }

        public static T ContextMenu<T>(this T b, string menuId) where T : ElementHtmlBuilder
        {
            return b.Attr("contextmenu", menuId);
        }

        public static T ContentEditable<T>(this T b, bool editable = true) where T : ElementHtmlBuilder
        {
            return b.Attr("contenteditable", editable ? "true" : "false");
        }
    }
}
