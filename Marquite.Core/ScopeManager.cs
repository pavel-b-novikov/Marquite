using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core
{
    public class ScopeManager
    {
        private readonly IMarquite _marquite;
        public bool HasActiveScope { get { return CurrentScope != null; } }

        public MarquiteScope CurrentScope { get; private set; }

        private readonly Stack<MarquiteScope> _scopeStack = new Stack<MarquiteScope>();

        public ScopeManager(IMarquite marquite)
        {
            _marquite = marquite;
        }

        public void PushScope()
        {
            MarquiteScope ms = new MarquiteScope(_marquite);
            _scopeStack.Push(ms);
            CurrentScope = ms;
        }

        public MarquiteScope PopScope()
        {
            var scope = _scopeStack.Pop();
            CurrentScope = _scopeStack.Count == 0 ? null : _scopeStack.Peek();
            if (HasActiveScope)
            {
                CurrentScope.Append(scope);
            }
            return scope;
        }
    }
}
