using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    class NgCallExpression : NgExpression
    {
        public NgExpression ExpressionToCall { get; set; }

        public List<NgExpression> Arguments { get; set; }

        public NgCallExpression()
        {
            Arguments = new List<NgExpression>();
        }

        protected override string BuildCore()
        {
            return String.Format("{0}({1})", ExpressionToCall.Build(),
                string.Join(",", Arguments.Select(c => c.Build())));
        }
    }
}
