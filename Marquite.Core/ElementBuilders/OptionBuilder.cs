using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class OptionBuilder : ElementHtmlBuilder<OptionBuilder>
    {
        public OptionBuilder(IMarquite marquite) : base(marquite, "option")
        {
        }

        public OptionBuilder Value(string value)
        {
            return Attr("value", value);
        }

        public OptionBuilder Value(object value)
        {
            return Attr("value", value.ToString());
        }

        public OptionBuilder Value(object value, string format)
        {
            return Attr("value", String.Format(format, value));
        }

        public OptionBuilder Label(string label)
        {
            return Attr("label", label);
        }
        public OptionBuilder Selected()
        {
            return SelfCloseAttr("selected");
        }

        public OptionBuilder Text(string text)
        {
            return TrailingText(text);
        }

        public OptionBuilder Disabled()
        {
            return SelfCloseAttr("disabled");
        }
    }
}
