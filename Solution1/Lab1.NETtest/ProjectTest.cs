using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1.NETtest
{
    [TestClass]
    public class ProjectTest
    {
        public ProjectTest()
        {
          
        }
        
        [TestMethod]
        public void given_Class_Product()
        {
            Product product = new Product();
            Assert(product);
        }
    }
}
