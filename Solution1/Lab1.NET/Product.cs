using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.NET
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double Price { get; set; }
        public int VAT { get; set; }

        public bool isValid()
        {
            if (DateTime.Now<EndDate)
                return true;
            return false;
        }

        public double computeVAT()
        {
            return (Price * VAT) / 100;
        }

        public Boolean setEndDate(DateTime EndDate)
        {
            if (EndDate < StartDate)
                return false;

            this.EndDate = EndDate;
            return true;
        }

        public Boolean setStartDate(DateTime StartDate)
        {
            if (EndDate < StartDate)
                return false;

            this.StartDate  = StartDate;
            return true;
        }

    }
}
