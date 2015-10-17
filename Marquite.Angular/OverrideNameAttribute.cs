using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    [AttributeUsage(AttributeTargets.Property)]
    class OverrideNameAttribute : Attribute
    {
        public OverrideNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
