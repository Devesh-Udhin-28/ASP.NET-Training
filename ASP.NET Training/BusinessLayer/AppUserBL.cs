using ASP.NET_Training.DataAccessLayer;
using ASP.NET_Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Training.BusinessLayer
{
    public class AppUserBL
    {
        public static bool AuthenticateUser(LoginModel model)
        {
            return AppUserDAL.AuthenticateUser(model);
        }

        public static LoginModel GetEmployeeDetailsWithRoles(LoginModel model)
        {
            return AppUserDAL.GetEmployeeDetailsWithRoles(model);
        }
    }
}