using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular.Expressions
{
    class NgInExpression<TElement, TParent> : NgExpression, IAngularInExpression<TElement, TParent>
    {
        private readonly List<string> _exprFilters = new List<string>();

        public override List<string> Filters { get { return _collectionExpression == null ? _exprFilters : _collectionExpression.Filters; } }

        private readonly NgExpression _collectionExpression;
        private readonly string _varName;
        private readonly string _expression;

        public NgInExpression(NgExpression collectionExpression, NgCollectionContext<TElement, TParent> context, string varName)
        {
            _collectionExpression = collectionExpression;
            Context = context;
            _varName = varName;
        }

        public NgInExpression(string expression, NgCollectionContext<TElement, TParent> context, string varName)
        {
            _expression = expression;
            Context = context;
            _varName = varName;
        }

        public override string Build()
        {
            var result = BuildCore();
            if (!string.IsNullOrEmpty(Tracking)) result = String.Concat(result, " track by ", Tracking);
            return result;
        }

        protected override string BuildCore()
        {
            var result = _collectionExpression == null ? _expression : _collectionExpression.Build();
            if (_collectionExpression == null)
            {
                if (string.IsNullOrEmpty(result)) return result;
                if (_exprFilters.Count == 0) return result;
                var filters = string.Join(" | ", _exprFilters);
                result = String.Concat(result, " | ", filters);
            }
            return String.Format("{0} in {1}", _varName, result);
        }

        public string Tracking { get; set; }
        public NgCollectionContext<TElement, TParent> Context { get; private set; }
    }
}
