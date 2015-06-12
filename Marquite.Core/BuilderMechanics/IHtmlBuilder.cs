using Marquite.Core.Rendering;

namespace Marquite.Core.BuilderMechanics
{
    public interface IHtmlBuilder : IRenderingClient
    {
        string Tag { get; }

        IHtmlBuilder NonGeneric_Id(string id);
        IHtmlBuilder NonGeneric_Css(Css property, string value);
        IHtmlBuilder NonGeneric_Attr(string attrName, string value,bool replaceExisting);
        IHtmlBuilder NonGeneric_Attr(string attrName, string value);
        IHtmlBuilder NonGeneric_SelfCloseAttr(string attrName);
        IHtmlBuilder NonGeneric_Data(string key, string value);
        IHtmlBuilder NonGeneric_Aria(string key, string value);
        IHtmlBuilder NonGeneric_AddClass(string clazz);
        IHtmlBuilder NonGeneric_RemoveAttr(string attr);
        IHtmlBuilder NonGeneric_RemoveClass(string clazz);
        IHtmlBuilder NonGeneric_RemoveData(string clazz);
        IHtmlBuilder NonGeneric_RemoveAria(string clazz);
        IHtmlBuilder NonGeneric_LeadingHtml(string html);
        IHtmlBuilder NonGeneric_LeadingText(string text);
        IHtmlBuilder NonGeneric_LeadingHtml(IRenderingClient content);
        IHtmlBuilder NonGeneric_TrailingHtml(string html);
        IHtmlBuilder NonGeneric_TrailingText(string text);
        IHtmlBuilder NonGeneric_TrailingHtml(IRenderingClient content);
        IHtmlBuilder NonGeneric_PullInnerContentUp();
    }
}