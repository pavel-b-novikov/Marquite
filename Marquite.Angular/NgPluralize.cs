using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Angular
{
    public class NgPluralize : BasicHtmlBuilder<NgPluralize>
    {
        public NgPluralize(IMarquite marquite)
            : base(marquite, "ng-pluralize")
        {
        }

        private readonly Dictionary<string,string> _whenExpressions = new Dictionary<string, string>();

        public NgPluralize When(int number, string expression)
        {
            _whenExpressions[number.ToString()] = expression;
            return this;
        }

        public NgPluralize When(string category, string expression)
        {
            _whenExpressions[category] = expression;
            return this;
        }

        public NgPluralize When(string category, string expressionFormat,params IAngularExpression[] arguments)
        {
            var s = arguments.Select(c => c.ToHtmlString()).Cast<object>().ToArray();
            var fmt = string.Format(expressionFormat, s);
            _whenExpressions[category] = fmt;
            return this;
        }

        public override void PrepareForRender()
        {
            var pluralizations =
               string.Join(", ",_whenExpressions.Select(c => string.Format("{0}: {1}", c.Key.QuoteSafe(), c.Value.QuoteSafe())).ToArray());
            pluralizations = String.Format("{{ {0} }}",pluralizations);
            Attr("when", pluralizations);
            base.PrepareForRender();
        }
    }
}
