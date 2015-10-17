using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Marquite.Core.ElementBuilders;

namespace Marquite.Core.Html
{
    public static class LabelExtensions
    {
        public static LabelBuilder Label(this HtmlHelper html, string expression)
        {
            return Label(html,
                         expression,
                         labelText: null);
        }

        public static LabelBuilder Label(this HtmlHelper html, string expression, string labelText)
        {
            return Label(html, expression, labelText, htmlAttributes: null, metadataProvider: null);
        }

        public static LabelBuilder Label(this HtmlHelper html, string expression, object htmlAttributes)
        {
            return Label(html, expression, labelText: null, htmlAttributes: htmlAttributes, metadataProvider: null);
        }

        public static LabelBuilder Label(this HtmlHelper html, string expression, IDictionary<string, object> htmlAttributes)
        {
            return Label(html, expression, labelText: null, htmlAttributes: htmlAttributes, metadataProvider: null);
        }

        public static LabelBuilder Label(this HtmlHelper html, string expression, string labelText, object htmlAttributes)
        {
            return Label(html, expression, labelText, htmlAttributes, metadataProvider: null);
        }

        public static LabelBuilder Label(this HtmlHelper html, string expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            return Label(html, expression, labelText, htmlAttributes, metadataProvider: null);
        }

        internal static LabelBuilder Label(this HtmlHelper html, string expression, string labelText, object htmlAttributes, ModelMetadataProvider metadataProvider)
        {
            return Label(html,
                         expression,
                         labelText,
                         HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                         metadataProvider);
        }

        internal static LabelBuilder Label(this HtmlHelper html, string expression, string labelText, IDictionary<string, object> htmlAttributes, ModelMetadataProvider metadataProvider)
        {
            if (metadataProvider!=null) throw new ArgumentException("Metadata provider not null","metadataProvider");
            return LabelHelper(html,
                               ModelMetadata.FromStringExpression(expression, html.ViewData),
                               expression,
                               labelText,
                               htmlAttributes);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static LabelBuilder LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return LabelFor<TModel, TValue>(html, expression, labelText: null);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static LabelBuilder LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText)
        {
            return LabelFor(html, expression, labelText, htmlAttributes: null, metadataProvider: null);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static LabelBuilder LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            return LabelFor(html, expression, labelText: null, htmlAttributes: htmlAttributes, metadataProvider: null);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static LabelBuilder LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            return LabelFor(html, expression, labelText: null, htmlAttributes: htmlAttributes, metadataProvider: null);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static LabelBuilder LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes)
        {
            return LabelFor(html, expression, labelText, htmlAttributes, metadataProvider: null);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static LabelBuilder LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            return LabelFor(html, expression, labelText, htmlAttributes, metadataProvider: null);
        }

        internal static LabelBuilder LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes, ModelMetadataProvider metadataProvider)
        {
            return LabelFor(html,
                            expression,
                            labelText,
                            HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                            metadataProvider);
        }

        internal static LabelBuilder LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes, ModelMetadataProvider metadataProvider)
        {
            return LabelHelper(html,
                               ModelMetadata.FromLambdaExpression(expression, html.ViewData/*, metadataProvider*/),
                               ExpressionHelper.GetExpressionText(expression),
                               labelText,
                               htmlAttributes);
        }

        public static LabelBuilder LabelForModel(this HtmlHelper html)
        {
            return LabelForModel(html, labelText: null);
        }

        public static LabelBuilder LabelForModel(this HtmlHelper html, string labelText)
        {
            return LabelHelper(html, html.ViewData.ModelMetadata, String.Empty, labelText);
        }

        public static LabelBuilder LabelForModel(this HtmlHelper html, object htmlAttributes)
        {
            return LabelHelper(html, html.ViewData.ModelMetadata, String.Empty, labelText: null, htmlAttributes: HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LabelBuilder LabelForModel(this HtmlHelper html, IDictionary<string, object> htmlAttributes)
        {
            return LabelHelper(html, html.ViewData.ModelMetadata, String.Empty, labelText: null, htmlAttributes: htmlAttributes);
        }

        public static LabelBuilder LabelForModel(this HtmlHelper html, string labelText, object htmlAttributes)
        {
            return LabelHelper(html, html.ViewData.ModelMetadata, String.Empty, labelText, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static LabelBuilder LabelForModel(this HtmlHelper html, string labelText, IDictionary<string, object> htmlAttributes)
        {
            return LabelHelper(html, html.ViewData.ModelMetadata, String.Empty, labelText, htmlAttributes);
        }

        internal static LabelBuilder LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, string labelText = null, IDictionary<string, object> htmlAttributes = null)
        {
            string resolvedLabelText = labelText ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            LabelBuilder lb = new LabelBuilder(html.Marq());
            if (String.IsNullOrEmpty(resolvedLabelText))
            {
                return lb;
            }

            lb.For(TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
            lb.TrailingText(resolvedLabelText);
            lb.MergeAttributes(htmlAttributes, replaceExisting: true);
            return lb;
        }
    }
}
