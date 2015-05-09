using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Extensions;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Elements
{
    public class DropdownBuilder : ElementHtmlBuilder<DropdownBuilder>
    {
        public DropdownBuilder(Core.Marquite marquite, string labell = null)
            : base(marquite, "ul")
        {
            AddClass("dropdown-menu");
            this.Role("menu");
            if (!string.IsNullOrEmpty(labell))
            {
                Aria("labelledby", labell);
            }
        }

        private SimpleHtmlBuilder Li()
        {
            return (new SimpleHtmlBuilder(Marquite, "li")).Role("presentation");
        }

        public DropdownBuilder Divider()
        {
            Trail(Li().AddClass("divider"));
            return this;
        }

        public DropdownBuilder LinkItem(string text, string href, string id = null, bool enabled = true)
        {
            LinkBuilder lb = new LinkBuilder(Marquite);
            lb.TrailingText(text).Href(href).Tabindex(-1);
            
            var li = Li()
                .TrailingHtml(lb)
                .When(!enabled, c => c.AddClass("disabled"))
                .When(!string.IsNullOrEmpty(id), c => c.Id(id));
            
            Trail(li);
            return this;
        }

        public DropdownBuilder Header(string header)
        {
            Trail(Li().AddClass("dropdown-header").TrailingText(header));
            return this;
        }
    }
}
