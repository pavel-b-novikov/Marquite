using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Marquite.Bootstrap.Elements;
using Marquite.Bootstrap.Extensions;
using Marquite.Bootstrap.Forms;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Html;

namespace LuuritV3.Classes
{
    public static class UiExtensions
    {
        public static FormGroupBuilder FGTextboxWithValidationFor<TModel, TData>(this HtmlHelper<TModel> h,
            Expression<Func<TModel, TData>> field)
        {
            return
                h.FormGroup().AddElement(h.LabelFor(field), h.TextBoxFor(field))
                    .AddElement(null, h.ValidationMessageFor(field));
        }

        public static FormGroupBuilder FGTextboxWithValidationFor<TModel, TData>(this HtmlHelper<TModel> h,
            Expression<Func<TModel, TData>> field,Action<InputElementBuilder> inputAction)
        {
            var input = h.TextBoxFor(field);
            inputAction(input);
            return
                h.FormGroup().AddElement(h.LabelFor(field), input)
                    .AddElement(null, h.ValidationMessageFor(field));
        }

        public static FormGroupBuilder FGPasswordWithValidationFor<TModel, TData>(this HtmlHelper<TModel> h,
            Expression<Func<TModel, TData>> field)
        {
            return
                h.FormGroup().AddElement(h.LabelFor(field), h.PasswordFor(field))
                    .AddElement(null, h.ValidationMessageFor(field));
        }

        public static FormGroupBuilder FGPasswordWithValidationFor<TModel, TData>(this HtmlHelper<TModel> h,
            Expression<Func<TModel, TData>> field, Action<InputElementBuilder> inputAction)
        {
            var input = h.PasswordFor(field);
            inputAction(input);
            return
                h.FormGroup().AddElement(h.LabelFor(field), input)
                    .AddElement(null, h.ValidationMessageFor(field));
        }

        public static FormGroupBuilder FGBootstrapSubmitButton<TModel>(this HtmlHelper<TModel> h)
        {
            return h.FormGroup().AddElement(null, h.Bs().Button("Save").Block().Attr("type", "submit"));
        }

        public static FormGroupBuilder FGBootstrapSubmitButton<TModel>(this HtmlHelper<TModel> h, Action<BootstrapButtonBuilder> buttonAction)
        {
            var btn = h.Bs().Button("Save").Block().Attr("type", "submit");
            buttonAction(btn);
            return h.FormGroup().AddElement(null, btn);
        }

        public static AjaxOptions StandardOptionsForBasicResult(this AjaxOptions o, string loadingElementSelector,string messageFormatFunction = null)
        {
            const string beginFunctionFormat = @"var e = $('{0}'); e.addClass('disabled'); e.attr('disabled', 'disabled'); e.append($Common.getIndicator());";
            const string endFunctionFormat = @"var e = $('{0}'); e.removeClass('disabled'); e.removeAttr('disabled'); var ind = e.find('.' + $Common.indicatorClassName); ind.remove();";
            const string successFunctionFormatWithoutMessageFormatter = @"if (data.Success) { data.Message?ShowNotification(data.Message):ShowNotification('Success'); } else { data.Message?ShowNotification(data.Message,'error'):ShowNotification('Failed','error'); }";
            const string successFunctionWithMessageFormatter = @"var f = {0}; var msg = f(data); data.Success?ShowNotification(msg):ShowNotification(msg,'error');";
            o.OnBegin = String.Format(beginFunctionFormat,loadingElementSelector);
            o.OnComplete = String.Format(endFunctionFormat,loadingElementSelector);
            if (string.IsNullOrEmpty(messageFormatFunction))
            {
                o.OnSuccess = successFunctionFormatWithoutMessageFormatter;
            }
            else
            {
                o.OnSuccess = String.Format(successFunctionWithMessageFormatter,messageFormatFunction);
            }

            return o;
        }

    }
}