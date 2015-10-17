﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;

namespace Marquite.Core.Html
{
    public static class ValidationExtensions
    {
        #region Helper methods
        private static string _resourceClassKey;

        public static string ResourceClassKey
        {
            get { return _resourceClassKey ?? String.Empty; }
            set { _resourceClassKey = value; }
        }

        private static FieldValidationMetadata ApplyFieldValidationMetadata(HtmlHelper htmlHelper,
            ModelMetadata modelMetadata, string modelName)
        {
            FormContext formContext = htmlHelper.ViewContext.FormContext;
            FieldValidationMetadata fieldMetadata = formContext.GetValidationMetadataForField(modelName, true
                /* createIfNotFound */);

            // write rules to context object
            IEnumerable<ModelValidator> validators = ModelValidatorProviders.Providers.GetValidators(modelMetadata,
                htmlHelper.ViewContext);
            foreach (ModelClientValidationRule rule in validators.SelectMany(v => v.GetClientValidationRules()))
            {
                fieldMetadata.ValidationRules.Add(rule);
            }

            return fieldMetadata;
        }

        private static string GetInvalidPropertyValueResource(HttpContextBase httpContext)
        {
            string resourceValue = null;
            if (!String.IsNullOrEmpty(ResourceClassKey) && (httpContext != null))
            {
                // If the user specified a ResourceClassKey try to load the resource they specified.
                // If the class key is invalid, an exception will be thrown.
                // If the class key is valid but the resource is not found, it returns null, in which
                // case it will fall back to the MVC default error message.
                resourceValue =
                    httpContext.GetGlobalResourceObject(ResourceClassKey, "InvalidPropertyValue",
                        CultureInfo.CurrentUICulture) as string;
            }
            return resourceValue ?? "ValueNotValidForProperty";
        }

        private static string GetUserErrorMessageOrDefault(HttpContextBase httpContext, ModelError error,
            ModelState modelState)
        {
            if (!String.IsNullOrEmpty(error.ErrorMessage))
            {
                return error.ErrorMessage;
            }
            if (modelState == null)
            {
                return null;
            }

            string attemptedValue = (modelState.Value != null) ? modelState.Value.AttemptedValue : null;
            return String.Format(CultureInfo.CurrentCulture, GetInvalidPropertyValueResource(httpContext),
                attemptedValue);
        }
        #endregion

        // Validate

        public static void Validate(this HtmlHelper htmlHelper, string modelName)
        {
            if (modelName == null)
            {
                throw new ArgumentNullException("modelName");
            }

            ValidateHelper(htmlHelper,
                ModelMetadata.FromStringExpression(modelName, htmlHelper.ViewContext.ViewData),
                modelName);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static void ValidateFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            ValidateHelper(htmlHelper,
                ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
                ExpressionHelper.GetExpressionText(expression));
        }

        private static void ValidateHelper(HtmlHelper htmlHelper, ModelMetadata modelMetadata, string expression)
        {
            FormContext formContext = htmlHelper.ViewContext.ClientValidationEnabled? htmlHelper.ViewContext.FormContext : null;
            if (formContext == null || htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
            {
                return; // nothing to do
            }

            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            ApplyFieldValidationMetadata(htmlHelper, modelMetadata, modelName);
        }

        // ValidationMessage

        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper, string modelName)
        {
            return ValidationMessage(htmlHelper, modelName, validationMessage: null,
                htmlAttributes: new RouteValueDictionary());
        }

        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper, string modelName,
            object htmlAttributes)
        {
            return ValidationMessage(htmlHelper, modelName, validationMessage: null,
                htmlAttributes: HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Displays a validation message if an error exists for the specified entry in the
        /// <see cref="ModelStateDictionary"/> object.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method operates on.</param>
        /// <param name="modelName">The name of the entry being validated.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element.</param>
        /// <param name="tag">The tag to be set for the wrapping HTML element of the validation message.</param>
        /// <returns>null if the entry is valid and client-side validation is disabled.
        /// Otherwise, a <paramref name="tag"/> element that contains an error message.</returns>
        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper,
            string modelName,
            object htmlAttributes,
            string tag)
        {
            return ValidationMessage(htmlHelper,
                modelName,
                validationMessage: null,
                htmlAttributes: HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                tag: tag);
        }

        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames",
            Justification =
                "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper, string modelName,
            string validationMessage)
        {
            return ValidationMessage(htmlHelper, modelName, validationMessage, new RouteValueDictionary());
        }

        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames",
            Justification =
                "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper, string modelName,
            string validationMessage, object htmlAttributes)
        {
            return ValidationMessage(htmlHelper, modelName, validationMessage,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Displays a validation message if an error exists for the specified entry in the
        /// <see cref="ModelStateDictionary"/> object.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method operates on.</param>
        /// <param name="modelName">The name of the entry being validated.</param>
        /// <param name="validationMessage">The message to display if the specified entry contains an error.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element.</param>
        /// <param name="tag">The tag to be set for the wrapping HTML element of the validation message.</param>
        /// <returns>null if the entry is valid and client-side validation is disabled.
        /// Otherwise, a <paramref name="tag"/> element that contains an error message.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", Justification =
            "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper,
            string modelName,
            string validationMessage,
            object htmlAttributes,
            string tag)
        {
            return ValidationMessage(htmlHelper,
                modelName,
                validationMessage,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                tag);
        }

        /// <summary>
        /// Displays a validation message if an error exists for the specified entry in the
        /// <see cref="ModelStateDictionary"/> object.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method operates on.</param>
        /// <param name="modelName">The name of the entry being validated.</param>
        /// <param name="validationMessage">The message to display if the specified entry contains an error.</param>
        /// <param name="tag">The tag to be set for the wrapping HTML element of the validation message.</param>
        /// <returns>null if the entry is valid and client-side validation is disabled.
        /// Otherwise, a <paramref name="tag"/> element that contains an error message.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", Justification =
            "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper,
            string modelName,
            string validationMessage,
            string tag)
        {
            return ValidationMessage(htmlHelper,
                modelName,
                validationMessage,
                htmlAttributes: new RouteValueDictionary(),
                tag: tag);
        }

        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper, string modelName,
            IDictionary<string, object> htmlAttributes)
        {
            return ValidationMessage(htmlHelper, modelName, validationMessage: null, htmlAttributes: htmlAttributes);
        }

        /// <summary>
        /// Displays a validation message if an error exists for the specified entry in the
        /// <see cref="ModelStateDictionary"/> object.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method operates on.</param>
        /// <param name="modelName">The name of the entry being validated.</param>
        /// <param name="htmlAttributes">An <see cref="IDictionary{TKey,TValue}"/> that contains the HTML attributes
        /// for the element.</param>
        /// <param name="tag">The tag to be set for the wrapping HTML element of the validation message.</param>
        /// <returns>null if the entry is valid and client-side validation is disabled.
        /// Otherwise, a <paramref name="tag"/> element that contains an error message.</returns>
        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper,
            string modelName,
            IDictionary<string, object> htmlAttributes,
            string tag)
        {
            return ValidationMessage(htmlHelper,
                modelName,
                validationMessage: null,
                htmlAttributes: htmlAttributes,
                tag: tag);
        }

        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames",
            Justification =
                "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper, string modelName,
            string validationMessage, IDictionary<string, object> htmlAttributes)
        {
            return ValidationMessage(htmlHelper, modelName, validationMessage, htmlAttributes, tag: null);
        }

        /// <summary>
        /// Displays a validation message if an error exists for the specified entry in the
        /// <see cref="ModelStateDictionary"/> object.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method operates on.</param>
        /// <param name="modelName">The name of the model object being validated.</param>
        /// <param name="validationMessage">The message to display if the specified entry contains an error.</param>
        /// <param name="htmlAttributes">An <see cref="IDictionary{TKey,TValue}"/> that contains the HTML attributes
        /// for the element.</param>
        /// <param name="tag">The tag to be set for the wrapping HTML element of the validation message.</param>
        /// <returns>null if the model object is valid and client-side validation is disabled.
        /// Otherwise, a <paramref name="tag"/> element that contains an error message.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", Justification =
            "'validationMessage' refers to the message that will be rendered by the ValidationMessage helper.")]
        public static SimpleHtmlBuilder ValidationMessage(this HtmlHelper htmlHelper,
            string modelName,
            string validationMessage,
            IDictionary<string, object> htmlAttributes,
            string tag)
        {
            if (modelName == null)
            {
                throw new ArgumentNullException("modelName");
            }

            return ValidationMessageHelper(htmlHelper,
                ModelMetadata.FromStringExpression(modelName, htmlHelper.ViewContext.ViewData),
                modelName,
                validationMessage,
                htmlAttributes,
                tag);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static SimpleHtmlBuilder ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return ValidationMessageFor(htmlHelper, expression, validationMessage: null,
                htmlAttributes: new RouteValueDictionary());
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static SimpleHtmlBuilder ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string validationMessage)
        {
            return ValidationMessageFor(htmlHelper, expression, validationMessage, new RouteValueDictionary());
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static SimpleHtmlBuilder ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string validationMessage, object htmlAttributes)
        {
            return ValidationMessageFor(htmlHelper, expression, validationMessage,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static SimpleHtmlBuilder ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, string validationMessage,
            IDictionary<string, object> htmlAttributes)
        {
            return ValidationMessageFor(htmlHelper,
                expression,
                validationMessage,
                htmlAttributes,
                tag: null);
        }

        /// <summary>
        /// Returns the HTML markup for a validation-error message for the specified expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method operates on.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.
        /// </param>
        /// <param name="validationMessage">The message to display if a validation error occurs.</param>
        /// <param name="tag">The tag to be set for the wrapping HTML element of the validation message.</param>
        /// <returns>null if the model object is valid and client-side validation is disabled.
        /// Otherwise, a <paramref name="tag"/> element that contains an error message.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification =
            "This is an appropriate nesting of generic types")]
        public static SimpleHtmlBuilder ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string validationMessage,
            string tag)
        {
            return ValidationMessageFor(htmlHelper,
                expression,
                validationMessage,
                htmlAttributes: null,
                tag: tag);
        }

        /// <summary>
        /// Returns the HTML markup for a validation-error message for the specified expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method operates on.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.
        /// </param>
        /// <param name="validationMessage">The message to display if a validation error occurs.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes for the element.</param>
        /// <param name="tag">The tag to be set for the wrapping HTML element of the validation message.</param>
        /// <returns>null if the model object is valid and client-side validation is disabled.
        /// Otherwise, a <paramref name="tag"/> element that contains an error message.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification =
            "This is an appropriate nesting of generic types")]
        public static SimpleHtmlBuilder ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string validationMessage,
            object htmlAttributes,
            string tag)
        {
            return ValidationMessageFor(htmlHelper,
                expression,
                validationMessage,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes),
                tag);
        }

        /// <summary>
        /// Returns the HTML markup for a validation-error message for the specified expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method operates on.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.
        /// </param>
        /// <param name="validationMessage">The message to display if a validation error occurs.</param>
        /// <param name="htmlAttributes">An <see cref="IDictionary{TKey,TValue}"/> that contains the HTML attributes
        /// for the element.</param>
        /// <param name="tag">The tag to be set for the wrapping HTML element of the validation message.</param>
        /// <returns>null if the model object is valid and client-side validation is disabled.
        /// Otherwise, a <paramref name="tag"/> element that contains an error message.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification =
            "This is an appropriate nesting of generic types")]
        public static SimpleHtmlBuilder ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string validationMessage,
            IDictionary<string, object> htmlAttributes,
            string tag)
        {
            return ValidationMessageHelper(htmlHelper,
                ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
                ExpressionHelper.GetExpressionText(expression),
                validationMessage,
                htmlAttributes,
                tag);
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase",
            Justification = "Normalization to lowercase is a common requirement for JavaScript and HTML values")]
        private static SimpleHtmlBuilder ValidationMessageHelper(this HtmlHelper htmlHelper, ModelMetadata modelMetadata,
            string expression, string validationMessage, IDictionary<string, object> htmlAttributes, string tag)
        {
            IMarquite marq = htmlHelper.Marq();
            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            FormContext formContext = htmlHelper.ViewContext.ClientValidationEnabled? htmlHelper.ViewContext.FormContext : null;

            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName) && formContext == null)
            {
                return null;
            }

            ModelState modelState = htmlHelper.ViewData.ModelState[modelName];
            ModelErrorCollection modelErrors = (modelState == null) ? null : modelState.Errors;
            ModelError modelError = (((modelErrors == null) || (modelErrors.Count == 0))
                ? null
                : modelErrors.FirstOrDefault(m => !String.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrors[0]);

            if (modelError == null && formContext == null)
            {
                return null;
            }

            if (String.IsNullOrEmpty(tag))
            {
                tag = htmlHelper.ViewContext.ValidationMessageElement;
            }

            SimpleHtmlBuilder builder = new SimpleHtmlBuilder(marq,tag);
            builder.MergeAttributes(htmlAttributes);
            builder.AddClass((modelError != null)
                ? HtmlHelper.ValidationMessageCssClassName
                : HtmlHelper.ValidationMessageValidCssClassName);

            if (!String.IsNullOrEmpty(validationMessage))
            {
                builder.TrailingText(validationMessage);
            }
            else if (modelError != null)
            {
                builder.TrailingText(GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError,
                    modelState));
            }

            if (formContext != null)
            {
                bool replaceValidationMessageContents = String.IsNullOrEmpty(validationMessage);

                if (htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
                {
                    builder.Data("valmsg-for", modelName);
                    builder.Data("valmsg-replace",
                        replaceValidationMessageContents.ToString().ToLowerInvariant());
                }
                else
                {
                    FieldValidationMetadata fieldMetadata = ApplyFieldValidationMetadata(htmlHelper, modelMetadata,
                        modelName);
                    // rules will already have been written to the metadata object
                    fieldMetadata.ReplaceValidationMessageContents = replaceValidationMessageContents;
                        // only replace contents if no explicit message was specified

                    // client validation always requires an ID
                    if (!string.IsNullOrEmpty(builder.IdVal))
                    {
                        builder.Id(marq.GenerateId(modelName + "_validationMessage"));
                    }
                    
                    fieldMetadata.ValidationMessageId = builder.IdVal;
                }
            }

            return builder;
        }

        // ValidationSummary

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors: false);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors, message: null);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, string message)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors: false, message: message,
                htmlAttributes: (object) null, headingTag: null);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, string message, string headingTag)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors: false, message: message,
                htmlAttributes: (object) null, headingTag: headingTag);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
            string message)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors, message, htmlAttributes: (object) null,
                headingTag: null);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
            string message, string headingTag)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors, message, htmlAttributes: (object) null,
                headingTag: headingTag);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, string message, object htmlAttributes)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors: false, message: message,
                htmlAttributes: HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), headingTag: null);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, string message, object htmlAttributes,
            string headingTag)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors: false, message: message,
                htmlAttributes: HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), headingTag: headingTag);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
            string message, object htmlAttributes)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors, message,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), null);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
            string message, object htmlAttributes, string headingTag)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors, message,
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), headingTag);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, string message,
            IDictionary<string, object> htmlAttributes)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors: false, message: message,
                htmlAttributes: htmlAttributes, headingTag: null);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, string message,
            IDictionary<string, object> htmlAttributes, string headingTag)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors: false, message: message,
                htmlAttributes: htmlAttributes, headingTag: headingTag);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
            string message, IDictionary<string, object> htmlAttributes)
        {
            return ValidationSummary(htmlHelper, excludePropertyErrors, message, htmlAttributes, null);
        }

        public static SimpleHtmlBuilder ValidationSummary(this HtmlHelper htmlHelper, bool excludePropertyErrors,
            string message, IDictionary<string, object> htmlAttributes, string headingTag)
        {
            var marq = htmlHelper.Marq();
            if (htmlHelper == null)
            {
                throw new ArgumentNullException("htmlHelper");
            }

            FormContext formContext = htmlHelper.ViewContext.ClientValidationEnabled? htmlHelper.ViewContext.FormContext : null;
            if (htmlHelper.ViewData.ModelState.IsValid)
            {
                if (formContext == null)
                {
                    // No client side validation
                    return null;
                }
                // TODO: This isn't really about unobtrusive; can we fix up non-unobtrusive to get rid of this, too?
                if (htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled && excludePropertyErrors)
                {
                    // No client-side updates
                    return null;
                }
            }

            SimpleHtmlBuilder messageSpan;
            if (!String.IsNullOrEmpty(message))
            {
                if (String.IsNullOrEmpty(headingTag))
                {
                    headingTag = htmlHelper.ViewContext.ValidationSummaryMessageElement;
                }

                SimpleHtmlBuilder spanTag = new SimpleHtmlBuilder(marq,headingTag);
                spanTag.TrailingText(message);
                messageSpan = spanTag;
            }
            else
            {
                messageSpan = null;
            }

           
            UnorderedListBuilder unorderedList = new UnorderedListBuilder(marq);

            IEnumerable<ModelState> modelStates = GetModelStateList(htmlHelper, excludePropertyErrors);

            foreach (ModelState modelState in modelStates)
            {
                foreach (ModelError modelError in modelState.Errors)
                {
                    string errorText = GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError, null
                        /* modelState */);
                    if (!String.IsNullOrEmpty(errorText))
                    {
                        unorderedList.AddItem(errorText);
                    }
                }
            }

            if (unorderedList.RenderingQueue.Count==0)
            {
                unorderedList.AddItem((new ListItemBuilder(marq)).Css(Css.Display, "none"));
            }

            SimpleHtmlBuilder divBuilder = new SimpleHtmlBuilder(marq,"div");
            divBuilder.MergeAttributes(htmlAttributes);
            divBuilder.AddClass((htmlHelper.ViewData.ModelState.IsValid)
                ? HtmlHelper.ValidationSummaryValidCssClassName
                : HtmlHelper.ValidationSummaryCssClassName);
            divBuilder.TrailingHtml(messageSpan);
            divBuilder.TrailingHtml(unorderedList);
            
            if (formContext != null)
            {
                if (htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
                {
                    if (!excludePropertyErrors)
                    {
                        // Only put errors in the validation summary if they're supposed to be included there
                        divBuilder.Data("valmsg-summary", "true");
                    }
                }
                else
                {
                    // client val summaries need an ID

                    if (!string.IsNullOrEmpty(divBuilder.IdVal))
                    {
                        divBuilder.Id(marq.GenerateId("validationSummary"));
                    }
                    formContext.ValidationSummaryId = divBuilder.IdVal;
                    formContext.ReplaceValidationSummary = !excludePropertyErrors;
                }
            }
            return divBuilder;
        }

        // Returns non-null list of model states, which caller will render in order provided.
        private static IEnumerable<ModelState> GetModelStateList(HtmlHelper htmlHelper, bool excludePropertyErrors)
        {
            if (excludePropertyErrors)
            {
                ModelState ms;
                htmlHelper.ViewData.ModelState.TryGetValue(htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix, out ms);
                if (ms != null)
                {
                    return new[] {ms};
                }

                return new ModelState[0];
            }
            else
            {
                // Sort modelStates to respect the ordering in the metadata.                 
                // ModelState doesn't refer to ModelMetadata, but we can correlate via the property name.
                Dictionary<string, int> ordering = new Dictionary<string, int>();

                var metadata = htmlHelper.ViewData.ModelMetadata;
                if (metadata != null)
                {
                    foreach (ModelMetadata m in metadata.Properties)
                    {
                        ordering[m.PropertyName] = m.Order;
                    }
                }

                return from kv in htmlHelper.ViewData.ModelState
                    let name = kv.Key
                    orderby ordering.GetOrDefault(name, ModelMetadata.DefaultOrder)
                    select kv.Value;
            }
        }
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue @default)
        {
            TValue value;
            if (dict.TryGetValue(key, out value))
            {
                return value;
            }
            return @default;
        }
    }
}
