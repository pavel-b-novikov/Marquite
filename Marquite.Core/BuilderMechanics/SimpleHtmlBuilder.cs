using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core.BuilderMechanics
{
    public class SimpleHtmlBuilder : ElementHtmlBuilder
    {
        public SimpleHtmlBuilder(IMarquite marquite, string tagName) : base(marquite, tagName)
        {
        }
    }
}
