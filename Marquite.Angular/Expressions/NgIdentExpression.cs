using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    class NgLiteralExpression : NgExpression
    {
        public string Literal { get; set; }
        public bool IsModelReference { get; set; }
        public override string Build()
        {
            return Literal;
        }
    }
}
