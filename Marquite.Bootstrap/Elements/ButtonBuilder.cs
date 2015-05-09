using System;
using Marquite.Bootstrap.Extensions;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Elements
{
    public class ButtonBuilder : ElementHtmlBuilder<ButtonBuilder>
    {
        public ButtonBuilder(Core.Marquite marquite, string tagName) : base(marquite, tagName)
        {
            AddClass("btn");
            AddClass(Lookups.Lookup(ButtonColor.Default));
        }
        
        public ButtonBuilder Block()
        {
            AddClass("btn-block");
            return This;
        }

        public ButtonBuilder Active()
        {
            AddClass("active");
            return This;
        }

        public ButtonBuilder Diabled()
        {
            AddClass("disabled");
            return This;
        }

        public ButtonBuilder Submit()
        {
            Attr("type","submit");
            return This;
        }
        #region Color
        public ButtonBuilder Color(ButtonColor color)
        {
            TagsCategory.CleanupAndAdd("color", Lookups.Lookup(color));
            return This;
        }

        public ButtonBuilder Danger()
        {
            return Color(ButtonColor.Danger);
        }

        public ButtonBuilder Info()
        {
            return Color(ButtonColor.Info);
        }

        public ButtonBuilder Primary()
        {
            return Color(ButtonColor.Primary);
        }

        public ButtonBuilder Success()
        {
            return Color(ButtonColor.Success);
        }

        public ButtonBuilder Warning()
        {
            return Color(ButtonColor.Warning);
        }

        #endregion

        #region Size
        public ButtonBuilder Size(ButtonSize size)
        {
            TagsCategory.CleanupAndAdd("btnsize", Lookups.Lookup(size));
            return This;
        }

        public ButtonBuilder XtraSmall()
        {
            return Size(ButtonSize.XtraSmall);
        }
        public ButtonBuilder Small()
        {
            return Size(ButtonSize.Small);
        }
        public ButtonBuilder Large()
        {
            return Size(ButtonSize.Large);
        }
        #endregion

        public ButtonBuilder Content(string text)
        {
            if (TagName == "input")
            {
                if (string.IsNullOrEmpty(text)) RemoveAttr("value");
                else Attr("value", text);
            }
            else
            {
                ClearQueue();
                Trail(text);
            }
            return This;
        }

        public ButtonBuilder AppendText(string text)
        {
            if (string.IsNullOrEmpty(text)) return This;

            if (TagName == "input")
            {
                Attr("value", GetAttr("value")+text);
            }
            else
            {
                Trail(text);
            }
            return This;
        }

        public ButtonBuilder TrailIcon(GlyphIcon icon)
        {
            if (TagName == "input")
            {
                throw new Exception("Cannot place icons to input-kind buttons");
            }
            else
            {
                Trail(Marquite.CompiledGlyphIcon(icon));
            }
            return This;
        }

        public ButtonBuilder LeadIcon(GlyphIcon icon)
        {
            if (TagName == "input")
            {
                throw new Exception("Cannot place icons to input-kind buttons");
            }
            else
            {
                Lead(Marquite.CompiledGlyphIcon(icon));
            }
            return This;
        }

    }
}
