using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public static class ScopeExtensions
    {
        public static T Detached<T>(this MarquiteScope scope, T element)
            where T : IRenderingClient
        {
            if (element == null) return default(T);
            if (scope != null) scope.Detach(element);
            return element;
        }

        public static T Detached<T>(this T element)
            where T : IRenderingClient
        {
            if (element == null) return default(T);
            var scope = element.Marquite.ScopeManager.CurrentScope;
            if (scope != null) 
                scope.Detach(element);
            return element;
        }
        
    }
}
