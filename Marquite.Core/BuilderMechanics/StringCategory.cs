using System.Collections.Generic;

namespace Marquite.Core.BuilderMechanics
{
    public class StringCategory
    {
        private readonly HashSet<string> _aggregatedStrings;

        private readonly Dictionary<string,HashSet<string>> _categoryKeys = new Dictionary<string, HashSet<string>>();
        
        public StringCategory(HashSet<string> aggregatedStrings)
        {
            _aggregatedStrings = aggregatedStrings;
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
