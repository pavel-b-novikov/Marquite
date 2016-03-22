using System;
using System.Linq;
using System.Web.Mvc;

namespace Marquite.Angular
{
    public class Ng
    {
    }

    public static class HtmlAngularExtensions
    {
        public static Ng Ng(this HtmlHelper h)
        {
            return null;
        }

        public static MvcHtmlString App(this Ng builder)
        {
            return MvcHtmlString.Create("ng-app");
        }

        public static MvcHtmlString App(this Ng builder, string appModuleName)
        {
            return MvcHtmlString.Create(string.Format("ng-app=\"{0}\"", appModuleName));
        }

        public static MvcHtmlString Csp(this Ng builder)
        {
            return MvcHtmlString.Create("ng-csp");
        }

        public static MvcHtmlString Controller(this Ng builder, string controllerName)
        {
            return MvcHtmlString.Create(string.Format("ng-controller=\"{0}\"", controllerName));
        }

        public static MvcHtmlString Controller(this Ng builder, string controllerName, string asAlias)
        {
            return
                MvcHtmlString.Create(string.Format("ng-controller=\"{0}\"",
                    string.Format("{0} as {1}", controllerName, asAlias)));
        }

        public static MvcHtmlString Controller(this Ng builder, string controllerName, INgContext contextWithModelName)
        {
            return
                MvcHtmlString.Create(string.Format("ng-controller=\"{0}\"",
                    string.Format("{0} as {1}", controllerName, contextWithModelName.ModelName)));
        }

        public static MvcHtmlString Controller(this Ng builder, INgContext contextWithModelName)
        {
            return
                MvcHtmlString.Create(string.Format("ng-controller=\"{0}\"",
                    string.Format("{0} as {1}", contextWithModelName.ControllerName, contextWithModelName.ModelName)));
        }

        public static MvcHtmlString Event(this Ng builder, NgEvent evt, string handler)
        {
            var evtAttr = NgLookups.Lookup(evt);
            return MvcHtmlString.Create(string.Format("{0}=\"{1}\"", evtAttr, handler));
        }

        public static MvcHtmlString Event(this Ng builder, NgEvent evt, IAngularExpression handler)
        {
            var evtAttr = NgLookups.Lookup(evt);
            return MvcHtmlString.Create(string.Format("{0}=\"{1}\"", evtAttr, handler.Build()));
        }

        public static MvcHtmlString Required(this Ng builder, bool required = true)
        {
            return MvcHtmlString.Create(string.Format("ng-required=\"{0}\"", required ? "true" : "false"));
        }

        public static MvcHtmlString Required(this Ng builder, string condition)
        {
            return MvcHtmlString.Create(string.Format("ng-required=\"{0}\"", condition));
        }

        public static MvcHtmlString Required(this Ng builder, IAngularExpression condition)
        {
            return MvcHtmlString.Create(string.Format("ng-required=\"{0}\"", condition.Build()));
        }

        public static MvcHtmlString Trim(this Ng builder, bool trim = true)
        {
            return MvcHtmlString.Create(string.Format("ng-trim=\"{0}\"", trim ? "true" : "false"));
        }

        public static MvcHtmlString Bind(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-bind=\"{0}\"", expression));
        }

        public static MvcHtmlString Bind(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-bind=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString BindHtml(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-bind-html=\"{0}\"", expression));
        }

        public static MvcHtmlString BindHtml(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-bind-html=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString BindTemplate(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-bind-template=\"{0}\"", expression));
        }

        public static MvcHtmlString BindTemplate(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-bind-template=\"{0}\"", expression.ToHtmlString()));
        }

        public static MvcHtmlString Class(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-class=\"{0}\"", expression));
        }

        public static MvcHtmlString Class(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-class=\"{0}\"", expression.ToHtmlString()));
        }

        public static MvcHtmlString Class(this Ng builder, Action<NgClassBuilder> classBuilderConf)
        {
            var clb = new NgClassBuilder();
            classBuilderConf(clb);
            return MvcHtmlString.Create(string.Format("ng-class=\"{0}\"", clb.Build()));
        }

        public static MvcHtmlString ClassEven(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-class-even=\"{0}\"", expression));
        }

        public static MvcHtmlString ClassEven(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-class-even=\"{0}\"", expression.ToHtmlString()));
        }

        public static MvcHtmlString ClassOdd(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-class-odd=\"{0}\"", expression));
        }

        public static MvcHtmlString ClassOdd(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-class-odd=\"{0}\"", expression.ToHtmlString()));
        }

        public static MvcHtmlString Cloak(this Ng builder)
        {
            return MvcHtmlString.Create("ng-cloak");
        }

        public static MvcHtmlString Model(this Ng builder, string modelExpression)
        {
            return MvcHtmlString.Create(string.Format("ng-model=\"{0}\"", modelExpression));
        }

        public static MvcHtmlString ModelButton(this Ng builder)
        {
            return MvcHtmlString.Create(string.Format("ng-model=\"{0}\"", "button"));
        }

        public static MvcHtmlString Model(this Ng builder, IAngularExpression modelExpression)
        {
            return MvcHtmlString.Create(string.Format("ng-model=\"{0}\"", modelExpression.Build()));
        }

        public static MvcHtmlString TrueValue(this Ng builder, string modelExpression)
        {
            return MvcHtmlString.Create(string.Format("ng-true-value=\"{0}\"", modelExpression));
        }

        public static MvcHtmlString TrueValue(this Ng builder, IAngularExpression modelExpression)
        {
            return MvcHtmlString.Create(string.Format("ng-true-value=\"{0}\"", modelExpression.Build()));
        }

        public static MvcHtmlString FalseValue(this Ng builder, string modelExpression)
        {
            return MvcHtmlString.Create(string.Format("ng-false-value=\"{0}\"", modelExpression));
        }

        public static MvcHtmlString FalseValue(this Ng builder, IAngularExpression modelExpression)
        {
            return MvcHtmlString.Create(string.Format("ng-false-value=\"{0}\"", modelExpression.Build()));
        }

        public static MvcHtmlString Checked(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-checked=\"{0}\"", expression));
        }

        public static MvcHtmlString Checked(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-checked=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString Disabled(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-disabled=\"{0}\"", expression));
        }

        public static MvcHtmlString Disabled(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-disabled=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString Form(this Ng builder, string name)
        {
            return MvcHtmlString.Create(string.Format("ng-form=\"{0}\"", name));
        }

        public static MvcHtmlString Minlength(this Ng builder, int length)
        {
            return MvcHtmlString.Create(string.Format("ng-minlength=\"{0}\"", length));
        }

        public static MvcHtmlString Maxlength(this Ng builder, int length)
        {
            return MvcHtmlString.Create(string.Format("ng-maxlength=\"{0}\"", length));
        }

        public static MvcHtmlString Pattern(this Ng builder, string regexPattern)
        {
            return MvcHtmlString.Create(string.Format("ng-pattern=\"{0}\"", string.Format("/{0}/", regexPattern)));
        }

        public static MvcHtmlString Hide(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-hide=\"{0}\"", expression));
        }

        public static MvcHtmlString Hide(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-hide=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString Show(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-show=\"{0}\"", expression));
        }

        public static MvcHtmlString Show(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-show=\"{0}\"", expression.Build()));
        }


        public static MvcHtmlString Readonly(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-readonly=\"{0}\"", expression));
        }

        public static MvcHtmlString Readonly(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-readonly=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString Href(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-href=\"{0}\"", expression));
        }

        public static MvcHtmlString Href(this Ng builder, string expressionFormat, params IAngularExpression[] arguments)
        {
            var s = arguments.Select(c => c.ToHtmlString()).Cast<object>().ToArray();
            var fmt = string.Format(expressionFormat, s);
            return MvcHtmlString.Create(string.Format("ng-href=\"{0}\"", fmt));
        }

        public static MvcHtmlString Src(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-src=\"{0}\"", expression));
        }

        public static MvcHtmlString Src(this Ng builder, string expressionFormat, params IAngularExpression[] arguments)
        {
            var s = arguments.Select(c => c.ToHtmlString()).Cast<object>().ToArray();
            var fmt = string.Format(expressionFormat, s);
            return MvcHtmlString.Create(string.Format("ng-src=\"{0}\"", fmt));
        }

        public static MvcHtmlString SrcSet(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-srcset=\"{0}\"", expression));
        }

        public static MvcHtmlString SrcSet(this Ng builder, string expressionFormat,
            params IAngularExpression[] arguments)
        {
            var s = arguments.Select(c => c.ToHtmlString()).Cast<object>().ToArray();
            var fmt = string.Format(expressionFormat, s);
            return MvcHtmlString.Create(string.Format("ng-srcset=\"{0}\"", fmt));
        }

        public static MvcHtmlString If(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-if=\"{0}\"", expression));
        }

        public static MvcHtmlString If(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-if=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString Init(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-init=\"{0}\"", expression));
        }

        public static MvcHtmlString Init(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-init=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString List(this Ng builder, string delimiter)
        {
            return MvcHtmlString.Create(string.Format("ng-list=\"{0}\"", delimiter));
        }

        public static MvcHtmlString Open(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-open=\"{0}\"", expression));
        }

        public static MvcHtmlString Open(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-open=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString ModelOptions(this Ng builder, NgModelOptions options)
        {
            return MvcHtmlString.Create(string.Format("ng-model-options=\"{0}\"", options));
        }

        public static MvcHtmlString NonBindable(this Ng builder)
        {
            return MvcHtmlString.Create("ng-non-bindable");
        }

        public static MvcHtmlString Options(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-options=\"{0}\"", expression));
        }

        public static MvcHtmlString Repeat(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-repeat=\"{0}\"", expression));
        }

        public static MvcHtmlString Repeat(this Ng builder, IAngularInExpressionNongeneric expression)
        {
            return MvcHtmlString.Create(string.Format("ng-repeat=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString Style(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-style=\"{0}\"", expression));
        }

        public static MvcHtmlString Style(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-style=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString Submit(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-submit=\"{0}\"", expression));
        }

        public static MvcHtmlString Submit(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-submit=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString Switch(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-switch=\"{0}\"", expression));
        }

        public static MvcHtmlString Switch(this Ng builder, IAngularExpression expression)
        {
            return MvcHtmlString.Create(string.Format("ng-switch=\"{0}\"", expression.Build()));
        }

        public static MvcHtmlString SwitchWhen(this Ng builder, string expression)
        {
            return MvcHtmlString.Create(string.Format("ng-switch-when=\"{0}\"", expression));
        }

        public static MvcHtmlString SwitchDefault(this Ng builder)
        {
            return MvcHtmlString.Create("ng-switch-default");
        }

        public static MvcHtmlString Value(this Ng builder, string modelExpression)
        {
            return MvcHtmlString.Create(string.Format("ng-value=\"{0}\"", modelExpression));
        }

        public static MvcHtmlString Value(this Ng builder, IAngularExpression modelExpression)
        {
            return MvcHtmlString.Create(string.Format("ng-value=\"{0}\"", modelExpression.Build()));
        }
    }
}