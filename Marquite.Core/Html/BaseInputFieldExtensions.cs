using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class BaseInputFieldExtensions
    {
        public static T Form<T>(this T b, string formId) where T : BaseInputField
        {
            return b.Attr("form", formId);
        }

        public static T Readonly<T>(this T b) where T : BaseInputField
        {
            return b.SelfCloseAttr("readonly");
        }

        public static T Required<T>(this T b) where T : BaseInputField
        {
            return b.SelfCloseAttr("required");
        }

        public static T Autofocus<T>(this T b) where T : BaseInputField
        {
            return b.SelfCloseAttr("autofocus");
        }
    }
}