using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.NET
{
    public class Employee
    {
        public Employee(string FirstName, string LastName, DateTime startDate, int salary)
        {
            this.id = Guid.NewGuid();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.StartDate = startDate;
            this.Salary = salary;
        }
        public Guid id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate {  get; private set; }
        public int Salary { get; private set; }

        public String getFullName()
        {
            return FirstName + " " + LastName;
        }

        public Boolean isActive()
        {
            if (DateTime.Now < EndDate)
                return true;
            return false;
        }

        public Boolean setEndDate(DateTime EndDate)
        {
            if (EndDate < StartDate)
                return false;

            this.EndDate = EndDate;
            return true;
        }

        public virtual String salutations()
        {
            return "Hello employee";
        }

        public DateTime getEndDate()
        {
            if (this.EndDate == null)
                throw new ArgumentNullException();
            return EndDate;
        }
 
    }
}
