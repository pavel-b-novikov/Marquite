﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marquite.Core
{
    internal class MarquiteInstanceManager
    {
        private MarquiteInstanceManager()
        {
        }

        private const string MarquiteId = "__MarquiteInstanceManager";

        private Marquite _global;

        private readonly Dictionary<IViewDataContainer, Marquite> _globalCache = new Dictionary<IViewDataContainer, Marquite>();

        public Marquite GetInstance(HtmlHelper h)
        {
            var vdc = h.ViewDataContainer;
            if (_global == null)
            {
                _global = new Marquite(h);
                _global.IsGlobal = true;
                _globalCache[vdc] = _global;
                return _global;
            }

            if (!_globalCache.ContainsKey(vdc))
            {
                var vp = (WebViewPage)vdc;
                var tlk = new Marquite(h);
                tlk.IsGlobal = false;
                tlk.Global = _global;
                _globalCache[vp] = tlk;
                return tlk;
            }
            return _globalCache[vdc];
        }

        public static MarquiteInstanceManager GetInstanceManager(HtmlHelper h)
        {
            var td = h.ViewContext.TempData;
            if (td.ContainsKey(MarquiteId))
            {
                return (MarquiteInstanceManager) td[MarquiteId];
            }
            var im = new MarquiteInstanceManager();
            td[MarquiteId] = im;
            return im;
        }
    }
}