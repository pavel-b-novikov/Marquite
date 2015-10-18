using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    public static class NgExpressionExtensions
    {
        public static T AddFilter<T>(this T expression, string filter, params string[] arguments)
            where T : IAngularExpression
        {
            if (arguments != null && arguments.Length > 0)
            {
                var args = string.Join(":", arguments);
                filter = String.Concat(filter, ":", args);
            }
            expression.Filters.Add(filter);
            return expression;
        }

        public static T FilterJson<T>(this T expression, int spacing = 0)
            where T : IAngularExpression
        {
            if (spacing > 0) return AddFilter(expression, "json", spacing.ToString());
            return AddFilter(expression, "json");
        }

        public static T FilterNumber<T>(this T expression, int fractionSize = 0)
            where T : IAngularExpression
        {
            if (fractionSize > 0) return AddFilter(expression, "number", fractionSize.ToString());
            return AddFilter(expression, "number");
        }

        public static T FilterOrderBy<T>(this T e, string expression, bool reverse = false)
            where T : IAngularExpression
        {
            if (reverse) return AddFilter(e, "orderBy", expression.QuoteSafe(), "reverse");
            return AddFilter(e, "orderBy", expression.QuoteSafe());
        }

        public static T FilterOrderBy<T>(this T e, IAngularExpression expression, bool reverse = false)
            where T : IAngularExpression
        {
            if (reverse) return AddFilter(e, "orderBy", expression.Build().QuoteSafe(), "reverse");
            return AddFilter(e, "orderBy", expression.Build().QuoteSafe());
        }

        public static T FilterUpperCase<T>(this T e)
            where T : IAngularExpression
        {
            return AddFilter(e, "uppercase");
        }

        public static T FilterLowerCase<T>(this T e)
            where T : IAngularExpression
        {
            return AddFilter(e, "lowercase");
        }

        public static T FilterDate<T>(this T e, string format = null, string timezone = null)
            where T : IAngularExpression
        {
            List<string> args = new List<string>();
            if (!string.IsNullOrEmpty(format)) args.Add(format.QuoteSafe());
            if (!string.IsNullOrEmpty(timezone)) args.Add(timezone.QuoteSafe());
            return AddFilter(e, "date", args.ToArray());
        }

        public static T FilterCurrency<T>(this T e, string symbol = null, int fractionSize = 0)
            where T : IAngularExpression
        {
            List<string> args = new List<string>();
            if (!string.IsNullOrEmpty(symbol)) args.Add(symbol.QuoteSafe());
            if (fractionSize > 0) args.Add(fractionSize.ToString());
            return AddFilter(e, "currency", args.ToArray());
        }

        public static T FilterFilter<T>(this T e, string expression, string comparator = null)
            where T : IAngularExpression
        {
            if (!string.IsNullOrEmpty(comparator)) return AddFilter(e, "filter", expression, comparator);
            return AddFilter(e, "filter", expression);
        }

        public static T FilterFilter<T>(this T e, IAngularExpression expression, string comparator = null)
            where T : IAngularExpression
        {
            if (!string.IsNullOrEmpty(comparator)) return AddFilter(e, "filter", expression.Build(), comparator);
            return AddFilter(e, "filter", expression.Build());
        }
        public static T TrackBy<T>(this T e, string expression)
            where T : IAngularInExpressionNongeneric
        {
            e.Tracking = expression;
            return e;
        }

        public static T TrackBy<T>(this T e, IAngularExpression expression)
            where T : IAngularInExpressionNongeneric
        {
            e.Tracking = expression.Build();
            return e;
        }
    }
}
