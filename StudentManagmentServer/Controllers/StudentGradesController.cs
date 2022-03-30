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
    public class StudentGradesController : ApiController
    {
        private StudentManagmentDBContext db = new StudentManagmentDBContext();

        // GET: api/StudentGrades
        public IQueryable<StudentGrade> GetStudentGrades()
        {
            return db.StudentGrades;
        }

        // GET: api/StudentGrades/5
        [ResponseType(typeof(StudentGrade))]
        public IHttpActionResult GetStudentGrade(int id)
        {
            StudentGrade studentGrade = db.StudentGrades.Find(id);
            if (studentGrade == null)
            {
                return NotFound();
            }

            return Ok(studentGrade);
        }

        // PUT: api/StudentGrades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentGrade(int id, StudentGrade studentGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentGrade.GaradeID)
            {
                return BadRequest();
            }

            db.Entry(studentGrade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGradeExists(id))
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

        // POST: api/StudentGrades
        [ResponseType(typeof(StudentGrade))]
        public IHttpActionResult PostStudentGrade(StudentGrade studentGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentGrades.Add(studentGrade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentGrade.GaradeID }, studentGrade);
        }

        // DELETE: api/StudentGrades/5
        [ResponseType(typeof(StudentGrade))]
        public IHttpActionResult DeleteStudentGrade(int id)
        {
            StudentGrade studentGrade = db.StudentGrades.Find(id);
            if (studentGrade == null)
            {
                return NotFound();
            }

            db.StudentGrades.Remove(studentGrade);
            db.SaveChanges();

            return Ok(studentGrade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentGradeExists(int id)
        {
            return db.StudentGrades.Count(e => e.GaradeID == id) > 0;
        }
    }
}