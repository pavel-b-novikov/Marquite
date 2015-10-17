using System;
using Marquite.Bootstrap.Extensions;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Elements
{
    public class BootstrapButtonBuilder : ButtonBuilderBase<BootstrapButtonBuilder>
    {
        private readonly BootstrapPlugin _bootstrap;
        public BootstrapButtonBuilder(Core.IMarquite marquite, string tagName)
            : base(marquite, tagName)
        {
            AddClass("btn");
            AddClass(Lookups.Lookup(ButtonColor.Default));
            /*
             * If the <a> elements are used to act as buttons – triggering in-page functionality, 
             * rather than navigating to another document or section within the current page – 
             * they should also be given an appropriate role="button".
             */
            if (tagName == "a")
            {
                Attr("role", "button");
            }
            _bootstrap = marquite.ResolvePlugin<BootstrapPlugin>();
        }

        /// <summary>
        /// Create block level buttons—those that span the full width of a parent
        /// </summary>
        /// <returns>Chain</returns>
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
            CategorizedCssClasses.CleanupAndAdd("color", Lookups.Lookup(color));
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

        /// <summary>
        /// Fancy larger or smaller buttons? Use ButtonSize enum
        /// </summary>
        /// <param name="size">Button size</param>
        /// <returns>Chain</returns>
        public BootstrapButtonBuilder Size(ButtonSize size)
        {
            CategorizedCssClasses.CleanupAndAdd("btnsize", Lookups.Lookup(size));
            return This;
        }

        /// <summary>
        /// Extra-small button
        /// </summary>
        /// <returns></returns>
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
                RenderingQueue.Trail(_bootstrap.CompiledGlyphIcon(icon));
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
                RenderingQueue.Lead(_bootstrap.CompiledGlyphIcon(icon));
            }
            return This;
        }

    }
}
