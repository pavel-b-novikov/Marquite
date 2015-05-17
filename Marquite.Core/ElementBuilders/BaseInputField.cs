using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public class BaseInputField<T> : ElementHtmlBuilder<T> where T : BaseInputField<T> 
    {
        public BaseInputField(Marquite marquite, string tagName) : base(marquite, tagName)
        {
        }

        public T Form(string formId)
        {
            return Attr("form", formId);
        }

        public T Readonly()
        {
            return SelfCloseAttr("readonly");
        }

        public T Required()
        {
            return SelfCloseAttr("required");
        }

        public T Disabled()
        {
            return SelfCloseAttr("disabled");
        }

        public T Autofocus()
        {
            return SelfCloseAttr("autofocus");
        }

        public T Name(string fieldName)
        {
            return Attr("name", fieldName);
        }

        
    }

    
}
