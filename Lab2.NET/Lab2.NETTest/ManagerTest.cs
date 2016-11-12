using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Lab2.NETtest
{
    public class ManagerTest
    {

        [TestMethod]
        public void When_EmployeeIsInstantiated_then_Salutation_ShoudReturnHelloEmployee()
        {
            Manager employee = CreateSUT();

            var salut = employee.salutations();

            salut.Should().Be("Hello manager");
        }

        private Manager CreateSUT()
        {
            return new Manager("Ciprian", "Cusmuliuc", DateTime.Now, 20);
        }
    }
}
