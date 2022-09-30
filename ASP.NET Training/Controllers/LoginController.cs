using ASP.NET_Training.BusinessLayer;
using ASP.NET_Training.DataAccessLayer;
using ASP.NET_Training.DataAccessLayer.Common;
using ASP.NET_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Training.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Authenticate(LoginModel model)
        {
            var IsUserValid = AppUserBL.AuthenticateUser(model);

            if (IsUserValid)
            {
                LoginModel employeeInfo = AppUserBL.GetEmployeeDetailsWithRoles(model);
                this.Session["CurrentUser"] = employeeInfo;
                this.Session["CurrentRole"] = employeeInfo.RoleName;

            }

            return Json(new { result = IsUserValid, url = Url.Action("Index", "Employee") });
        }
    }
}