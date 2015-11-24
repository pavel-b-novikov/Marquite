using System.IO;
using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Html;

namespace Marquite.Core.Elements
{
    
    public class FormBuilder : ElementHtmlBuilder, INameable
    {
        public FormBuilder(IMarquite marquite)
            : base(marquite, "form")
        {
        }
        
        public override ITagScope Open(bool pullExistingContentAtTop = false)
        {
            Marquite.ViewContext.FormContext = new FormContext {FormId = this.GetAttr("id")};
            return base.Open(pullExistingContentAtTop);
        }

        public override void RenderAfterClosingTag(TextWriter tw)
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
