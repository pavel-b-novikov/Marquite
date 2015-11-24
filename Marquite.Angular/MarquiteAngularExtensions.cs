using System;
using System.Linq;
using System.Web.Mvc;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;
using Marquite.Core.Html;

namespace Marquite.Angular
{
    public static class MarquiteAngularExtensions
    {
        internal static string QuoteSafe(this string s)
        {
            s = s.Replace("'", "\\'").Replace("\"", "\\\"");
            return String.Concat("'", s, "'");
        }

        internal static string DoubleQuoteSafe(this string s)
        {
            s = s.Replace("\"", "\\\"");
            return String.Concat("\"", s, "\"");
        }
        public static T NgApp<T>(this T builder) where T : IHtmlBuilder
        {
            builder.SelfCloseAttr("ng-app");
            return builder;
        }

        public static T NgApp<T>(this T builder, string appModuleName) where T : IHtmlBuilder
        {
            builder.Attr("ng-app", appModuleName);
            return builder;
        }

        public static T NgCsp<T>(this T builder) where T : IHtmlBuilder
        {
            builder.SelfCloseAttr("ng-csp");
            return builder;
        }

        public static T NgController<T>(this T builder, string controllerName) where T : IHtmlBuilder
        {
            builder.Attr("ng-controller", controllerName);
            return builder;
        }

        public static T NgController<T>(this T builder, string controllerName, string asAlias) where T : IHtmlBuilder
        {
            builder.Attr("ng-controller", String.Format("{0} as {1}", controllerName, asAlias));
            return builder;
        }

        public static T NgController<T>(this T builder, string controllerName, INgContext contextWithModelName) where T : IHtmlBuilder
        {
            builder.Attr("ng-controller", String.Format("{0} as {1}", controllerName, contextWithModelName.ModelName));
            return builder;
        }

        public static T NgEvent<T>(this T builder, NgEvent evt, string handler) where T : IHtmlBuilder
        {
            var evtAttr = NgLookups.Lookup(evt);
            builder.Attr(evtAttr, handler, true);
            return builder;
        }

        public static T NgEvent<T>(this T builder, NgEvent evt, IAngularExpression handler) where T : IHtmlBuilder
        {
            var evtAttr = NgLookups.Lookup(evt);
            builder.Attr(evtAttr, handler.Build(), true);
            return builder;
        }

        public static T NgRequired<T>(this T builder, bool required = true)
            where T : IInputField
        {
            CheckAllowedTextField(builder);
            builder.Attr("ng-required", required ? "true" : "false");
            return builder;

        }

        public static T NgTrim<T>(this T builder, bool trim = true)
            where T : IInputField
        {
            CheckAllowedTextField(builder);
            builder.Attr("ng-trim", trim ? "true" : "false");
            return builder;

        }

        public static T NgBind<T>(this T builder, string expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-bind", expression);
            return builder;
        }

        public static T NgBind<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-bind", expression.Build());
            return builder;
        }

        public static T NgBindHtml<T>(this T builder, string expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-bind-html", expression);
            return builder;
        }

        public static T NgBindHtml<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-bind-html", expression.Build());
            return builder;
        }

        public static T NgBindTemplate<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-bind-template", expression);
            return builder;
        }

        public static T NgBindTemplate<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-bind-template", expression.ToHtmlString());
            return builder;
        }

        public static T NgClass<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-class", expression);
            return builder;
        }

        public static T NgClass<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-class", expression.ToHtmlString());
            return builder;
        }

        public static T NgClassEven<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-class-even", expression);
            return builder;
        }

        public static T NgClassEven<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-class-even", expression.ToHtmlString());
            return builder;
        }

        public static T NgClassOdd<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-class-odd", expression);
            return builder;
        }

        public static T NgClassOdd<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-class-odd", expression.ToHtmlString());
            return builder;
        }

        public static T NgCloak<T>(this T builder)
            where T : IHtmlBuilder
        {
            builder.SelfCloseAttr("ng-cloak");
            return builder;
        }

        public static T NgModel<T>(this T builder, string modelExpression)
            where T : IInputField
        {
            builder.Attr("ng-model", modelExpression);
            return builder;
        }

        public static T NgModel<T>(this T builder, IAngularExpression modelExpression)
            where T : IInputField
        {
            builder.Attr("ng-model", modelExpression.Build());
            return builder;
        }

        public static T NgTrueValue<T>(this T builder, string modelExpression)
            where T : IInputField
        {
            if (!builder.FieldType.IsCheckable()) throw new Exception("NgTrueValue and NgFalseValue are only applyable to checkboxes");
            builder.Attr("ng-true-value", modelExpression);
            return builder;
        }

        public static T NgTrueValue<T>(this T builder, IAngularExpression modelExpression)
            where T : IInputField
        {
            if (!builder.FieldType.IsCheckable()) throw new Exception("NgTrueValue and NgFalseValue are only applyable to checkboxes");
            builder.Attr("ng-true-value", modelExpression.Build());
            return builder;
        }

        public static T NgFalseValue<T>(this T builder, string modelExpression)
            where T : IInputField
        {
            if (!builder.FieldType.IsCheckable()) throw new Exception("NgTrueValue and NgFalseValue are only applyable to checkboxes");
            builder.Attr("ng-false-value", modelExpression);
            return builder;
        }

        public static T NgFalseValue<T>(this T builder, IAngularExpression modelExpression)
            where T : IInputField
        {
            if (!builder.FieldType.IsCheckable()) throw new Exception("NgTrueValue and NgFalseValue are only applyable to checkboxes");
            builder.Attr("ng-false-value", modelExpression.Build());
            return builder;
        }

        public static T NgChecked<T>(this T builder, string expression)
            where T : IInputField
        {
            if (!builder.FieldType.IsCheckable()) throw new Exception("NgTrueValue and NgFalseValue are only applyable to checkboxes");
            builder.Attr("ng-checked", expression);
            return builder;
        }

        public static T NgChecked<T>(this T builder, IAngularExpression expression)
            where T : IInputField
        {
            if (!builder.FieldType.IsCheckable()) throw new Exception("NgChecked is only applyable to checkboxes");
            builder.Attr("ng-checked", expression.Build());
            return builder;
        }

        public static T NgDisabled<T>(this T builder, string expression)
            where T : IInputField
        {
            builder.Attr("ng-disabled", expression);
            return builder;
        }

        public static T NgForm<T>(this T builder, string name)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-form", name);
            return builder;
        }

        public static T NgDisabled<T>(this T builder, IAngularExpression expression)
            where T : IInputField
        {
            builder.Attr("ng-disabled", expression.Build());
            return builder;
        }

        public static T NgMinlength<T>(this T builder, int length)
            where T : IInputField
        {
            CheckAllowedTextField(builder);
            builder.Attr("ng-minlength", length.ToString());
            return builder;
        }

        public static T NgMaxlength<T>(this T builder, int length)
           where T : IInputField
        {
            CheckAllowedTextField(builder);
            builder.Attr("ng-maxlength", length.ToString());
            return builder;
        }

        public static T NgPattern<T>(this T builder, string regexPattern)
           where T : IInputField
        {
            CheckAllowedTextField(builder);
            builder.Attr("ng-pattern", regexPattern);
            return builder;
        }

        private static void CheckAllowedTextField(IInputField builder)
        {
            if (builder.FieldType.Is(MarquiteInputType.Button)
                  || builder.FieldType.Is(MarquiteInputType.CheckBox)
                  || builder.FieldType.Is(MarquiteInputType.Radio)
                  || builder.FieldType.Is(MarquiteInputType.Select))
            {
                throw new Exception(String.Format("This method would not work with {0} field", builder.FieldType.ToString()));
            }
        }

        public static T NgHide<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-hide", expression);
            return builder;
        }

        public static T NgHide<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-hide", expression.Build());
            return builder;
        }

        public static T NgShow<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-show", expression);
            return builder;
        }

        public static T NgShow<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-show", expression.Build());
            return builder;
        }


        public static T NgReadonly<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-readonly", expression);
            return builder;
        }

        public static T NgReadonly<T>(this T builder, IAngularExpression expression)
            where T : IInputField
        {
            builder.Attr("ng-readonly", expression.Build());
            return builder;
        }

        public static T NgHref<T>(this T builder, string expression)
           where T : LinkBuilder
        {
            builder.Attr("ng-href", expression);
            return builder;
        }

        public static T NgHref<T>(this T builder, string expressionFormat, params IAngularExpression[] arguments)
           where T : LinkBuilder
        {
            var s = arguments.Select(c => c.ToHtmlString()).Cast<object>().ToArray();
            var fmt = string.Format(expressionFormat, s);
            builder.Attr("ng-href", fmt);
            return builder;
        }

        public static T NgSrc<T>(this T builder, string expression)
           where T : ImageBuilder
        {
            builder.Attr("ng-src", expression);
            return builder;
        }

        public static T NgSrc<T>(this T builder, string expressionFormat, params IAngularExpression[] arguments)
           where T : ImageBuilder
        {
            var s = arguments.Select(c => c.ToHtmlString()).Cast<object>().ToArray();
            var fmt = string.Format(expressionFormat, s);
            builder.Attr("ng-src", fmt);
            return builder;
        }

        public static T NgSrcSet<T>(this T builder, string expression)
           where T : ImageBuilder
        {
            builder.Attr("ng-srcset", expression);
            return builder;
        }

        public static T NgSrcSet<T>(this T builder, string expressionFormat, params IAngularExpression[] arguments)
           where T : ImageBuilder
        {
            var s = arguments.Select(c => c.ToHtmlString()).Cast<object>().ToArray();
            var fmt = string.Format(expressionFormat, s);
            builder.Attr("ng-srcset", fmt);
            return builder;
        }

        public static T NgIf<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-if", expression);
            return builder;
        }

        public static T NgIf<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-if", expression.Build());
            return builder;
        }

        public static T NgInit<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-init", expression);
            return builder;
        }

        public static T NgInit<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-init", expression.Build());
            return builder;
        }

        public static T NgList<T>(this T builder, string delimiter)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-list", delimiter);
            return builder;
        }

        public static T NgOpen<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-open", expression);
            return builder;
        }

        public static T NgOpen<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-open", expression.Build());
            return builder;
        }

        public static T NgModelOptions<T>(this T builder, NgModelOptions options)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-model-options", options.ToString());
            return builder;
        }

        public static T NgNonBindable<T>(this T builder)
           where T : IHtmlBuilder
        {
            builder.SelfCloseAttr("ng-non-bindable");
            return builder;
        }

        public static T NgOptions<T>(this T builder, string expression)
           where T : SelectBuilder
        {
            builder.Attr("ng-options", expression);
            return builder;
        }

        public static NgPluralize NgPluralize(this HtmlHelper h)
        {
            return new NgPluralize(h.Marq());
        }

        public static T NgRepeat<T>(this T builder, string expression)
           where T : IHtmlBuilder
        {
            builder.Attr("ng-repeat", expression);
            return builder;
        }

        public static T NgRepeat<T>(this T builder, IAngularInExpressionNongeneric expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-repeat", expression.Build());
            return builder;
        }

        public static T NgStyle<T>(this T builder, string expression)
          where T : IHtmlBuilder
        {
            builder.Attr("ng-style", expression);
            return builder;
        }

        public static T NgStyle<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-style", expression.Build());
            return builder;
        }

        public static T NgSubmit<T>(this T builder, string expression)
          where T : FormBuilder
        {
            builder.Attr("ng-submit", expression);
            return builder;
        }

        public static T NgSubmit<T>(this T builder, IAngularExpression expression)
            where T : FormBuilder
        {
            builder.Attr("ng-submit", expression.Build());
            return builder;
        }

        public static T NgSwitch<T>(this T builder, string expression)
         where T : IHtmlBuilder
        {
            builder.Attr("ng-switch", expression);
            return builder;
        }

        public static T NgSwitch<T>(this T builder, IAngularExpression expression)
            where T : IHtmlBuilder
        {
            builder.Attr("ng-switch", expression.Build());
            return builder;
        }

        public static T NgSwitchWhen<T>(this T builder, string expression)
        where T : IHtmlBuilder
        {
            builder.Attr("ng-switch-when", expression);
            return builder;
        }

        public static T NgSwitchDefault<T>(this T builder)
        where T : IHtmlBuilder
        {
            builder.SelfCloseAttr("ng-switch-default");
            return builder;
        }

        public static T NgValue<T>(this T builder, string modelExpression)
           where T : IInputField
        {
            builder.Attr("ng-value", modelExpression);
            return builder;
        }

        public static T NgValue<T>(this T builder, IAngularExpression modelExpression)
            where T : IInputField
        {
            builder.Attr("ng-value", modelExpression.Build());
            return builder;
        }
    }
}
