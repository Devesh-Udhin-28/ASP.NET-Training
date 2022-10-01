using ASP.NET_Training.BusinessLayer;
using ASP.NET_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Training.Controllers
{
    public class EditEmployeeController : Controller
    {
        // GET: Update
        // Index() is never used
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UpdateEmp(EmployeeModel model)
        {
            var IsUpdateSuccess = EmployeeBL.UpdateEmployee(model);

            return Json(new { result = IsUpdateSuccess, url = Url.Action("Index", "Employee") });
        }

        [HttpPost]
        public JsonResult InsertEmp(EmployeeModel model)
        {
            var IsInsertSuccess = EmployeeBL.InsertEmployee(model);

            return Json(new { result = IsInsertSuccess, url = Url.Action("Index", "Employee") });
        }
    }
}