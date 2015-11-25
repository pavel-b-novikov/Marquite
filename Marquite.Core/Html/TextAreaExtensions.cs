using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Marquite.Core.Elements;

namespace Marquite.Core.Html
{
    public static class TextAreaExtensions
    {
        // These values are similar to the defaults used by WebForms
        // when using <asp:TextBox TextMode="MultiLine"> without specifying
        // the Rows and Columns attributes.
        private const int TextAreaRows = 2;
        private const int TextAreaColumns = 20;
        
        public static TextareaBuilder TextArea(this HtmlHelper htmlHelper, string name)
        {
            return TextArea(htmlHelper, name, null /* value */, null /* htmlAttributes */);
        }

        public static TextareaBuilder TextArea(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        {
            return TextArea(htmlHelper, name, null /* value */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static TextareaBuilder TextArea(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
        {
            return TextArea(htmlHelper, name, null /* value */, htmlAttributes);
        }

        public static TextareaBuilder TextArea(this HtmlHelper htmlHelper, string name, string value)
        {
            return TextArea(htmlHelper, name, value, null /* htmlAttributes */);
        }

        public static TextareaBuilder TextArea(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes)
        {
            return TextArea(htmlHelper, name, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static TextareaBuilder TextArea(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromStringExpression(name, htmlHelper.ViewContext.ViewData);
            if (value != null)
            {
                metadata.Model = value;
            }

            return TextAreaHelper(htmlHelper, metadata, name, htmlAttributes);
        }

        public static TextareaBuilder TextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, object htmlAttributes)
        {
            return TextArea(htmlHelper, name, value, rows, columns, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static TextareaBuilder TextArea(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromStringExpression(name, htmlHelper.ViewContext.ViewData);
            if (value != null)
            {
                metadata.Model = value;
            }

            return TextAreaHelper(htmlHelper, metadata, name, htmlAttributes,rows:rows,columns:columns);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static TextareaBuilder TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return TextAreaFor(htmlHelper, expression, (IDictionary<string, object>)null);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static TextareaBuilder TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return TextAreaFor(htmlHelper, expression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static TextareaBuilder TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return TextAreaHelper(htmlHelper,
                                  ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
                                  ExpressionHelper.GetExpressionText(expression),
                                  htmlAttributes);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static TextareaBuilder TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, object htmlAttributes)
        {
            return TextAreaFor(htmlHelper, expression, rows, columns, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static TextareaBuilder TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return TextAreaHelper(htmlHelper,
                                  ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
                                  ExpressionHelper.GetExpressionText(expression),
                                  htmlAttributes,rows:rows,columns:columns);
        }

        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "If this fails, it is because the string-based version had an empty 'name' parameter")]
        internal static TextareaBuilder TextAreaHelper(HtmlHelper htmlHelper, ModelMetadata modelMetadata, string name, IDictionary<string, object> htmlAttributes, string innerHtmlPrefix = null,int rows = TextAreaRows, int columns = TextAreaColumns
            )
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Name should not be null", "name");
            }

            var marq = htmlHelper.Marq();

            TextareaBuilder tagBuilder = new TextareaBuilder(marq);
            tagBuilder.Id(fullName);
            tagBuilder.MergeAttributes(htmlAttributes, true);
            tagBuilder.Rows(rows).Cols(columns);
            tagBuilder.Name(fullName);

            // If there are any errors for a named field, we add the CSS attribute.
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState) && modelState.Errors.Count > 0)
            {
                tagBuilder.AddClass(CssNames.ValidationInputCssClassName);
            }

            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, modelMetadata));

            string value;
            if (modelState != null && modelState.Value != null)
            {
                value = modelState.Value.AttemptedValue;
            }
            else if (modelMetadata.Model != null)
            {
                value = modelMetadata.Model.ToString();
            }
            else
            {
                value = String.Empty;
            }

            // The first newline is always trimmed when a TextArea is rendered, so we add an extra one
            // in case the value being rendered is something like "\r\nHello".
            tagBuilder.Append((innerHtmlPrefix ?? Environment.NewLine) + HttpUtility.HtmlEncode(value));

            return tagBuilder;
        }
    }
}
