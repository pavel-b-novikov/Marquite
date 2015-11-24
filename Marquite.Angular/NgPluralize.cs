using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Angular
{
    public class NgPluralize : BasicHtmlBuilder
    {
        public NgPluralize(IMarquite marquite)
            : base(marquite, "ng-pluralize")
        {
        }

        internal readonly Dictionary<string,string> _whenExpressions = new Dictionary<string, string>();

        

        public override void PrepareForRender()
        {
            var pluralizations =
               string.Join(", ",_whenExpressions.Select(c => string.Format("{0}: {1}", c.Key.QuoteSafe(), c.Value.QuoteSafe())).ToArray());
            pluralizations = String.Format("{{ {0} }}",pluralizations);
            this.Attr("when", pluralizations);
            base.PrepareForRender();
        }
    }

    public static class PluralizeExtensions
    {
        public static NgPluralize When<T>(this T b,int number, string expression) where T: NgPluralize
        {
            b._whenExpressions[number.ToString()] = expression;
            return b;
        }

        public static NgPluralize When<T>(this T b, string category, string expression) where T : NgPluralize
        {
            b._whenExpressions[category] = expression;
            return b;
        }

        public static NgPluralize When<T>(this T b, string category, string expressionFormat, params IAngularExpression[] arguments) where T : NgPluralize
        {
            var s = arguments.Select(c => c.ToHtmlString()).Cast<object>().ToArray();
            var fmt = string.Format(expressionFormat, s);
            b._whenExpressions[category] = fmt;
            return b;
        }
    }
}
