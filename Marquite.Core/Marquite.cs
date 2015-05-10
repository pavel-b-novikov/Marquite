using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Marquite.Core.Rendering;

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
                var marq = new Marquite(h) {IsGlobal = true};
                marq.AddThis(h);
                h.ViewContext.TempData[MarquiteId] = marq;
                m = marq;
            }
            else
            {
                Marquite marq = (Marquite) m;
                m = marq.LookupOrCreate<Marquite>(h);
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
                    ViewData = h.ViewData,
                    IsGlobal = true
                };
                n.AddThis(h);
                m = n;
                h.ViewContext.TempData[MarquiteId] = m;
            }
            else
            {
                Marquite marq = (Marquite)m;
                m = marq.LookupOrCreate<TMarquite>(h);
            }
            return (TMarquite)m;
        }

        public Marquite(HtmlHelper h)
        {
            var vp = (WebViewPage) h.ViewDataContainer;

            ViewContext = h.ViewContext;
            ViewData = h.ViewData;
            _outputStack = vp.OutputStack;
            InitDefaultCssStyles();
        }

        public Marquite() { InitDefaultCssStyles(); }

        public ViewContext ViewContext { get; private set; }

        public ViewDataDictionary ViewData { get; private set; }

        private Stack<TextWriter> _outputStack;

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

        private int _formsCount = 0;
        public string GenerateNewFormId()
        {
            _formsCount++;
            return String.Format("form{0}", _formsCount);
        }

        #region Global cache and context nesting

        public TextWriter GetTopmostWriter()
        {
            return _outputStack.Peek();
        }

        public Marquite Global { get; private set; }

        public bool IsGlobal
        {
            get { return _isGlobal; }
            private set
            {
                _isGlobal = value;
                if (value)
                {
                    _globalCache = new Dictionary<IViewDataContainer, Marquite>();
                    _scaffoldedCache = new SortedDictionary<string, List<IRenderingClient>>(StringComparer.OrdinalIgnoreCase);
                    Global = this;
                }
            }
        }

        private bool _isGlobal;
        private Dictionary<IViewDataContainer, Marquite> _globalCache;

        private void AddThis(HtmlHelper h)
        {
            _globalCache[h.ViewDataContainer] = this;
        }

        private T LookupOrCreate<T>(HtmlHelper h) where T: Marquite,new()
        {
            if (_globalCache.ContainsKey(h.ViewDataContainer)) return (T) _globalCache[h.ViewDataContainer];
            var vp = (WebViewPage) h.ViewDataContainer;
            var tlk = new T();
            tlk.ViewContext = h.ViewContext;
            tlk.ViewData = h.ViewData;
            tlk.IsGlobal = false;
            tlk.Global = this;
            tlk._outputStack = vp.OutputStack;
            _globalCache[vp] = tlk;
            return tlk;
        }
        #endregion

        #region Scaffoder Queue
        private SortedDictionary<string,List<IRenderingClient>> _scaffoldedCache;

        public void Scaffold(string key, IRenderingClient client)
        {
            if (!IsGlobal) throw new Exception("Scaffolding works only on global context. Use .Global.Scaffold(...)");
            List<IRenderingClient> rcList;
            bool exists = _scaffoldedCache.TryGetValue(key, out rcList);
            if (!exists)
            {
                rcList = new List<IRenderingClient>(50);
                _scaffoldedCache[key] = rcList;
            }
            rcList.Add(client);
        }

        public void RenderScaffoldedQueue(string key, TextWriter tw)
        {
            if (!IsGlobal) throw new Exception("Scaffolding works only on global context. Use .Global.Scaffold(...)");
            List<IRenderingClient> rcList;
            bool exists = _scaffoldedCache.TryGetValue(key, out rcList);
            if (!exists) return;
            var a = rcList.ToArray();
            a.ForEach(tw.RenderClient);
        }
        #endregion
    }
}
