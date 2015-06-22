using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public class Marquite
    {
        public Marquite(HtmlHelper h)
        {
            var vp = (WebViewPage)h.ViewDataContainer;
            ViewContext = h.ViewContext;
            ViewData = h.ViewData;
            OutputStack = vp.OutputStack;
            InitDefaultCssStyles();
            EventsManager = new MarquiteEventsManager();
        }

        public ViewContext ViewContext { get; internal set; }

        public ViewDataDictionary ViewData { get; internal set; }

        internal Stack<TextWriter> OutputStack;

        #region CSS
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
        #endregion

        private int _formsCount = 0;
        private int _marquiteElements = 0;

        public string GenerateNewId()
        {
            return String.Format("__marquite{0}", ++_marquiteElements);
        }

        public string GenerateNewFormId()
        {
            if (!_isGlobal) return Global.GenerateNewFormId();
            _formsCount++;
            return String.Format("form{0}", _formsCount);
        }

        #region Global cache and context nesting

        public TextWriter GetTopmostWriter()
        {
            return OutputStack.Peek();
        }

        public Marquite Global { get; internal set; }

        public bool IsGlobal
        {
            get { return _isGlobal; }
            internal set
            {
                _isGlobal = value;
                if (value)
                {
                    _scaffoldedCache = new SortedDictionary<string, List<IRenderingClient>>(StringComparer.OrdinalIgnoreCase);
                    _pluginsCache = new Dictionary<Type, IMarquitePlugin>();
                    Global = this;
                }
            }
        }

        private bool _isGlobal;

        #endregion

        #region Scaffoder Queue
        private SortedDictionary<string, List<IRenderingClient>> _scaffoldedCache;

        public void Scaffold(string key, IRenderingClient client)
        {
            if (!_isGlobal) Global.Scaffold(key, client);
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
            if (!_isGlobal) Global.RenderScaffoldedQueue(key, tw);
            List<IRenderingClient> rcList;
            bool exists = _scaffoldedCache.TryGetValue(key, out rcList);
            if (!exists) return;
            var a = rcList.ToArray();
            a.ForEach(tw.RenderClient);
        }
        #endregion

        #region Plugins

        private Dictionary<Type, IMarquitePlugin> _pluginsCache;

        public T ResolvePlugin<T>() where T : IMarquitePlugin, new()
        {
            if (!_isGlobal) return Global.ResolvePlugin<T>();
            if (_pluginsCache.ContainsKey(typeof(T))) return (T)_pluginsCache[typeof(T)];
            T pluginInstance = new T();
            pluginInstance.Marquite = this;
            _pluginsCache[typeof(T)] = pluginInstance;
            return pluginInstance;
        }

        #endregion

        internal MarquiteEventsManager EventsManager;

        public string GenerateId(string name)
        {
            return TagBuilder.CreateSanitizedId(name, HtmlHelper.IdAttributeDotReplacement);
        }
    }
}
