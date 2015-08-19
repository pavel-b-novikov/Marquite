using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core.Html
{
    public class CssNames
    {

        public static string ValidationInputCssClassName { get; set; }

        public static string ValidationInputValidCssClassName { get; set; }

        public static string ValidationMessageCssClassName { get; set; }

        public static string ValidationMessageValidCssClassName { get; set; }

        public static string ValidationSummaryCssClassName { get; set; }

        public static string ValidationSummaryValidCssClassName { get; set; }

        static CssNames()
        {
            ValidationInputCssClassName = "input-validation-error";
            ValidationInputValidCssClassName = "input-validation-valid";
            ValidationMessageCssClassName = "field-validation-error";
            ValidationMessageValidCssClassName = "field-validation-valid";
            ValidationSummaryCssClassName = "validation-summary-errors";
            ValidationSummaryValidCssClassName = "validation-summary-valid";
        }
    }
}
