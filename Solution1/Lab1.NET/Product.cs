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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public int VAT { get; set; }

        public bool isValid()
        {
            if (StartDate.CompareTo(EndDate) < 0)
                return true;
            return false;
        }

        public double computeVAT()
        {
            return (Price * VAT) / 100;
        }

    }
}
