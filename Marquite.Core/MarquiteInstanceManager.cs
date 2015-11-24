using System;
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

        private RazorMarquite _global;

        private readonly Dictionary<IViewDataContainer, RazorMarquite> _globalCache = new Dictionary<IViewDataContainer, RazorMarquite>();

        public RazorMarquite GetInstance(HtmlHelper h)
        {
            return GetInstance((WebViewPage) h.ViewDataContainer,h.ViewContext,h.ViewData);
        }

        public RazorMarquite GetInstance(WebViewPage page, ViewContext vc, ViewDataDictionary vd)
        {
            if (_global == null)
            {
                _global = new RazorMarquite(page,vc,vd);
                _global.IsGlobal = true;
                _globalCache[page] = _global;
                return _global;
            }

            if (!_globalCache.ContainsKey(page))
            {
                var vp = (WebViewPage)page;
                var tlk = new RazorMarquite(page, vc, vd);
                tlk.IsGlobal = false;
                tlk.Global = _global;
                _globalCache[vp] = tlk;
                return tlk;
            }
            return _globalCache[page];
        }

        public static MarquiteInstanceManager GetInstanceManager(HtmlHelper h)
        {
            var td = h.ViewContext.TempData;
            return GetInstanceManager(td);
        }

        public static MarquiteInstanceManager GetInstanceManager(TempDataDictionary td)
        {
            if (td.ContainsKey(MarquiteId))
            {
                return (MarquiteInstanceManager)td[MarquiteId];
            }
            var im = new MarquiteInstanceManager();
            td[MarquiteId] = im;
            return im;
        }
    }
}
