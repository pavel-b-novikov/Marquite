using System.IO;
using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core.ElementBuilders
{
    public class FormBuilder : FormBuilderBase<FormBuilder>
    {
        public FormBuilder(Marquite marquite) : base(marquite)
        {
        }
    }
    public class FormBuilderBase<T> : ElementHtmlBuilder<T> where T : FormBuilderBase<T>
    {
        public FormBuilderBase(Marquite marquite)
            : base(marquite, "form")
        {
        }

        public T Action(string url)
        {
            return Attr("action", url);
        }

        public T Novalidate()
        {
            return SelfCloseAttr("novalidate");
        }

        public T Method(string method)
        {
            return Attr("method",method);
        }

        public T Method(FormMethod method)
        {
            return Attr("method", method==FormMethod.Get?"GET":"POST");
        }

        public T Target(string target)
        {
            return Attr("target", target);
        }

        public T Target(TargetWindowType type)
        {
            return Target(Lookups.Lookup(type));
        }

        public T Autocomplete(bool enable)
        {
            return Attr("autocomplete", enable?"on":"off");
        }

        public T Name(string name)
        {
            return Attr("name", name);
        }

        public T Charset(string charset)
        {
            return Attr("accept-charset", charset);
        }

        public T Enctype(string enctype)
        {
            return Attr("enctype", enctype);
        }

        public T Enctype(FormEnctype enctype)
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
