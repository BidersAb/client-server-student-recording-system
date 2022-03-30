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
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            IEnumerable<Department> deparmentModels;
            HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.GetAsync("Departments").Result;
            deparmentModels = responseMessage.Content.ReadAsAsync<IEnumerable<Department>>().Result;

            return View(deparmentModels);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(DepartmentModel  department)
        {
            try
            {
                // TODO: Add insert logic here
                Department departmentModel;
                HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.PostAsJsonAsync("Departments",department).Result;
                departmentModel = responseMessage.Content.ReadAsAsync<Department>().Result;
                TempData["SuccessMessage"] = "Saveed Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            Department departmentModel;
            HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.GetAsync("Departments/" + id.ToString()).Result;
            departmentModel = responseMessage.Content.ReadAsAsync<Department>().Result;
            return View(departmentModel);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, DepartmentModel department)
        {
            try
            {
                // TODO: Add update logic here
                HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.PutAsJsonAsync("Departments/" + id.ToString(), department).Result;
                TempData["SuccessMessage"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            HttpResponseMessage responseMessage = GlobalVariable.WebApiClient.DeleteAsync("Departments/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        // POST: Department/Delete/5
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
