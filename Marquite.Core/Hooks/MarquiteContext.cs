using System;
using System.IO;
using System.Web.Mvc;

namespace Marquite.Core.Hooks
{
    public class MarquiteHookContext : IDisposable
    {
        private bool _disposed;
        private readonly TextWriter _writerPersist;
        private readonly ViewContext _viewContext;
        private readonly PopupContext _thisPopupContext;
        protected MarquiteViewPageContext MarquiteViewPageContext
        {
            get { return _viewContext.MarquiteContext(); }
        }

        public MarquiteHookContext(ViewContext viewContext, string id, string title, int width, bool outOfTop = false)
        {
            _viewContext = viewContext;
            _writerPersist = viewContext.Writer;
            _thisPopupContext = MarquiteViewPageContext.CreateWindow(id, title, outOfTop);
            _thisPopupContext.Width = width;
            viewContext.Writer = _thisPopupContext.Writer;
            WritePopupBegin(_thisPopupContext);
        }

        private void WritePopupBegin(PopupContext popup)
        {
            popup.Writer.Write(@"<div id=""{0}"" class=""b-popup"" style=""display:none;""><div class=""i-valign i-dib"">", popup.Id);
            if (popup.Width == 0)
                popup.Writer.Write(@"<div class=""b-popup__center i-dib popup-content"">");
            else
                popup.Writer.Write(@"<div class=""b-popup__center i-dib popup-content"" style=""width:{0}px"">", popup.Width);

            if (!string.IsNullOrEmpty(popup.Title))
            {
                popup.Writer.Write("<h2 class=\"b-popup__title\">{0}</h2>", popup.Title);
            }
        }

        private void WritePopupEnd(PopupContext popup)
        {
            popup.Writer.Write("<div class=\"b-popup__close _popupClose\" onclick=\"$.Cordage.Popups.close('{0}');\" id=\"btn{0}Close\"></div></div></div>", popup.Id);
            popup.Writer.WriteLine("<div class=\"i-valign-helper i-dib\"></div></div>");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                WritePopupEnd(_thisPopupContext);
                MarquiteViewPageContext.FinishPopup();
                _viewContext.Writer = _writerPersist;
            }
        }
    }
}
