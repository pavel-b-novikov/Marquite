using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Bootstrap.Lists
{
    public class UnorderedListBuilder : ListBuilder<UnorderedListBuilder>
    {
        public UnorderedListBuilder(Core.Marquite m) : base(m,"ul")
        {
        }
    }
}
