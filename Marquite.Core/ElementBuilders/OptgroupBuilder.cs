using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class OptgroupBuilder : ElementHtmlBuilder<OptgroupBuilder>
    {
        public OptgroupBuilder(Marquite marquite) : base(marquite, "optgroup")
        {
        }

        public OptgroupBuilder Label(string label)
        {
            return Attr("label", label);
        }

        public OptgroupBuilder AddItem(OptionBuilder option)
        {
            Trail(option);
            return this;
        }

        public OptgroupBuilder AddItem(string option,string value,bool selected)
        {
            OptionBuilder ob = new OptionBuilder(Marquite);
            ob.Text(option).Value(value).When(selected,c=>c.Selected());
            Trail(ob);
            return this;
        }

        public OptgroupBuilder AddItem(string option, string value)
        {
            OptionBuilder ob = new OptionBuilder(Marquite);
            ob.Text(option).Value(value);
            Trail(ob);
            return this;
        }

        public OptgroupBuilder Disabled()
        {
            return SelfCloseAttr("disabled");
        }

    }
}
