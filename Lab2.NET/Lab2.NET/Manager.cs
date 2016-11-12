using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.NET
{
    public class Manager : Employee
    {
        public Manager(string FirstName, string LastName, DateTime startDate, int salary) :base( FirstName,  LastName,  startDate,  salary)
        {
            
        }

        public override string salutations()
        {
            return "Hello manager";
        }
    }
}
