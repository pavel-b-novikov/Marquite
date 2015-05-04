using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Bootstrap
{
    public class BootstrapElementBuilder : BootstrapBasicBuilder<BootstrapElementBuilder>
    {
        public BootstrapElementBuilder(Core.Marquite marquite, string tagName) : base(marquite, tagName)
        {
        }
    }
}
