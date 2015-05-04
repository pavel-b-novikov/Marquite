using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core
{
    public class StringCategory
    {
        private readonly HashSet<string> _aggregatedStrings;

        private readonly Dictionary<string,HashSet<string>> _categoryKeys = new Dictionary<string, HashSet<string>>();
        private readonly IEmpyStateHandler _emptyStateHandler;

        public StringCategory(HashSet<string> aggregatedStrings, IEmpyStateHandler emptyStateHandler)
        {
            _aggregatedStrings = aggregatedStrings;
            _emptyStateHandler = emptyStateHandler;
        }

        public void CleanupAndAdd(string category, string value)
        {
            if (_categoryKeys.ContainsKey(category))
            {
                var hs = _categoryKeys[category];
                _aggregatedStrings.RemoveWhere(c => hs.Contains(c));
                hs.Add(value);
            }
            else
            {
                Add(category,value);
            }
            
        }

        public void Add(string category, string value)
        {
            var hs = GetOrCreateValueKey(category);
            hs.Add(value);
            _aggregatedStrings.Add(value);
        }

        public void CleanupCategory(string category)
        {
            if (!_categoryKeys.ContainsKey(category)) return;
            var hs = _categoryKeys[category];
            _categoryKeys.Remove(category);
            _aggregatedStrings.RemoveWhere(c => hs.Contains(c));
            _emptyStateHandler.UpdateEmptyState();
        }

        private HashSet<string> GetOrCreateValueKey(string category)
        {
            if (_categoryKeys.ContainsKey(category)) return _categoryKeys[category];
            var c = new HashSet<string>();
            _categoryKeys[category] = c;
            return c;
        }
    }
}
