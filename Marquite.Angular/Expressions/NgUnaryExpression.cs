using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    class NgUnaryExpression : NgExpression
    {
        public NgExpression Expression { get; set; }
        public string Symbol { get; set; }
        protected override string BuildCore()
        {
            return String.Format("({0}{1})",Symbol,Expression.Build());
        }
    }
}
