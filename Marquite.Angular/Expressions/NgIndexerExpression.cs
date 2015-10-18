using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    class NgIndexerExpression : NgExpression
    {
        public NgExpression ExpressionToIndex { get; set; }

        public NgExpression Index { get; set; }
        protected override string BuildCore()
        {
            return string.Format("{0}[{1}]", ExpressionToIndex.Build(), Index.Build());
        }
    }
}
