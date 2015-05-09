using System.Web.Mvc;

namespace Marquite.Core
{
    public class Marquite //todo inherit marquite object
    {
        private const string MarquiteId = "__Marquite";

        public static Marquite Instance(HtmlHelper h)
        {
            return GetOrCreateMain(h);
        }

        public static Marquite Instance<TModel>(HtmlHelper<TModel> h)
        {
            return GetOrCreateMain(h);
        }

        public static TMarquite Instance<TMarquite>(HtmlHelper h)
            where TMarquite : Marquite,new()
        {
            return GetOrCreate<TMarquite>(h);
        }

        public static TMarquite Instance<TModel, TMarquite>(HtmlHelper<TModel> h)
            where TMarquite : Marquite,new()
        {
            return GetOrCreate<TMarquite>(h);
        }

        private static Marquite GetOrCreateMain(HtmlHelper h,string typename = null)
        {
            var m = h.ViewContext.TempData[MarquiteId];
            if (m == null)
            {
                m = new Marquite(h.ViewContext,h.ViewData);
                h.ViewContext.TempData[MarquiteId] = m;
            }
            return (Marquite) m;
        }

        private static TMarquite GetOrCreate<TMarquite>(HtmlHelper h)
            where TMarquite : Marquite, new()
        {
            var key = MarquiteId + typeof(TMarquite).FullName;

            var m = h.ViewContext.TempData[key];
            if (m == null)
            {
                var n = new TMarquite
                {
                    ViewContext = h.ViewContext,
                    ViewData = h.ViewData
                };
                m = n;
                h.ViewContext.TempData[MarquiteId] = m;
            }
            return (TMarquite)m;
        }

        public Marquite(ViewContext viewContext, ViewDataDictionary viewData)
        {
            ViewContext = viewContext;
            ViewData = viewData;
            InitDefaultCssStyles();
        }

        protected Marquite() { InitDefaultCssStyles(); }

        public ViewContext ViewContext { get; private set; }

        public ViewDataDictionary ViewData { get; private set; }

        public string ValidationInputCssClassName { get; private set; }

        public string ValidationInputValidCssClassName { get; private set; }

        public string ValidationMessageCssClassName { get; private set; }

        public string ValidationMessageValidCssClassName { get; private set; }

        public string ValidationSummaryCssClassName { get; private set; }

        public string ValidationSummaryValidCssClassName { get; private set; }

        private void InitDefaultCssStyles()
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
