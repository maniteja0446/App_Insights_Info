using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApp_FrontEnd.Models;

namespace WebApp_FrontEnd.Controllers
{
    public class MyEmployeeController : Controller
    {
        // GET: MyEmployeeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyEmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyEmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyEmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MyEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<JsonResult> GetDepartmentAsync()
        {
            List<Department> departments = new List<Department>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://azrg-wa-api.azurewebsites.net/weatherforecast"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    departments = JsonConvert.DeserializeObject<List<Department>>(apiResponse);
                }
            }
            departments.Insert(0, new Department { DID = 0, DepartmentName = "Select" });
            return Json(new SelectList(departments, "DID", "DepartmentName"));
        }


    }
}
