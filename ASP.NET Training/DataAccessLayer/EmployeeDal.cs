using ASP.NET_Training.DataAccessLayer.Common;
using ASP.NET_Training.Models;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace ASP.NET_Training.DataAccessLayer
{
    public static class EmployeeDAL
    {

        public const string GetEmployeesQuery = @"SELECT [EmployeeId], [LastName], [FirstName], [HomePhone], [Address], [Address2], [EmailAddress] 
                                                  FROM [dbo].[Employee]";

        public const string UpdateEmployeeQuery = @"UPDATE [dbo].[Employee] 
                                                    SET [FirstName] = @FirstName,
                                                                                [LastName] = @LastName,
                                                                                [Address] = @Address,
                                                                                [Address2] = @Address2,
                                                                                [HomePhone] = @HomePhone,
                                                                                [EmailAddress] = @EmailAddress WHERE [EmployeeId] = @EmployeeId";

        public const string InsertEmployeeQuery = @"INSERT INTO [dbo].[Employee]
                                                                      ([FirstName]
                                                                      ,[LastName]
                                                                      ,[Address]
                                                                      ,[Address2]
                                                                      ,[HomePhone]
                                                                      ,[EmailAddress])
                                                    VALUES (@FirstName,
                                                            @LastName,
                                                            @Address,
                                                            @Address2,
                                                            @HomePhone,
                                                            @EmailAddress";

        public static List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            
            EmployeeModel employee;

            var dt = DatabaseCommand.GetData(GetEmployeesQuery);

            foreach (DataRow row in dt.Rows)
            {
                employee = new EmployeeModel();
                employee.Address = row["Address"].ToString();
                employee.Address2 = row["Address2"].ToString();
                employee.FirstName = row["FirstName"].ToString();
                employee.LastName = row["LastName"].ToString();
                employee.HomePhone = row["HomePhone"].ToString();
                employee.EmailAddress = row["EmailAddress"].ToString();
                employee.EmployeeId = int.Parse(row["EmployeeId"].ToString());

                employees.Add(employee);
            }

            return employees;
        }

        public static bool UpdateEmployee( EmployeeModel model)
        {
            List<SqlParameter> Updateparameters = new List<SqlParameter>
            {
                new SqlParameter("FirstName", model.FirstName),
                new SqlParameter("LastName", model.LastName),
                new SqlParameter("Address", model.Address),
                new SqlParameter("Address2", model.Address2),
                new SqlParameter("HomePhone", model.HomePhone),
                new SqlParameter("EmailAddress", model.EmailAddress),
                new SqlParameter("EmployeeId", model.EmployeeId)
            };

            return DatabaseCommand.UpdateData(UpdateEmployeeQuery, Updateparameters) > 0;
        }

    }

}