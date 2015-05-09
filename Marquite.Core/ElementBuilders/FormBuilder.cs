using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class FormBuilder : ElementHtmlBuilder<FormBuilder>
    {
        public FormBuilder(Marquite marquite) : base(marquite, "form")
        {
        }
    }
}
