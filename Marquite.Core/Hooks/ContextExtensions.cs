using System.Web.Mvc;

namespace Marquite.Core.Hooks
{
    public static class ContextExtensions
    {
        private const string MarquiteContextId = "___hithere___";

        public static MarquiteViewPageContext MarquiteContext(this HtmlHelper h)
        {
            return MarquiteContext(h.ViewContext);
        }

        public static MarquiteViewPageContext MarquiteContext(this ViewContext h)
        {
            if (!h.TempData.ContainsKey(MarquiteContextId))
            {
                h.TempData[MarquiteContextId] = new MarquiteViewPageContext();
            }
            return (MarquiteViewPageContext)h.TempData[MarquiteContextId];
        }
    }
}