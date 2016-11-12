using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Lab2.NET;

namespace Lab2.NETtest
{
    [TestClass]

    public class ArchitectText
    {
        [TestMethod]
        public void When_EmployeeIsInstantiated_then_Salutation_ShoudReturnHelloEmployee()
        {
            Architect employee = CreateSUT();

            var salut = employee.salutations();

            salut.Should().Be("Hello architect");
        }

        private Architect CreateSUT()
        {
            return new Architect("Ciprian", "Cusmuliuc", DateTime.Now, 20);
        }
    }
}
