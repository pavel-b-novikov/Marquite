using Marquite.Core.Rendering;

namespace Marquite.Core
{
    public static class RenderingQueueExtensions
    {
        #region Prepend
        public static IRenderingQueue Prepend(this IRenderingQueue b, string html) 
        {
            b.Lead(html);
            return b;
        }

        public static IRenderingQueue PrependText(this IRenderingQueue b, string text) 
        {
            b.Lead(text, encode: true);
            return b;
        }

        public static IRenderingQueue Prepend(this IRenderingQueue b, IRenderingClient content) 
        {
            b.Lead(content);
            return b;
        }
        public static IRenderingQueue Prepend(this IRenderingQueue b, string html, bool condition) 
        {
            if (condition) b.Prepend(html);
            return b;
        }

        public static IRenderingQueue PrependText(this IRenderingQueue b, string text, bool condition) 
        {
            if (condition) b.PrependText(text);
            return b;
        }

        public static IRenderingQueue Prepend(this IRenderingQueue b, IRenderingClient content, bool condition) 
        {
            if (condition) b.Prepend(content);
            return b;
        }
        #endregion

        #region Append
        public static IRenderingQueue Append(this IRenderingQueue b, string html) 
        {
            b.Trail(html);
            return b;
        }

        public static IRenderingQueue AppendText(this IRenderingQueue b, string text) 
        {
            b.Trail(text,encode:true);
            return b;
        }

        public static IRenderingQueue Append(this IRenderingQueue b, IRenderingClient content) 
        {
            b.Trail(content);
            return b;
        }

        public static IRenderingQueue Append(this IRenderingQueue b, string html, bool condition) 
        {
            if (condition) b.Append(html);
            return b;
        }

        public static IRenderingQueue AppendText(this IRenderingQueue b, string text, bool condition) 
        {
            if (condition) b.AppendText(text);
            return b;
        }

        public static IRenderingQueue Append(this IRenderingQueue b, IRenderingClient content, bool condition) 
        {
            if (condition) b.Append(content);
            return b;
        }
        #endregion
    }
}
