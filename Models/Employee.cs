using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employe.Models
{
    public class Employee
    {
        public int empid { get; set; }
        public string  Name { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Country { get; set; }

        public string State { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}