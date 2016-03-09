using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    class NgUnboundExpression : NgExpression
    {
        public NgExpression Boundee { get; set; }

        public bool IsEmpty { get; set; }

        protected override string BuildCore()
        {
            return Boundee == null ? (IsEmpty ? string.Empty : "<unbound>") : Boundee.Build();
        }
    }
}
