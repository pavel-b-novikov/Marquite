using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Extensions
{
    public static class CommonExtensions
    {
        public static ElementHtmlBuilder<T> Pull<T>(this ElementHtmlBuilder<T> elem,BootstrapPull pull)
        {
            elem.TagsCategory.CleanupAndAdd("pulls", Lookups.Lookup(pull));
            return elem;
        }

        public static ElementHtmlBuilder<T> Background<T>(this ElementHtmlBuilder<T> elem,Background color)
        {
            elem.TagsCategory.CleanupAndAdd("bg-color", Lookups.Lookup(color));
            return elem;
        }

        public static ElementHtmlBuilder<T> TextColor<T>(this ElementHtmlBuilder<T> elem,TextColor color)
        {
            elem.TagsCategory.CleanupAndAdd("text-color", Lookups.Lookup(color));
            return elem;
        }

        public static ElementHtmlBuilder<T> ShowHide<T>(this ElementHtmlBuilder<T> elem,Hiding hiding)
        {
            elem.TagsCategory.CleanupAndAdd("hiding", Lookups.Lookup(hiding));
            return elem;
        }

        public static ElementHtmlBuilder<T> VisibleOn<T>(this ElementHtmlBuilder<T> elem,Device device, Display displayType)
        {
            var dev = "visible-" + Lookups.Lookup(device);
            elem.TagsCategory.CleanupAndAdd(dev, dev + "-" + Lookups.Lookup(displayType));

            return elem;
        }

        public static ElementHtmlBuilder<T> VisibleOn<T>(this ElementHtmlBuilder<T> elem,Device device)
        {
            return VisibleOn(elem,device, Display.Block);
        }

        public static ElementHtmlBuilder<T> VisibleOn<T>(this ElementHtmlBuilder<T> elem,params Device[] devices)
        {
            foreach (var device in devices)
            {
                return VisibleOn(elem,device, Display.Block);
            }
            return elem;
        }

        public static ElementHtmlBuilder<T> HiddenOn<T>(this ElementHtmlBuilder<T> elem,Device device)
        {
            var dev = "visible-" + Lookups.Lookup(device);
            elem.TagsCategory.CleanupAndAdd(dev, ("hidden-" + Lookups.Lookup(device)).Intern());
            return elem;
        }

        public static ElementHtmlBuilder<T> HiddenOn<T>(this ElementHtmlBuilder<T> elem,params Device[] devices)
        {
            foreach (var device in devices)
            {
                HiddenOn(elem,device);
            }
            return elem;
        }

        public static ElementHtmlBuilder<T> TextCase<T>(this ElementHtmlBuilder<T> elem,TextCasing casing)
        {
            elem.TagsCategory.CleanupAndAdd("txt-casing", Lookups.Lookup(casing));
            return elem;
        }

        public static ElementHtmlBuilder<T> AddCaret<T>(this ElementHtmlBuilder<T> elem)
        {
            elem.TrailingHtml(elem.Marquite.Caret().Compile());
            return elem;
        }

        public static ElementHtmlBuilder<T> TrailIcon<T>(this ElementHtmlBuilder<T> elem,GlyphIcon icon)
        {
            elem.TrailingHtml(elem.Marquite.CompiledGlyphIcon(icon));
            return elem;
        }

        public static ElementHtmlBuilder<T> LeadIcon<T>(this ElementHtmlBuilder<T> elem,GlyphIcon icon)
        {
            elem.TrailingHtml(elem.Marquite.CompiledGlyphIcon(icon));
            return elem;
        }

        public static ElementHtmlBuilder<T> Color<T>(this ElementHtmlBuilder<T> elem,Color c)
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(c));
            return elem;
        }

        public static ElementHtmlBuilder<T> Success<T>(this ElementHtmlBuilder<T> elem)
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Success));
            return elem;
        }

        public static ElementHtmlBuilder<T> Danger<T>(this ElementHtmlBuilder<T> elem)
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Danger));
            return elem;
        }

        public static ElementHtmlBuilder<T> Info<T>(this ElementHtmlBuilder<T> elem)
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Info));
            return elem;
        }

        public static ElementHtmlBuilder<T> Warning<T>(this ElementHtmlBuilder<T> elem)
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Warning));
            return elem;
        }

        public static ElementHtmlBuilder<T> Primary<T>(this ElementHtmlBuilder<T> elem)
        {
            elem.TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Primary));
            return elem;
        }
    }
}
