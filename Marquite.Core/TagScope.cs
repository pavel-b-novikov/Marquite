using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core
{
    public class TagScope : ITagScope
    {
        private readonly IMarquite _marquite;

        public MarquiteScope Scope { get; private set; }

        public TagScope(IMarquite marquite)
        {
            _marquite = marquite;
            _marquite.ScopeManager.PushScope();
            Scope = _marquite.ScopeManager.CurrentScope;
        }

        public void Dispose()
        {
            _marquite.ScopeManager.PopScope();
        }
    }
}
