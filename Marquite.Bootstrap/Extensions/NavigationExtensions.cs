using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Bootstrap.Elements;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;
using Marquite.Core.Rendering;

namespace Marquite.Bootstrap.Extensions
{
    /// <summary>
    /// Extensions for Bootstrap navigation elements
    /// </summary>
    public static class NavigationExtensions
    {
        public static NavBuilder Navigation(this BootstrapPlugin bs)
        {
            return new NavBuilder(bs.Marquite);
        }

        public static NavBuilder Navigation(this BootstrapPlugin bs, params string[] links)
        {
            var b = new NavBuilder(bs.Marquite);
            foreach (var link in links)
            {
                b.Item(link);
            }
            return b;
        }

        public static NavBuilder Navigation(this BootstrapPlugin bs, params LinkBuilder[] links)
        {
            var b = new NavBuilder(bs.Marquite);
            foreach (var link in links)
            {
                b.Item(link);
            }
            return b;
        }

        /// <summary>
        /// Constructs an empty Bootstrap navbar
        /// <seealso cref="http://getbootstrap.com/components/#navbar"/>
        /// </summary>
        /// <param name="bs">Bootstrap plugin</param>
        /// <returns>Navbar builder</returns>
        public static NavbarBuilder Navbar(this BootstrapPlugin bs)
        {
            return new NavbarBuilder(bs.Marquite);
        }

        /// <summary>
        /// Constructs an empty Bootstrap navbar
        /// <seealso cref="http://getbootstrap.com/components/#navbar"/>
        /// </summary>
        /// <param name="bs">Bootstrap plugin</param>
        /// <param name="brandName">Brand name (big label that will be shown at the left) (nav-brand)</param>
        /// <param name="homeUrl">Url of brand link</param>
        /// <returns>Navbar builder</returns>
        public static NavbarBuilder Navbar(this BootstrapPlugin bs, string brandName, string homeUrl)
        {
            return new NavbarBuilder(bs.Marquite).Brand(brandName, homeUrl);
        }

        public static NavbarBuilder Navbar(this BootstrapPlugin bs, params LinkBuilder[] links)
        {
            var b =  new NavbarBuilder(bs.Marquite);
            if (links.Length > 0)
            {
                var nav = bs.Navigation(links);
                b.AddNavigation(nav);
            }
            return b;
        }

        public static NavbarBuilder Navbar(this BootstrapPlugin bs, string brandName, string homeUrl, params LinkBuilder[] links)
        {
            var b = bs.Navbar(brandName,homeUrl);
            if (links.Length > 0)
            {
                var nav = bs.Navigation(links);
                b.AddNavigation(nav);
            }
            return b;
        }


        public static NavbarBuilder Navbar(this BootstrapPlugin bs, string brandName, string homeUrl, params IHtmlBuilder[] elements)
        {
            var b = bs.Navbar(brandName, homeUrl);
            if (elements.Length > 0)
            {
                foreach (var renderingClient in elements)
                {
                    if (renderingClient is BootstrapButtonBuilder)
                    {
                        b.AddButton((BootstrapButtonBuilder) renderingClient);
                    }
                    else if (renderingClient is FormBuilder)
                    {
                        b.AddForm((FormBuilder) renderingClient);
                    }
                    else if (renderingClient is NavBuilder)
                    {
                        b.AddNavigation((NavBuilder) renderingClient);
                    }
                    else
                    {
                        b.AddItem(renderingClient);
                    }
                }
            }
            return b;
        }
    }
}
