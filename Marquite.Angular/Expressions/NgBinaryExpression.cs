using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    class NgBinaryExpression : NgExpression
    {
        public NgExpression Left { get; set; }

        public NgExpression Right { get; set; }

        public string Symbol { get; set; }
        protected override string BuildCore()
        {
            return String.Format("({1} {0} {2})", Symbol, Left.Build(), Right.Build());
        }
    }
}
