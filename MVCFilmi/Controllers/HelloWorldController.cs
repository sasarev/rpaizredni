using System.Web.Mvc;

namespace MVCFilmi.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pozdrav(string ime, int numTimes = 1)
        {

            ViewBag.sporocilo = $"Pozdravljen {ime}: kolikokrat {numTimes}";
            ViewBag.numTimes = numTimes; 

            return View();
        }
    }
}