using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    class NgMemberExpression : NgExpression
    {
        public NgExpression Accessed { get; set; }

        public string MemberName { get; set; }
        protected override string BuildCore()
        {
            var field = Accessed.Build();
            if (!string.IsNullOrEmpty(field)) field = field + ".";
            return String.Format("{0}{1}", field, MemberName);
        }
    }
}
