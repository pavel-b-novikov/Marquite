using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Bootstrap.Lists
{
    public class ListItemBuilder<T> : BootstrapBasicBuilder<T>
    {
        public ListItemBuilder(Core.Marquite m) : base(m,"li")
        {
        }
    }
}
