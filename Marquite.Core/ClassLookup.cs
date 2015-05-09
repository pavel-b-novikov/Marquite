using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Marquite.Core
{
    public static class ClassLookup
    {
        private class TypeComparer : IComparer<Type>
        {
            public int Compare(Type x, Type y)
            {
                return x.GUID.CompareTo(y.GUID);
            }
        }

        private static readonly SortedDictionary<Type, List<string>> _cache = new SortedDictionary<Type, List<string>>(new TypeComparer());

        public static SortedDictionary<Type, List<string>> Cache { get { return _cache; } }
        
        public static void Init()
        {
            var assembly = typeof(ClassLookup).Assembly;
            LoadFromAssembly(assembly);
        }

        public static void LoadFromAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(c => c.GetCustomAttribute<LookupEnumAttribute>() != null);
            foreach (var type in types)
            {
                List<string> cacheItems = new List<string>();
                var members = type.GetMembers().OfType<FieldInfo>().Where(c=>c.IsStatic);
                foreach (var memberInfo in members)
                {
                    var attr = memberInfo.GetCustomAttribute<LookupStringAttribute>();
                    if (attr == null) throw new Exception(string.Format("No contextual attribute for enum value {0}", memberInfo));
                    cacheItems.Add(attr.ClassName);
                }
                _cache[type] = cacheItems;
            }
        }

        
    }
}
