using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trgovina.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Admin()
        {
            string apiUrl = Url.HttpRouteUrl("DefaultApi", new { Controller = "Admin" });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUrl).AbsoluteUri.ToString();
            return View();
        }

        public ActionResult Index() { return View();  }

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