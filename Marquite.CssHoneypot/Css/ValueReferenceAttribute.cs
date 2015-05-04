using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.CssHoneypot.Css
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct|AttributeTargets.Enum,AllowMultiple = true)]
    public class ValueReferenceAttribute : Attribute
    {
        public string W3CName { get; private set; }

        public ValueReferenceAttribute(string w3CName)
        {
            W3CName = w3CName;
        }
    }
}
