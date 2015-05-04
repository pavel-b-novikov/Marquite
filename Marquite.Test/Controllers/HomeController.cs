using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marquite.CssHoneypot;

namespace Marquite.Test.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}