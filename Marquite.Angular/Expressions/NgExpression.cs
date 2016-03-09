using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    public abstract class NgExpression : IAngularExpression
    {
        protected abstract string BuildCore();
        private readonly List<string> _filters = new List<string>();
        public virtual string Build()
        {
            string result = BuildCore();
            if (string.IsNullOrEmpty(result)) return result;
            if (Filters.Count == 0) return result;
            var filters = string.Join(" | ", Filters);
            result = String.Concat(result, " | ", filters);
            return result;
        }

        public virtual List<string> Filters { get { return _filters; } }

        public string ToHtmlString()
        {
            return String.Format("{{{{{0}}}}}", Build());
        }

        public override string ToString()
        {
            return String.Format("{{{{{0}}}}}", Build());
        }
    }
}
