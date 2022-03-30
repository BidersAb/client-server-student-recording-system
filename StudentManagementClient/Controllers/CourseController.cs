using StudentManagementClient.Models;
using StudentManagmentServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementClient.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<Cours> cours;
            HttpResponseMessage responseMassage = GlobalVariable.WebApiClient.GetAsync("Cours").Result;
            cours = responseMassage.Content.ReadAsAsync<IEnumerable<Cours>>().Result;

            return View(cours);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Cours cours)
        {
            try
            {
                // TODO: Add insert logic here
                HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.PostAsJsonAsync("Cours", cours).Result;
                TempData["SuccessMessage"] = "Saveed Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {

            Cours cours;
            HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.GetAsync("Cours/" + id.ToString()).Result;
            cours = responseMessage.Content.ReadAsAsync<Cours>().Result;
     
            return View(cours);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Cours cours)
        {
            try
            {
                // TODO: Add update logic here
                HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.PutAsJsonAsync("Cours/" + id, cours).Result;
                TempData["SuccessMessage"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.DeleteAsync("Cours/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        // POST: Course/Delete/5
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
