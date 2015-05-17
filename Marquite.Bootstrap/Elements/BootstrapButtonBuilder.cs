using System;
using Marquite.Bootstrap.Extensions;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Elements
{
    public class BootstrapButtonBuilder : ButtonBuilderBase<BootstrapButtonBuilder>
    {
        private readonly BootstrapPlugin _bootstrap;
        public BootstrapButtonBuilder(Core.Marquite marquite, string tagName)
            : base(marquite, tagName)
        {
            AddClass("btn");
            AddClass(Lookups.Lookup(ButtonColor.Default));
            _bootstrap = marquite.ResolvePlugin<BootstrapPlugin>();
        }

        public BootstrapButtonBuilder Block()
        {
            AddClass("btn-block");
            return This;
        }

        public BootstrapButtonBuilder Active()
        {
            AddClass("active");
            return This;
        }

        public BootstrapButtonBuilder Diabled()
        {
            AddClass("disabled");
            return This;
        }
        
        #region Color
        public BootstrapButtonBuilder Color(ButtonColor color)
        {
            TagsCategory.CleanupAndAdd("color", Lookups.Lookup(color));
            return This;
        }

        public BootstrapButtonBuilder Danger()
        {
            return Color(ButtonColor.Danger);
        }

        public BootstrapButtonBuilder Info()
        {
            return Color(ButtonColor.Info);
        }

        public BootstrapButtonBuilder Primary()
        {
            return Color(ButtonColor.Primary);
        }

        public BootstrapButtonBuilder Success()
        {
            return Color(ButtonColor.Success);
        }

        public BootstrapButtonBuilder Warning()
        {
            return Color(ButtonColor.Warning);
        }

        #endregion

        #region Size
        public BootstrapButtonBuilder Size(ButtonSize size)
        {
            TagsCategory.CleanupAndAdd("btnsize", Lookups.Lookup(size));
            return This;
        }

        public BootstrapButtonBuilder XtraSmall()
        {
            return Size(ButtonSize.XtraSmall);
        }
        public BootstrapButtonBuilder Small()
        {
            return Size(ButtonSize.Small);
        }
        public BootstrapButtonBuilder Large()
        {
            return Size(ButtonSize.Large);
        }
        #endregion

        public BootstrapButtonBuilder TrailIcon(GlyphIcon icon)
        {
            if (TagName == "input")
            {
                throw new Exception("Cannot place icons to input-kind buttons");
            }
            else
            {
                Trail(_bootstrap.CompiledGlyphIcon(icon));
            }
            return This;
        }

        public BootstrapButtonBuilder LeadIcon(GlyphIcon icon)
        {
            if (TagName == "input")
            {
                throw new Exception("Cannot place icons to input-kind buttons");
            }
            else
            {
                Lead(_bootstrap.CompiledGlyphIcon(icon));
            }
            return This;
        }

    }
}
