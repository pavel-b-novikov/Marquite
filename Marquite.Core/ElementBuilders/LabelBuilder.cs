using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class LabelBuilder : ElementHtmlBuilder<LabelBuilder>
    {
        public LabelBuilder(Marquite marquite) : base(marquite, "label")
        {
        }

        public LabelBuilder For(string forField)
        {
            return Attr("for", forField);
        }
    }
}
