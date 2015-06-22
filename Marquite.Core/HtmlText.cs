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
    public static class HtmlText
    {
        private const string NameValueFormat = "{0}=\"{1}\"";
        private const string ClassValueFormat = "class=\"{0}\"";
        private const string StyleValueFormat = "{0}:{1};";
        private const string StyleAttrValueFormat = "style=\"{0}\"";
        private const string IdAttrValueFormat = "id=\"{0}\"";

        public static string Id(string id)
        {
            return String.Format(IdAttrValueFormat,id);
        }

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

        public static string OpenTag(string tagName, params string[] attributes)
        {
            return String.Format("<{0} {1}>", tagName, string.Join(" ", attributes));
        }

        public static string ClosingTag(string tagName)
        {
            return String.Format("</{0}>", tagName);
        }

        public static string SelfClosingTag(string tagName, params string[] attributes)
        {
            return String.Format("<{0} {1} />", tagName, string.Join(" ", attributes));
        }
    }
}
