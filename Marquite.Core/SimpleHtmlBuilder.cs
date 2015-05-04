using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core
{
    public class SimpleHtmlBuilder : BasicHtmlBuilder<SimpleHtmlBuilder>
    {
        public SimpleHtmlBuilder(Marquite marquite, string tagName) : base(marquite, tagName)
        {
        }
    }
}
