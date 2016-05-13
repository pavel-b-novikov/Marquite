using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class SelectBuilderExtensions
    {
        public static T AddItem<T>(this T b,OptionBuilder option) where T : SelectBuilder 
        {
            b.Content.Trail(option);
            return b;
        }

        public static T AddItem<T>(this T b,string option, string value, bool selected) where T : SelectBuilder 
        {
            OptionBuilder ob = new OptionBuilder(b.Marquite);
            ob.Detached().Text(option).Value(value).When(selected, c => c.Selected());
            b.Content.Trail(ob);
            return b;
        }

        public static T AddItem<T>(this T b,string option, string value) where T : SelectBuilder 
        {
            OptionBuilder ob = new OptionBuilder(b.Marquite);
            ob = ob.Detached();
            ob.Text(option).Value(value);
            b.Content.Trail(ob);
            return b;
        }

        public static T Size<T>(this T b,int size) where T : SelectBuilder 
        {
            return b.Attr("size", size.ToString());
        }

        public static T Multiple<T>(this T b) where T : SelectBuilder 
        {
            return b.SelfCloseAttr("multiple");
        }
    }
}