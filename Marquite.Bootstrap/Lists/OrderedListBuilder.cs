using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Bootstrap.Lists
{
    public class OrderedListBuilder : ListBuilder<OrderedListBuilder>
    {
        public OrderedListBuilder(Core.Marquite m) : base(m,"ol")
        {
        }
    }
}
