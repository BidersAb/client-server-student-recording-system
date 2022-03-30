using StudentManagementClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementClient.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {

            IEnumerable<StudentsModel> studentlist;
            HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.GetAsync("Student").Result;
            studentlist = responseMessage.Content.ReadAsAsync<IEnumerable<StudentsModel>>().Result;
            return View(studentlist);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentsModel student)
        {
            try
            {
                // TODO: Add insert logic here
                student.Date = DateTime.Now;
                HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.PostAsJsonAsync("Students", student).Result;
                TempData["SuccessMessage"] = "Saveed Successfully"; 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            StudentsModel studentsModel = new StudentsModel();
            HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.GetAsync("Students/"+id.ToString()).Result;
            studentsModel = responseMessage.Content.ReadAsAsync<StudentsModel>().Result;
            
            return View(studentsModel);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentsModel  student)
        {
            try
            {
                // TODO: Add update logic here
                HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.PutAsJsonAsync("Students/"+id.ToString(), student).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.DeleteAsync("Students/" + id.ToString()).Result;

            TempData["SuccessMessage"] = "Updated Successfully";
            return RedirectToAction("Index");
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
