using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Extensions
{
    public static class FormsExtensions
    {
        public static T Inline<T>(this T t) where T : FormBuilderBase<T>
        {
            return t.AddClass("form-inline");
        }

        public static T InlineForm<T>(this T t) where T : ElementHtmlBuilder<T>
        {
            return t.AddClass("form-inline");
        }
    }
}
