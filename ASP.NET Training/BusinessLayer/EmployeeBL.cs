using ASP.NET_Training.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_Training.Models;

namespace ASP.NET_Training.BusinessLayer
{
    public class EmployeeBL
    {

        public static List<EmployeeModel> GetEmployees()
        {
            return EmployeeDAL.GetEmployees();
        }

        public static bool UpdateEmployee(EmployeeModel employee)
        {
            return EmployeeDAL.UpdateEmployee(employee);
        }

        public static bool InsertEmployee(EmployeeModel employee)
        {
            return EmployeeDAL.InsertEmployee(employee);
        }

    }
}