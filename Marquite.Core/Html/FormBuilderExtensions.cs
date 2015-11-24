using System.Web.Mvc;
using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class FormBuilderExtensions
    {
        public static T Action<T>(this T b,string url) where T : FormBuilder 
        {
            return b.Attr("action", url);
        }

        public static T Novalidate<T>(this T b) where T : FormBuilder 
        {
            return b.SelfCloseAttr("novalidate");
        }

        public static T Method<T>(this T b,string method) where T : FormBuilder 
        {
            return b.Attr("method", method);
        }

        public static T Method<T>(this T b,FormMethod method) where T : FormBuilder 
        {
            return b.Attr("method", method == FormMethod.Get ? "GET" : "POST");
        }

        public static T Target<T>(this T b,string target) where T : FormBuilder 
        {
            return b.Attr("target", target);
        }

        public static T Target<T>(this T b,TargetWindowType type) where T : FormBuilder 
        {
            return Target(b,Lookups.Lookup(type));
        }

        public static T Autocomplete<T>(this T b,bool enable) where T : FormBuilder 
        {
            return b.Attr("autocomplete", enable ? "on" : "off");
        }

        public static T Charset<T>(this T b,string charset) where T : FormBuilder 
        {
            return b.Attr("accept-charset", charset);
        }

        public static T Enctype<T>(this T b,string enctype) where T : FormBuilder 
        {
            return b.Attr("enctype", enctype);
        }

        public static T Enctype<T>(this T b,FormEnctype enctype) where T : FormBuilder 
        {
            return b.Attr("enctype", Lookups.Lookup(enctype));
        }
    }
}