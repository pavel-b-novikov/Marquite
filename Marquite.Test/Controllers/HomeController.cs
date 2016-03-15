using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marquite.Angular;
using Marquite.Bootstrap.Elements;
using Marquite.Bootstrap.Extensions;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.CssHoneypot;
using Marquite.Test.Models;

namespace Marquite.Test.Controllers
{
    public class HomeController : Controller
    {
        private interface ISomeViewModel
        {
            void Click(IEvent evt);
        }
        public ActionResult Index()
        {
            ISelectorBuilder selector = new StringSelectorBuilder();
            selector = selector.Tag("ul")
                               .Child()
                               .Tag("li")
                               .WithClass("active")
                               .Even()
                               .Gt(10)
                               .First()
                               .WhereAttrContainsPrefix("id","ourbuttons-")
                               .Child()
                               ;

            
            var button = selector.Child().Tag("button");

            return View();
        }

        public ActionResult Grids()
        {
            return View();
        }

        public ActionResult Forms()
        {
            return View(new SampleFormModel());
        }
    }
}