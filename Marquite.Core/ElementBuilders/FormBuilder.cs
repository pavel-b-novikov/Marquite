using System.IO;
using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class FormBuilder : ElementHtmlBuilder<FormBuilder>
    {
        public FormBuilder(Marquite marquite) : base(marquite, "form")
        {
        }

        public FormBuilder Action(string url)
        {
            return Attr("action", url);
        }

        public FormBuilder Novalidate()
        {
            return SelfCloseAttr("novalidate");
        }

        public FormBuilder Method(string method)
        {
            return Attr("method",method);
        }

        public FormBuilder Method(FormMethod method)
        {
            return Attr("method", method==FormMethod.Get?"GET":"POST");
        }

        public FormBuilder Target(string target)
        {
            return Attr("target", target);
        }

        public FormBuilder Target(TargetWindowType type)
        {
            return Target(Lookups.Lookup(type));
        }

        public FormBuilder Autocomplete(bool enable)
        {
            return Attr("autocomplete", enable?"on":"off");
        }

        public FormBuilder Name(string name)
        {
            return Attr("name", name);
        }

        public FormBuilder Charset(string charset)
        {
            return Attr("accept-charset", charset);
        }

        public FormBuilder Enctype(string enctype)
        {
            return Attr("enctype", enctype);
        }

        public FormBuilder Enctype(FormEnctype enctype)
        {
            return Attr("enctype", Lookups.Lookup(enctype));
        }

        public override InnerTagScope Open()
        {
            Marquite.ViewContext.FormContext = new FormContext();
            Marquite.ViewContext.FormContext.FormId = GetAttr("id");
            return base.Open();
        }

        protected override void RenderAfterClosingTag(TextWriter tw)
        {
            var persist = Marquite.ViewContext.Writer;
            Marquite.ViewContext.Writer = tw;
            Marquite.ViewContext.OutputClientValidation();
            Marquite.ViewContext.FormContext = null;
            Marquite.ViewContext.Writer = persist;
            base.RenderAfterClosingTag(tw);
        }
    }

    [LookupEnum]
    public enum FormEnctype
    {
        [LookupString("application/x-www-form-urlencoded")]
        UrlEncoded,
        [LookupString("multipart/form-data")]
        Multipart,
        [LookupString("text/plain")]
        TextPlain
    }
    
}
