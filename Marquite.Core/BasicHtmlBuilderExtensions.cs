using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public static class BasicHtmlBuilderExtensions
    {
        #region CSS
        public static T Css<T>(this T b, Css property, string value) where T : BasicHtmlBuilder
        {
            b.Style[property] = value;
            return b;
        }

        public static T RemoveClass<T>(this T b, string clazz) where T : BasicHtmlBuilder
        {
            b.Attributes.Remove(clazz);
            return b;
        }
        #endregion

        #region Add attributes
        public static T Attr<T>(this T b, string attrName, string value, bool replaceExisting) where T : BasicHtmlBuilder
        {
            // To self-closed attributes use method 'SelfCloseAttr'
            if (attrName == "class") throw new Exception("Dont try to operate directly with class attribute. Use AddClass and RemoveClass for manupulation with classes.");
            if (value == null)
            {
                if (b.Attributes.ContainsKey(attrName)) b.Attributes.Remove(attrName);
                return b;
            }
            if (!replaceExisting && b.Attributes.ContainsKey(attrName)) return b;
            b.Attributes[attrName] = value;
            if (string.Compare(attrName, "id", StringComparison.OrdinalIgnoreCase) == 0)
            {
                b.IdVal = value;
            }
            return b;
        }

        public static T Attr<T>(this T b, string attrName, string value) where T : BasicHtmlBuilder
        {
            return Attr(b, attrName, value, true);
        }

        public static T SelfClose<T>(this T b, bool selfClose = true) where T : BasicHtmlBuilder
        {
            b.IsSelfClosing = selfClose;
            return b;
        }

        public static T SelfCloseAttr<T>(this T b, string attrName) where T : BasicHtmlBuilder
        {
            if (attrName == "class") throw new Exception("Dont try to operate directly with class attribute. Use AddClass and RemoveClass for manupulation with classes.");
            b.Attributes[attrName] = null;
            return b;
        }

        public static T Data<T>(this T b, string key, string value) where T : BasicHtmlBuilder
        {
            return Attr(b, "data-" + key, value);
        }

        public static T Aria<T>(this T b, string key, string value) where T : BasicHtmlBuilder
        {
            return Attr(b, "aria-" + key, value);
        }

        public static T AddClass<T>(this T b, string clazz) where T : BasicHtmlBuilder
        {
            if (string.IsNullOrEmpty(clazz)) return b;
            if (!b.CssClasses.Contains(clazz)) b.CssClasses.Add(clazz);
            return b;
        }

        public static T FreeAttribute<T>(this T b, string content) where T : BasicHtmlBuilder
        {
            b.Free.Add(content);
            return b;
        }
        #endregion

        #region Remove attributes
        public static T RemoveAttr<T>(this T b, string attr) where T : BasicHtmlBuilder
        {
            if (attr == "class") throw new Exception("Dont try to remove class attribute. Use AddClass and RemoveClass for manupulation with classes.");
            b.Attributes.Remove(attr);
            return b;
        }

        public static T RemoveData<T>(this T b, string clazz) where T : BasicHtmlBuilder
        {
            return RemoveAttr(b, "data-" + clazz);
        }

        public static T RemoveAria<T>(this T b, string clazz) where T : BasicHtmlBuilder
        {
            return RemoveAttr(b, "aria-" + clazz);
        }
        #endregion

        #region Append
        

        public static T Append<T>(this T b, IRenderingClient content) where T : BasicHtmlBuilder
        {
            b.Content.TrailingHtml(content);
            return b;
        }
        
        #endregion

#region Before and after

        public static T Before<T>(this T b, Action<IRenderingQueue> beforeContent) where T : BasicHtmlBuilder
        {
            beforeContent(b.Before);
            return b;
        }

        public static T After<T>(this T b, Action<IRenderingQueue> afterContent) where T : BasicHtmlBuilder
        {
            afterContent(b.After);
            return b;
        }
        public static T Content<T>(this T b, Action<IRenderingQueue> content) where T : BasicHtmlBuilder
        {
            content(b.Content);
            return b;
        }
        
#endregion

        public static T When<T>(this T b, bool condition, Func<T, T> properties) where T : BasicHtmlBuilder
        {
            if (condition)
            {
                return properties(b);
            }
            return b;
        }

        public static T When<T>(this T b, bool condition, Action<T> properties) where T : BasicHtmlBuilder
        {
            if (condition && properties != null)
            {
                properties(b);
            }
            return b;
        }

        public static T Mixin<T>(this T b, Func<T, T> mixin) where T : BasicHtmlBuilder
        {
            if (mixin == null) return b;
            return mixin(b);
        }

        public static T Mixin<T>(this T b, Action<T> mixin) where T : BasicHtmlBuilder
        {
            if (mixin == null) return b;
            mixin(b);
            return b;
        }

        public static T Id<T>(this T b, string id) where T : BasicHtmlBuilder
        {
            b.IdVal = id;
            b.Attr("id", id);
            return b;
        }

        public static void MergeAttributes<T, TKey, TValue>(this T b, IDictionary<TKey, TValue> attributes, bool replaceExisting) where T : BasicHtmlBuilder
        {
            if (attributes != null)
            {
                foreach (var entry in attributes)
                {
                    string key = System.Convert.ToString(entry.Key, CultureInfo.InvariantCulture);
                    string value = System.Convert.ToString(entry.Value, CultureInfo.InvariantCulture);
                    if (key == "class")
                    {
                        if (value.Contains(" "))
                        {
                            var classes = value.Split(' ');
                            foreach (var @class in classes)
                            {
                                AddClass(b, @class);
                            }
                        }
                        else
                        {
                            AddClass(b, value);
                        }
                    }
                    else
                    {
                        Attr(b, key, value, replaceExisting);
                    }
                }
            }
        }

        public static void MergeAttributes<T, TKey, TValue>(this T b, IDictionary<TKey, TValue> attributes) where T : BasicHtmlBuilder
        {
            MergeAttributes(b, attributes, replaceExisting: false);
        }

        public static void FindAndRemoveClass<T>(this T b, string clazz) where T : BasicHtmlBuilder
        {
            var auto = AutocompleteClass(b, clazz);
            if (auto == null) return;
            RemoveClass(b, auto);
        }

        public static string AutocompleteClass<T>(this T b, string classStartsWith) where T : BasicHtmlBuilder
        {
            return b.CssClasses.FirstOrDefault(c => c.StartsWith(classStartsWith));
        }

        public static bool ContainsClass<T>(this T b, string clazz) where T : BasicHtmlBuilder
        {
            return b.CssClasses.Contains(clazz);
        }

        public static string GetAttr<T>(this T b, string data) where T : BasicHtmlBuilder
        {
            if (!b.Attributes.ContainsKey(data)) return null;
            return b.Attributes[data];
        }

        public static bool ContainsAttr<T>(this T b, string attrKey) where T : BasicHtmlBuilder
        {
            return b.Attributes.ContainsKey(attrKey);
        }

        public static string GetData<T>(this T b, string data) where T : BasicHtmlBuilder
        {
            data = "data-" + data;
            return GetAttr(b, data);
        }
        public static string GetAria<T>(this T b, string data) where T : BasicHtmlBuilder
        {
            data = "aria-" + data;
            return GetAttr(b, data);
        }

        public static void ReplaceClass<T>(this T b, string classStartsWith, string anotherClass) where T : BasicHtmlBuilder
        {
            string already = AutocompleteClass(b, classStartsWith);
            if (already != null) RemoveClass(b, already);
            AddClass(b, anotherClass);
        }

        public static T ChangeTag<T>(this T b, string tag) where T : IHtmlBuilder
        {
            b.TagName = tag;
            return b;
        }

        public static T2 Convert<T1, T2>(this T1 b, Func<T1, T2> converter)
            where T1 : IHtmlBuilder
            where T2 : IHtmlBuilder
        {
            return converter(b);
        }

        public static T EnsureId<T>(this T b)
            where T : BasicHtmlBuilder
        {
            if (string.IsNullOrEmpty(b.IdVal))
            {
                b.Id(b.Marquite.GenerateNewId());
            }
            return b;
        }

    }
}
