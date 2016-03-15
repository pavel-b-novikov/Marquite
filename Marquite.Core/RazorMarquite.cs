using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public class RazorMarquite : IMarquite
    {
        public RazorMarquite(HtmlHelper h)
            : this((WebViewPage)h.ViewDataContainer, h.ViewContext, h.ViewData)
        {

        }

        public RazorMarquite(WebViewPage page, ViewContext vc, ViewDataDictionary vd)
        {
            var vp = page;
            ViewContext = vc;
            ViewData = vd;
            OutputStack = vp.OutputStack;
            EventsManager = new MarquiteEventsManager();
            ScopeManager = new ScopeManager(this);
        }

        public ViewContext ViewContext { get; internal set; }

        public ViewDataDictionary ViewData { get; internal set; }

        internal Stack<TextWriter> OutputStack;

        private const string ElementsCounterKey = "MerquiteElementsCounter";
        private const string FormsCounterKey = "MerquiteFormsCounter";

        private int MarquiteElements
        {
            get
            {
                if (!ViewContext.TempData.ContainsKey(ElementsCounterKey))
                {
                    ViewContext.TempData[ElementsCounterKey] = 0;
                    return 0;
                }
                return (int) ViewContext.TempData[ElementsCounterKey];
            }
            set { ViewContext.TempData[ElementsCounterKey] = value; }
        }

        private int FormsCount
        {
            get
            {
                if (!ViewContext.TempData.ContainsKey(FormsCounterKey))
                {
                    ViewContext.TempData[FormsCounterKey] = 0;
                    return 0;
                }
                return (int)ViewContext.TempData[FormsCounterKey];
            }
            set { ViewContext.TempData[FormsCounterKey] = value; }
        }

        public string GenerateNewId()
        {
            return String.Format("__el__{0}", ++MarquiteElements);
        }

        public string GenerateNewFormId()
        {
            if (!_isGlobal) return Global.GenerateNewFormId();
            FormsCount++;
            return String.Format("__form{0}", FormsCount);
        }

        #region Global cache and context nesting

        public TextWriter GetTopmostWriter()
        {
            return OutputStack.Peek();
        }

        public IMarquite Global { get; internal set; }

        public bool IsGlobal
        {
            get { return _isGlobal; }
            internal set
            {
                _isGlobal = value;
                if (value)
                {
                    //_scaffoldedCache = new SortedDictionary<string, List<IRenderingClient>>(StringComparer.OrdinalIgnoreCase);

                    Global = this;
                }

                _pluginsCache = new Dictionary<Type, IMarquitePlugin>();
            }
        }

        private bool _isGlobal;

        #endregion

        #region Scaffoder Queue
        //private SortedDictionary<string, List<IRenderingClient>> _scaffoldedCache;

        //public void Scaffold(string key, IRenderingClient client)
        //{
        //    if (!_isGlobal) Global.Scaffold(key, client);
        //    List<IRenderingClient> rcList;
        //    bool exists = _scaffoldedCache.TryGetValue(key, out rcList);
        //    if (!exists)
        //    {
        //        rcList = new List<IRenderingClient>(50);
        //        _scaffoldedCache[key] = rcList;
        //    }
        //    rcList.Add(client);
        //}

        //public void RenderScaffoldedQueue(string key, TextWriter tw)
        //{
        //    if (!_isGlobal) Global.RenderScaffoldedQueue(key, tw);
        //    List<IRenderingClient> rcList;
        //    bool exists = _scaffoldedCache.TryGetValue(key, out rcList);
        //    if (!exists) return;
        //    var a = rcList.ToArray();
        //    a.ForEach(tw.RenderClient);
        //}
        #endregion

        #region Plugins

        private Dictionary<Type, IMarquitePlugin> _pluginsCache;

        public T ResolvePlugin<T>() where T : IMarquitePlugin, new()
        {
            if (_pluginsCache.ContainsKey(typeof(T))) return (T)_pluginsCache[typeof(T)];
            T pluginInstance = new T();
            pluginInstance.Marquite = this;
            _pluginsCache[typeof(T)] = pluginInstance;
            return pluginInstance;
        }

        #endregion

        public MarquiteEventsManager EventsManager { get; private set; }
        public ScopeManager ScopeManager { get; private set; }

        public string GenerateId(string name)
        {
            return TagBuilder.CreateSanitizedId(name, HtmlHelper.IdAttributeDotReplacement);
        }
    }
}
