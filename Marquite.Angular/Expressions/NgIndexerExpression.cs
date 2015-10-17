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
        public override string Build()
        {
            return string.Format("{0}[{1}]", ExpressionToIndex.Build(), Index.Build());
        }
    }
}
