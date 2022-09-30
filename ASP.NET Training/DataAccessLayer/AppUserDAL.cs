using ASP.NET_Training.DataAccessLayer.Common;
using ASP.NET_Training.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP.NET_Training.DataAccessLayer
{
    public class AppUserDAL
    {

        public const string AuthenticateUserQuery = @"select emp.* from Employee emp with(nolock) inner join AppUser au with(nolock) on emp.EmployeeId = au.EmployeeId
                                                    WHERE emp.EmailAddress = @EmailAddress and au.Password = @Password";

        public const string GetEmployeeByEmailAddress = @"select emp.*,r.* from Employee emp with(nolock) 
                                                          inner join AppUser au with(nolock) on emp.EmployeeId = au.EmployeeId
                                                          inner join Role r with(nolock) on au.RoleId = r.RoleId
                                                          WHERE emp.EmailAddress = @EmailAddress";


        public static bool AuthenticateUser(LoginModel model)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@EmailAddress", model.EmailAddress),
                new SqlParameter("@Password", model.Password)
            };
            // OR
            /*
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress", model.EmailAddress));
            parameters.Add(new SqlParameter("@Password", model.Password));
            */

            var dt = DatabaseCommand.GetDataWithConditions(AuthenticateUserQuery, parameters);

            return dt.Rows.Count > 0;
        }


        public static LoginModel GetEmployeeDetailsWithRoles(LoginModel model)
        {
            LoginModel employee = new LoginModel();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EmailAddress", model.EmailAddress));

            var dt = DatabaseCommand.GetDataWithConditions(GetEmployeeByEmailAddress, parameters);
            foreach (DataRow row in dt.Rows)
            {
                employee.RoleName = row["RoleName"].ToString();
                employee.EmailAddress = row["EmailAddress"].ToString().Trim();
                employee.RoleId = int.Parse(row["RoleId"].ToString());
            }
            return employee;
        }

    }
}