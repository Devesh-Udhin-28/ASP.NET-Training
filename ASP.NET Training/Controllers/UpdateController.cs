using ASP.NET_Training.BusinessLayer;
using ASP.NET_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Training.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UpdateEmp(EmployeeModel model)
        {
            var IsUserValid = EmployeeBL.UpdateEmployee(model);

            return Json(new { result = IsUserValid, url = Url.Action("Index", "Employee") });
        }
    }
}