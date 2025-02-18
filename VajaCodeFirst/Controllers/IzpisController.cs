using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VajaCodeFirst.Data;
using VajaCodeFirst.Models;

namespace VajaCodeFirst.Controllers
{
    public class IzpisController : Controller
    {
        // GET: Izpis
        public ActionResult Index(int id)
        {
            VajaCodeFirstContext vajaCodeFirstContext = new VajaCodeFirstContext();

            var izpiti = vajaCodeFirstContext.Izpits
                
                .Where(s => s.StudentID == id);

            return View(izpiti);
        }
    }
}