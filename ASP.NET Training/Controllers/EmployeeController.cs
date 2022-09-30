using ASP.NET_Training.BusinessLayer;
using ASP.NET_Training.DataAccessLayer;
using ASP.NET_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Training.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        // search for ActionResult, ViewResult, JsonResult
        /*public ActionResult Index()
        {

            int hour = DateTime.Now.Hour;

            ViewBag.Greeting = 
                hour < 12
                ? "Good Morning. Time is " + DateTime.Now.ToShortTimeString()
                : "Good Afternoon. Time is " + DateTime.Now.ToShortTimeString();

            return View();
        }*/

        public ActionResult Index()
        {

            //var data = EmployeeBL.GetEmployees();
            //ViewBag.EmployeeList = data;

            //return View();

            var loggedUser = Session["CurrentUser"] as LoginModel;

            var data = EmployeeBL.GetEmployees();
            ViewBag.EmployeeList = data;
            
            var myView = View();

            if(loggedUser != null && loggedUser.RoleName.Equals("Administrator"))
            {
                myView.MasterName = "~/Views/Shared/_AdminLayout.cshtml";
            }
            else
            {
                myView.MasterName = "~/Views/Shared/_Layout.cshtml";
            }

            return myView;
        }

        //public ActionResult Edit(int id)
        //{
        //    var employeeModelID = new EmployeeModel();

        //    employeeModelID.EmployeeId = id;
        //    return View(employeeModelID);
        //}

        public ActionResult Edit(int id)
        {
            var data = EmployeeBL.GetEmployees().FirstOrDefault(x => x.EmployeeId == id);
            return View(data);
            //var employeeModelID = new EmployeeModel();
            //var data = EmployeeBL.GetEmployees();
            //ViewBag.EmployeeList = data;
            //employeeModelID.EmployeeId = id;
            //return View(employeeModelID);
        }

        public ActionResult Create()
        {
            
            return View();
        }
    }
}