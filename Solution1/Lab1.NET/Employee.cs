using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.NET
{
    public abstract class Employee
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Salary { get; set; }

        public abstract String getFullName();

        public abstract Boolean isActive();

        public abstract Boolean setEndDate(DateTime EndDate);
    }
}
