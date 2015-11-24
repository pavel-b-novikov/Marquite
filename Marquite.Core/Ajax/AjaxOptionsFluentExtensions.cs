using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Ajax;

namespace Marquite.Core.Ajax
{
    public static class AjaxOptionsFluentExtensions
    {
        public static AjaxOptions AllowCache(this AjaxOptions options,bool allow = false)
        {
            options.AllowCache = allow;
            return options;
        }

        public static AjaxOptions Confirm(this AjaxOptions options, string confirmationFn)
        {
            options.Confirm = confirmationFn;
            return options;
        }

        public static AjaxOptions HttpMethod(this AjaxOptions options, string method)
        {
            options.HttpMethod = method;
            return options;
        }

        public static AjaxOptions InsertionMode(this AjaxOptions options, InsertionMode mode = System.Web.Mvc.Ajax.InsertionMode.Replace)
        {
            options.InsertionMode = mode;
            return options;
        }

        public static AjaxOptions LoadingElementDuration(this AjaxOptions options, int duration)
        {
            options.LoadingElementDuration = duration;
            return options;
        }

        public static AjaxOptions LoadingElementId(this AjaxOptions options, string elementId)
        {
            options.LoadingElementId = elementId;
            return options;
        }
        public static AjaxOptions OnBegin(this AjaxOptions options, string onBegin)
        {
            options.OnBegin = onBegin;
            return options;
        }

        public static AjaxOptions OnComplete(this AjaxOptions options, string onComplete)
        {
            options.OnComplete = onComplete;
            return options;
        }

        public static AjaxOptions OnFailure(this AjaxOptions options, string onFailure)
        {
            options.OnFailure = onFailure;
            return options;
        }

        public static AjaxOptions OnSuccess(this AjaxOptions options, string onSuccess)
        {
            options.OnSuccess = onSuccess;
            return options;
        }

        public static AjaxOptions UpdateTargetId(this AjaxOptions options, string updateTargetId)
        {
            options.UpdateTargetId = updateTargetId;
            return options;
        }

        public static AjaxOptions Url(this AjaxOptions options, string url)
        {
            options.Url = url;
            return options;
        }
    }
}
