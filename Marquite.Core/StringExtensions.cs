using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core
{
    public static class StringExtensions
    {
        public static string AggreageString(this IEnumerable<string> strings, string separator = null)
        {
            if (!strings.Any()) return String.Empty;
            return strings.Aggregate((a, v) => String.Concat(v, separator, a));
        }

        public static string Intern(this string str)
        {
            if (str == null) return null;
            return string.Intern(str);
        }

        public static string format(this string str, params object[] args)
        {
            if (str == null) return null;
            if (string.IsNullOrEmpty(str)) return string.Empty;
            return string.Format(str, args);
        }

        public static void ForEach<T>(this T[] array, Action<T> a)
        {
            if (array == null) return;
            if (array.Length == 0) return;
            for (int i = 0; i < array.Length; i++)
            {
                a(array[i]);
            }
        }

        public static void RevForEach<T>(this T[] array, Action<T> a)
        {
            if (array == null) return;
            if (array.Length == 0) return;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                a(array[i]);
            }
        }
    }
}
