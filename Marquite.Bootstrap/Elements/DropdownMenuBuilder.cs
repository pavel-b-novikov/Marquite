using System;
using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Elements
{
    public class DropdownMenuBuilder : ElementHtmlBuilder<DropdownMenuBuilder>
    {
        public DropdownMenuBuilder(Core.IMarquite marquite, string labell = null)
            : base(marquite, "ul")
        {
            AddClass("dropdown-menu");
            this.Role("menu");
            if (!string.IsNullOrEmpty(labell))
            {
                Aria("labelledby", labell);
            }
        }

        public DropdownMenuBuilder Divider()
        {
            return Item("", additionalClasses: "divider");
        }

        private string GetWrappingTagAttrs(string id = null, bool active = false, bool enabled = true, string additionalClasses = null)
        {
            string classes = HtmlText.Classes(additionalClasses, !enabled ? "disabled" : null, active ? "active" : null);
            return String.Join(" ",
                HtmlText.NameValue("role", "presentation"),
                (!string.IsNullOrEmpty(id) ? HtmlText.Id(id) : String.Empty),
                classes
                );
        }
        public DropdownMenuBuilder Item(string text, string id = null, bool active = false, bool enabled = true, string additionalClasses = null)
        {
            RenderingQueue.Trail(text, "li",
                wrappingTagAttrs: GetWrappingTagAttrs(id, active, enabled, additionalClasses)
                );

            return this;
        }

        public DropdownMenuBuilder Item(IRenderingClient item, string id = null, bool active = false, bool enabled = true, string additionalClasses = null)
        {
            RenderingQueue.Trail(item, "li",
                    wrappingTagAttrs: GetWrappingTagAttrs(id,active, enabled, additionalClasses)
                );

            return this;
        }

        public DropdownMenuBuilder LinkItem(string text, string href, string id = null, bool active = false, bool enabled = true, string additionalClasses = null)
        {
            LinkBuilder lb = new LinkBuilder(Marquite);
            lb.TrailingText(text).Href(href).Tabindex(-1);

            return Item(lb, id, active, enabled, additionalClasses);
        }

        public DropdownMenuBuilder RawItem(IRenderingClient item)
        {
            RenderingQueue.Trail(item);

            return this;
        }

        public DropdownMenuBuilder Header(string header)
        {
            return Item(header, additionalClasses: "dropdown-header");
        }
    }
}
