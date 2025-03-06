using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiVaja.Models;

namespace WebApiVaja.Controllers
{
    public class MentorsController : ApiController
    {
        private Evidenca db = new Evidenca();

        // GET: api/Mentors
        public IQueryable<Mentor> GetMentor()
        {
            return db.Mentor;
        }

        // GET: api/Mentors/5
        [ResponseType(typeof(Mentor))]
        public IHttpActionResult GetMentor(int id)
        {
            var mentors = db.Mentor.Include("IzvedbaMentor").Include("PlanSodelavci");
            var mentor = mentors.FirstOrDefault(x => x.MenId == id);

            if (mentor == null)
            {
                return NotFound();
            }

            return Ok(mentor);
        }

        // PUT: api/Mentors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMentor(int id, Mentor mentor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mentor.MenId)
            {
                return BadRequest();
            }

            db.Entry(mentor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Mentors
        [ResponseType(typeof(Mentor))]
        public IHttpActionResult PostMentor(Mentor mentor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mentor.Add(mentor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mentor.MenId }, mentor);
        }

        // DELETE: api/Mentors/5
        [ResponseType(typeof(Mentor))]
        public IHttpActionResult DeleteMentor(int id)
        {
            Mentor mentor = db.Mentor.Find(id);
            if (mentor == null)
            {
                return NotFound();
            }

            db.Mentor.Remove(mentor);
            db.SaveChanges();

            return Ok(mentor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MentorExists(int id)
        {
            return db.Mentor.Count(e => e.MenId == id) > 0;
        }
    }
}