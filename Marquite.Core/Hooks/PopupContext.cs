using System.Text;

namespace Marquite.Core.Hooks
{
    public class PopupContext
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Width { get; set; }
        public string Html { get { return _html.ToString(); } }
        public bool OutOfTop { get; set; }
        public HookedStringWriter Writer { get; private set; }
        public string ClassOverride { get; set; }
        private StringBuilder _html;

        public PopupContext(string id, string title)
        {
            Id = id;
            Title = title;
            _html = new StringBuilder();
            Writer = new HookedStringWriter(_html);
        }
    }
}