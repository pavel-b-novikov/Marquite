using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Bootstrap.Forms
{
    public class BaseInputBuilder<T> : ElementHtmlBuilder<T>
    {
        public BaseInputBuilder(Core.Marquite marquite) : base(marquite, "input")
        {
        }

        public T Value(string value)
        {
            return Attr("value", value);
        }

        public T Type(InputType type)
        {
            return Attr("type", Lookups.Lookup(type));
        }

        public T Enable(bool enabled = false)
        {
            if (enabled) RemoveClass("disabled");
            else AddClass("disabled");
            return This;
        }
    }
}
