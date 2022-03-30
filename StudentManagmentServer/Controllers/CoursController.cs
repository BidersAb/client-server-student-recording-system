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
using StudentManagmentServer.Models;

namespace StudentManagmentServer.Controllers
{
    public class CoursController : ApiController
    {
        private StudentManagmentDBContext db = new StudentManagmentDBContext();

        // GET: api/Cours
        public IQueryable<Cours> GetCourses()
        {
            return db.Courses;
        }

        // GET: api/Cours/5
        [ResponseType(typeof(Cours))]
        public IHttpActionResult GetCours(int id)
        {
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return NotFound();
            }

            return Ok(cours);
        }

        // PUT: api/Cours/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCours(int id, Cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cours.CourseID)
            {
                return BadRequest();
            }

            db.Entry(cours).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursExists(id))
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

        // POST: api/Cours
        [ResponseType(typeof(Cours))]
        public IHttpActionResult PostCours(Cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(cours);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cours.CourseID }, cours);
        }

        // DELETE: api/Cours/5
        [ResponseType(typeof(Cours))]
        public IHttpActionResult DeleteCours(int id)
        {
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return NotFound();
            }

            db.Courses.Remove(cours);
            db.SaveChanges();

            return Ok(cours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursExists(int id)
        {
            return db.Courses.Count(e => e.CourseID == id) > 0;
        }
    }
}