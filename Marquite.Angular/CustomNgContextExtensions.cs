using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    public static class CustomNgContextExtensions
    {
        private static string ConstructOutOfScopeCall(string modelName, string contollerName, string fn)
        {
            string scpFun = null;
            if (!string.IsNullOrEmpty(modelName))
            {
                const string scope =
                    @"(angular.element(document.querySelector('[ng-controller=\""{0} as {1}\""]')).scope())";
                scpFun = string.Format(scope, contollerName, modelName);
            }
            else
            {
                const string scope =
                    @"(angular.element(document.querySelector('[ng-controller=\""{0}""]')).scope())";
                scpFun = string.Format(scope, contollerName);
            }
            var apply = string.Format("a.$apply(function(){{ a.{0}; }});", fn);
            return string.Format("(function(a){{ {1} }}){0}", scpFun, apply);
        }

        public static string FromOutOfScope<T,TData>(this NgContext<T> context, string contollerName, Expression<Func<NgEventContext<T>, TData>> method)
        {
            var fn = context.Command(method).Build();
            return ConstructOutOfScopeCall(context.ModelName, contollerName, fn);
        }

        public static string FromOutOfScope<T>(this NgContext<T> context, string contollerName, Expression<Action<NgEventContext<T>>> method)
        {
            var fn = context.Command(method).Build();
            return ConstructOutOfScopeCall(context.ModelName, contollerName, fn);
        }
    }
}
