using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    internal abstract class NgExpression : IAngularExpression
    {
        public abstract string Build();
        private readonly List<string> _filters = new List<string>();
        public List<string> Filters { get { return _filters; } }

        public string ToHtmlString()
        {
            return String.Format("{{{{{0}}}}}", Build());
        }
    }
}
