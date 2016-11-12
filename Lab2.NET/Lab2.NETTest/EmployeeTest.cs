using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Lab2.NETtest
{

    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void When_EmployeeIsInstanciatedWithStartDateToday_then_IsValidShouldReturnTrue()
        {
            Employee employee = CreateSUT();

            var result = employee.isActive();

            result.Equals(true);
        }

        public void When_EmployeeIsInstanciatedWithName_then_ShouldReturnSameName()
        {
            Employee employee = CreateSUT();

            var fullName = employee.getFullName();

            fullName.Equals("Ciprian Cusmuliuc");

        }

        public void When_EmployeeIsInstantiated_then_Salutation_ShoudReturnHelloEmployee()
        {
            Employee employee = CreateSUT();

            var salut = employee.salutations();

            salut.Should().Be("Hello employee");
        }

        public void When_EmployeeEndDateIsNotSet_then_getEndDate_ShouldThrowException()
        {
            Employee employee = CreateSUT();

            Action action=() => employee.getEndDate();

            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void When_EmployeeIsInstanciatedWithEndDateGreaterThenStartDate_Then_ShouldVerifyAll()
        {
            Employee employee = CreateSUT();

            DateTime now = DateTime.Now;
            employee.setEndDate(now);

            employee.getEndDate().Should().Be(now);
        }

        
        private Employee CreateSUT()
        {
            return new Employee("Ciprian", "Cusmuliuc", DateTime.Now, 20);
        }
    }
}
