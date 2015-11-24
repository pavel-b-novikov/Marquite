using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class OptgroupExtensions
    {
        public static T AddItem<T>(this T b,OptionBuilder option) where T : OptgroupBuilder 
        {
            b.RenderingQueue.Trail(option.Detached());
            return b;
        }

        public static T AddItem<T>(this T b,string option, string value, bool selected) where T : OptgroupBuilder 
        {
            OptionBuilder ob = new OptionBuilder(b.Marquite);
            ob.Text(option).Value(value).When(selected, c => c.Selected());
            b.RenderingQueue.Trail(ob);
            return b;
        }

        public static T AddItem<T>(this T b,string option, string value) where T : OptgroupBuilder 
        {
            OptionBuilder ob = new OptionBuilder(b.Marquite);
            ob.Text(option).Value(value);
            b.RenderingQueue.Trail(ob);
            return b;
        }
    }
}