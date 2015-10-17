using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap.Extensions
{
    public static class ButtonExtensions
    {
        /// <summary>
        /// Makes a bootstrap button with <button/> tag
        /// </summary>
        /// <param name="b">Plugin</param>
        /// <param name="text">Button text (HTML allowed)</param>
        /// <returns>Builde</returns>
        public static BootstrapButtonBuilder Button(this BootstrapPlugin b, string text = null)
        {
            return new BootstrapButtonBuilder(b.Marquite, "button").Content(text);
        }

        /// <summary>
        /// Makes a bootstrap button with <input type="button"/> tag
        /// </summary>
        /// <param name="b">Plugin</param>
        /// <param name="text">Button text (HTML allowed)</param>
        /// <returns>Builde</returns>
        public static BootstrapButtonBuilder InputButton(this BootstrapPlugin b, string text = null)
        {
            return new BootstrapButtonBuilder(b.Marquite, "input").Attr("type", "button").Content(text);
        }

        /// <summary>
        /// Makes a bootstrap button with <input type="submit"/> tag
        /// </summary>
        /// <param name="b">Plugin</param>
        /// <param name="text">Button text (HTML allowed)</param>
        /// <returns>Builde</returns>
        public static BootstrapButtonBuilder SubmitButton(this BootstrapPlugin b, string text = null)
        {
            return new BootstrapButtonBuilder(b.Marquite, "input").Attr("type", "submit").Content(text);
        }

        /// <summary>
        /// Makes a bootstrap button with <a/> tag
        /// </summary>
        /// <param name="b">Plugin</param>
        /// <param name="text">Button text (HTML allowed)</param>
        /// <returns>Builde</returns>
        public static BootstrapButtonBuilder LinkButton(this BootstrapPlugin b, string text = null)
        {
            return new BootstrapButtonBuilder(b.Marquite, "a").Content(text);
        }
    }
}
