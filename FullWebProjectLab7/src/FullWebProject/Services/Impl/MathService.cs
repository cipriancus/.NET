using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullWebProject.Services
{
    public class MathService : IMathService
    {
        public double ComputeVat(double valueOfProduct, int vat)
        {
            if (vat == 0)
                throw new Exception("Vat cannot be 0");

            return (double)(valueOfProduct * ((double)vat / 100));
        }
    }
}
