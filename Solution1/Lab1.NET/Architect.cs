using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.NET
{
    public class Architect : Employee
    {
        public override String getFullName()
        {
            return FirstName + " " + LastName;
        }

        public override Boolean isActive()
        {
            if (DateTime.Now < EndDate)
                return true;
            return false;
        }

        public override Boolean setEndDate(DateTime EndDate)
        {
            if (EndDate < StartDate)
                return false;

            this.EndDate = EndDate;
            return true;
        }
    }
}
