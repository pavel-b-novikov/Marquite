using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    public class FieldsetBuilder : ElementHtmlBuilder, IFieldset
    {
        public FieldsetBuilder(IMarquite marquite)
            : base(marquite, "fieldset")
        {
        }
    }
}
