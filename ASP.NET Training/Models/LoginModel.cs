using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Training.Models
{
    public class LoginModel
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}