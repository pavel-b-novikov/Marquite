using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap
{
    public class BootstrapBasicBuilder<T> : BasicHtmlBuilder<T>
    {
        public virtual T Pull(BootstrapPull pull)
        {
            TagsCategory.CleanupAndAdd("pulls", Lookups.Lookup(pull));
            return This;
        }

        public virtual T Background(Background color)
        {
            TagsCategory.CleanupAndAdd("bg-color", Lookups.Lookup(color));
            return This;
        }

        public virtual T TextColor(TextColor color)
        {
            TagsCategory.CleanupAndAdd("text-color", Lookups.Lookup(color));
            return This;
        }

        public virtual T ShowHide(Hiding hiding)
        {
            TagsCategory.CleanupAndAdd("hiding", Lookups.Lookup(hiding));
            return This;
        }

        public virtual T VisibleOn(Device device, Display displayType)
        {
            var dev = "visible-" + Lookups.Lookup(device);
            TagsCategory.CleanupAndAdd(dev, dev + "-" + Lookups.Lookup(displayType));

            return This;
        }

        public virtual T VisibleOn(Device device)
        {
            return VisibleOn(device, Display.Block);
        }

        public virtual T VisibleOn(params Device[] devices)
        {
            foreach (var device in devices)
            {
                return VisibleOn(device, Display.Block);
            }
            return This;
        }

        public virtual T HiddenOn(Device device)
        {
            var dev = "visible-" + Lookups.Lookup(device);
            TagsCategory.CleanupAndAdd(dev, ("hidden-" + Lookups.Lookup(device)).Intern());
            return This;
        }

        public virtual T HiddenOn(params Device[] devices)
        {
            foreach (var device in devices)
            {
                HiddenOn(device);
            }
            return This;
        }

        public virtual T TextCase(TextCasing casing)
        {
            TagsCategory.CleanupAndAdd("txt-casing", Lookups.Lookup(casing));
            return This;
        }

        public BootstrapBasicBuilder(Core.Marquite marquite, string tagName)
            : base(marquite, tagName)
        {
        }

        public virtual T AddCaret()
        {
            Trail(Marquite.Caret().Compile());
            return This;
        }

        public virtual T TrailIcon(GlyphIcon icon)
        {
            Trail(Marquite.CompiledGlyphIcon(icon));
            return This;
        }

        public virtual T LeadIcon(GlyphIcon icon)
        {
            Trail(Marquite.CompiledGlyphIcon(icon));
            return This;
        }

        public virtual T Color(Color c)
        {
            TagsCategory.CleanupAndAdd("el-color",Lookups.Lookup(c));
            return This;
        }

        public virtual T Success()
        {
            TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Success));
            return This;
        }

        public virtual T Danger()
        {
            TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Danger));
            return This;
        }

        public virtual T Info()
        {
            TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Info));
            return This;
        }

        public virtual T Warning()
        {
            TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Warning));
            return This;
        }

        public virtual T Primary()
        {
            TagsCategory.CleanupAndAdd("el-color", Lookups.Lookup(Bootstrap.Color.Primary));
            return This;
        }

    }
}
