using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VajaCodeFirst.Data;
using VajaCodeFirst.Models;

namespace VajaCodeFirst.Controllers
{
    public class IzpitiController : Controller
    {
        private VajaCodeFirstContext db = new VajaCodeFirstContext();

        // GET: Izpiti
        public ActionResult Index()
        {
            var izpits = db.Izpits.Include(i => i.Predmet).Include(i => i.Student);
            return View(izpits.ToList());
        }

        // GET: Izpiti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Izpit izpit = db.Izpits.Find(id);
            if (izpit == null)
            {
                return HttpNotFound();
            }
            return View(izpit);
        }

        // GET: Izpiti/Create
        public ActionResult Create()
        {
            ViewBag.PredmetID = new SelectList(db.Predmets, "Id", "Ime");
            ViewBag.StudentID = new SelectList(db.Students, "Id", "Ime");
            return View();
        }

        // POST: Izpiti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Datum,Ocena,PredmetID,StudentID")] Izpit izpit)
        {
            if (ModelState.IsValid)
            {
                db.Izpits.Add(izpit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PredmetID = new SelectList(db.Predmets, "Id", "Ime", izpit.PredmetID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "Ime", izpit.StudentID);
            return View(izpit);
        }

        // GET: Izpiti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Izpit izpit = db.Izpits.Find(id);
            if (izpit == null)
            {
                return HttpNotFound();
            }
            ViewBag.PredmetID = new SelectList(db.Predmets, "Id", "Ime", izpit.PredmetID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "Ime", izpit.StudentID);
            return View(izpit);
        }

        // POST: Izpiti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Datum,Ocena,PredmetID,StudentID")] Izpit izpit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(izpit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PredmetID = new SelectList(db.Predmets, "Id", "Ime", izpit.PredmetID);
            ViewBag.StudentID = new SelectList(db.Students, "Id", "Ime", izpit.StudentID);
            return View(izpit);
        }

        // GET: Izpiti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Izpit izpit = db.Izpits.Find(id);
            if (izpit == null)
            {
                return HttpNotFound();
            }
            return View(izpit);
        }

        // POST: Izpiti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Izpit izpit = db.Izpits.Find(id);
            db.Izpits.Remove(izpit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
