using System.Collections.Generic;

namespace Marquite.Core.Hooks
{
    public class MarquiteViewPageContext
    {
        public List<PopupContext> Popups { get; private set; }

        public PopupContext CurrentPopup { get; private set; }

        public MarquiteViewPageContext()
        {
            Popups = new List<PopupContext>();
        }

        public PopupContext CreateWindow(string id, string title, bool outOfTop = false)
        {
            PopupContext pc = new PopupContext(id, title);
            pc.OutOfTop = outOfTop;
            Popups.Add(pc);
            CurrentPopup = pc;
            return pc;
        }

        public void FinishPopup()
        {
            CurrentPopup = null;
        }
    }
}