using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class NavBuilder : ElementHtmlBuilder<NavBuilder>
    {
        public NavBuilder(Core.Marquite marquite) : base(marquite, "ul")
        {
            AddClass("nav");
            AddClass("nav-tabs");
        }

        public NavBuilder Stacked()
        {
            RemoveClass("nav-justified");
            AddClass("nav-stacked");
            return this;
        }

        public NavBuilder Justified()
        {
            RemoveClass("nav-stacked");
            AddClass("nav-justified");
            return this;
        }

        public NavBuilder Pills()
        {
            RemoveClass("nav-tabs");
            AddClass("nav-pills");
            return this;
        }

        private string GetWrappingTagAttrs(string id = null, bool enabled = true, string additionalClasses = null)
        {
            string classes = HtmlText.Classes(additionalClasses, !enabled ? "disabled" : null);
            return String.Join(" ",
                HtmlText.NameValue("role", "presentation"),
                (!string.IsNullOrEmpty(id) ? HtmlText.Id(id) : String.Empty),
                classes
                );
        }
        public NavBuilder Item(string text, string id = null, bool enabled = true, string additionalClasses = null)
        {
            Trail(text, "li",
                wrappingTagAttrs: GetWrappingTagAttrs(id, enabled, additionalClasses)
                );

            return this;
        }

        public NavBuilder Item(IRenderingClient item, string id = null, bool enabled = true, string additionalClasses = null)
        {
            Trail(item, "li",
                    wrappingTagAttrs: GetWrappingTagAttrs(id, enabled, additionalClasses)
                );

            return this;
        }

        public NavBuilder LinkItem(string text, string href, string id = null, bool enabled = true, string additionalClasses = null)
        {
            LinkBuilder lb = new LinkBuilder(Marquite);
            lb.TrailingText(text).Href(href).Tabindex(-1);

            return Item(lb, id, enabled, additionalClasses);
        }
    }
}
