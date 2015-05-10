using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class SelectBuilder : BaseInputField<SelectBuilder>
    {
        public SelectBuilder(Marquite marquite) : base(marquite, "select")
        {
        }

        public SelectBuilder AddItem(OptionBuilder option)
        {
            Trail(option);
            return this;
        }

        public SelectBuilder AddItem(string option, string value, bool selected)
        {
            OptionBuilder ob = new OptionBuilder(Marquite);
            ob.Text(option).Value(value).When(selected, c => c.Selected());
            Trail(ob);
            return this;
        }

        public SelectBuilder AddItem(string option, string value)
        {
            OptionBuilder ob = new OptionBuilder(Marquite);
            ob.Text(option).Value(value);
            Trail(ob);
            return this;
        }

        public SelectBuilder Size(int size)
        {
            return Attr("size", size.ToString());
        }

        public SelectBuilder Multiple()
        {
            return SelfCloseAttr("multiple");
        }
    }
}
