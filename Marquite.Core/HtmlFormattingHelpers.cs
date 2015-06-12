using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core
{
    /// <summary>
    /// Helper methods for fast HTML attr construction
    /// </summary>
    public static class HtmlFormattingHelpers
    {
        private const string NameValueFormat = "{0}=\"{1}\"";
        private const string ClassValueFormat = "class=\"{0}\"";
        private const string StyleValueFormat = "{0}:{1};";
        private const string StyleAttrValueFormat = "style=\"{0}\"";

        public static string NameValue(string name, string value)
        {
            return String.Format(NameValueFormat, name, value);
        }

        public static string Class(string className)
        {
            return String.Format(ClassValueFormat, className);
        }

        public static string Classes(params string[] classes)
        {
            return String.Format(ClassValueFormat, string.Join(" ", classes));
        }

        public static string Style(string key, string value)
        {
            return String.Format(StyleValueFormat, key, value);
        }

        public static string Style(string styleVal)
        {
            return String.Format(StyleAttrValueFormat, styleVal);
        }
    }
}
