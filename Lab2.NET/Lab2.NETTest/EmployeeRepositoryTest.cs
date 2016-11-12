using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Lab2.NETTest
{
    [TestClass]
    public class EmployeeRepositoryTest
    { 
        //employee with less than 10 members throw exception
        [TestMethod]
        public void WhenEmployeeInstatiatedWithLessThan10_ThenShoudThrowException()
        {
            EmployeeRepository emp ;
            
            Action action=()=> emp = new EmployeeRepository(createSUTLIst(5));
            action.ShouldThrow<Exception>();
        }


        //employee with more than 10 members not throw exception
        [TestMethod]
        public void WhenEmployeeInstatiatedWithMoreThan10_ThenShoudNotThrowException()
        {
            EmployeeRepository emp;

            Action action = () => emp = new EmployeeRepository(createSUTLIst(11));
            action.ShouldNotThrow<Exception>();
        }


        //employee retrieveArchitectsQuery
        [TestMethod]
        public void WhenRetrieveArchitectQueryIsCalledWith5Architect_Then_ShoudReturn5()
        {
            EmployeeRepository emp= new EmployeeRepository(createSUTLIstWithArchitects(5));
            emp.retrieveArchitectsQuery().Count<Employee>().Should().Be(5);

        }

        //employee retrieveArchitectsMethod
        [TestMethod]
        public void WhenRetrieveArchitectMehodIsCalledWith5Architect_Then_ShoudReturn5()
        {
            EmployeeRepository emp = new EmployeeRepository(createSUTLIstWithArchitects(5));
            emp.retrieveArchitectsMethod().Count<Employee>().Should().Be(5);

        }


        //employee RetriveManagersQuery
        [TestMethod]
        public void WhenRetriveManagersQueryIsCalledWith5Managers_Then_ShoudReturn5()
        {
            EmployeeRepository emp = new EmployeeRepository(createSUTLIstWithManagers(5));

            emp.RetriveManagersQuery().Equals(5);


        }


        //employee RetriveManagersMehod
        [TestMethod]
        public void WhenRetriveManagersMethodIsCalledWith5Managers_Then_ShoudReturn5()
        {
            EmployeeRepository emp = new EmployeeRepository(createSUTLIstWithManagers(5));

            emp.RetriveManagersMethod().Equals(5);


        }


        //employee RetriveActiveEmployeeQuery with all active
        [TestMethod]
        public void WhenRetriveActiveEmployeeQueryIsCalledWith11ActiveEmployees_Then_ShoudReturn11()
        {
            EmployeeRepository emp = new EmployeeRepository(createSUTLIst(11));

            emp.RetriveActiveEmployeeQuery().Equals(11);
        }



        //employee RetriveActiveEmployeeMethod with all active
        [TestMethod]
        public void WhenRetriveActiveEmployeeMethodIsCalledWith11ActiveEmployees_Then_ShoudReturn11()
        {
            EmployeeRepository emp = new EmployeeRepository(createSUTLIst(11));

            emp.RetriveActiveEmployeeMethod().Equals(11);
        }


        //employee RetriveActiveEmployeeQuery with some active
        [TestMethod]
        public void WhenRetriveActiveEmployeeQueryIsCalledWith11EmployeesBut5Active_Then_ShoudReturn5()
        {

            List<Employee> list = createSUTLIst(5);
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));      
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));

            EmployeeRepository emp = new EmployeeRepository(list);

            emp.RetriveActiveEmployeeQuery().Should().HaveCount(5);


        }


        //employee RetriveActiveEmployeeMethod with some active
        [TestMethod]
        public void WhenRetriveActiveEmployeeMethodIsCalledWith11EmployeesBut5Active_Then_ShoudReturn5()
        {

            List<Employee> list = createSUTLIst(5);
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));
            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 1, 19));

            EmployeeRepository emp = new EmployeeRepository(list);

            emp.RetriveActiveEmployeeMethod().Should().HaveCount(5);


        }



        [TestMethod]
        public void WhenRetriveAllOrderBySalaryDescendingQueryIsCalled_Then_ShoudReturnEmployeesOrderedBySalary()
        {

            List<Employee> list = createSUTLIstWithDifferentSalary(11);
           
            EmployeeRepository emp = new EmployeeRepository(list);

            IEnumerable<Employee> newEmployeeList = emp.RetriveAllOrderBySalaryDescendingQuery();

            int salary = 10;
            foreach(Employee iterator in newEmployeeList)
            {
                iterator.Salary.Should().Be(salary--);
            }
        }


        [TestMethod]
        public void WhenRetriveAllOrderBySalaryDescendingMethodIsCalled_Then_ShoudReturnEmployeesOrderedBySalary()
        {

            List<Employee> list = createSUTLIstWithDifferentSalary(11);

            EmployeeRepository emp = new EmployeeRepository(list);

            IEnumerable<Employee> newEmployeeList = emp.RetriveAllOrderBySalaryDescendingMethod();

            int salary = 10;
            foreach (Employee iterator in newEmployeeList)
            {
                iterator.Salary.Should().Be(salary--);
            }
        }


        [TestMethod]
        public void WhenRetriveAllOrderBySalaryAscendingQueryIsCalled_Then_ShoudReturnEmployeesOrderedBySalary()
        {

            List<Employee> list = createSUTLIstWithDifferentSalary(11);

            EmployeeRepository emp = new EmployeeRepository(list);

            IEnumerable<Employee> newEmployeeList = emp.RetriveAllOrderBySalaryAscendingQuery();

            int salary = 0;
            foreach (Employee iterator in newEmployeeList)
            {
                iterator.Salary.Should().Be(salary++);
            }
        }



        [TestMethod]
        public void WhenRetriveAllOrderBySalaryAscendingMethodIsCalled_Then_ShoudReturnEmployeesOrderedBySalary()
        {

            List<Employee> list = createSUTLIstWithDifferentSalary(11);

            EmployeeRepository emp = new EmployeeRepository(list);

            IEnumerable<Employee> newEmployeeList = emp.RetriveAllOrderBySalaryAscendingMethod();

            int salary = 0;
            foreach (Employee iterator in newEmployeeList)
            {
                iterator.Salary.Should().Be(salary++);
            }

        }


        [TestMethod]
        public void WhenRetriveAllByNameQueryIsCalled_ThenReturnList_ShoudNotBeEmpty()
        {

            List<Employee> list = createSUTLIst(11);

            EmployeeRepository emp = new EmployeeRepository(list);

            IEnumerable<Employee> newEmployeeList = emp.RetriveAllByNameQuery("Ciprian", "Cusmuliuc");

            foreach (Employee iterator in newEmployeeList)
            {
                iterator.FirstName.Should().Be("Ciprian");
                iterator.LastName.Should().Be("Cusmuliuc");
            }
        }


        [TestMethod]
        public void WhenRetriveAllByNameMethodIsCalled_ThenReturnList_ShoudNotBeEmpty()
        {

            List<Employee> list = createSUTLIst(11);

            EmployeeRepository emp = new EmployeeRepository(list);

            IEnumerable<Employee> newEmployeeList = emp.RetriveAllByNameMethod("Ciprian", "Cusmuliuc");

            foreach (Employee iterator in newEmployeeList)
            {
                iterator.FirstName.Should().Be("Ciprian");
                iterator.LastName.Should().Be("Cusmuliuc");
            }
        }


        [TestMethod]
        public void WhenRetriveAllByStartEndDateQueryIsCalled_ThenReturnList_ShoudNotBeEmpty()
        {

            List<Employee> list = createSUTLIst(5);

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015,5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            EmployeeRepository emp = new EmployeeRepository(list);

            IEnumerable<Employee> newEmployeeList = emp.RetriveAllByStartEndDateQuery(new DateTime(2015, 1, 18), new DateTime(2015, 5, 19));

            newEmployeeList.Should().HaveCount(6);
        }

        [TestMethod]
        public void WhenRetriveAllByStartEndDateMethodIsCalled_ThenReturnList_ShoudNotBeEmpty()
        {

            List<Employee> list = createSUTLIst(5);

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            list.Add(new Employee("Ciprian", "Cusmuliuc", new DateTime(2015, 1, 18), 20));
            list[list.Count - 1].setEndDate(new DateTime(2015, 5, 19));

            EmployeeRepository emp = new EmployeeRepository(list);

            IEnumerable<Employee> newEmployeeList = emp.RetriveAllByStartEndDateMethod(new DateTime(2015, 1, 18), new DateTime(2015, 5, 19));

            newEmployeeList.Should().HaveCount(6);


        }


        private List<Employee> createSUTLIstWithDifferentSalary(int no)
        {
            List<Employee> list = new List<Employee>();
            for (int iterator = 0; iterator < no; iterator++)
            {
                list.Add(new Employee("Ciprian", "Cusmuliuc", DateTime.Now, iterator));
            }
            return list;
        }



        private List<Employee> createSUTLIst(int no)
        {
            List<Employee> list = new List<Employee>();
            for(int iterator = 0; iterator < no; iterator++)
            {
                list.Add(new Employee("Ciprian", "Cusmuliuc", DateTime.Now, 20));
                list[list.Count - 1].setEndDate(new DateTime(2016, 11, 19));
            }
            return list;
        }


        //5 emp and no or arch
        private List<Employee> createSUTLIstWithArchitects(int no)
        {
            List<Employee> list = new List<Employee>();
            for (int iterator = 0; iterator < 5; iterator++)
            {
                list.Add(new Employee("Ciprian", "Cusmuliuc", DateTime.Now, 20));
            }

            for (int iterator = 0; iterator < no; iterator++)
            {
                list.Add(new Architect("Ciprian", "Cusmuliuc", DateTime.Now, 20));
            }

            return list;
        }

        //5 emp and no or managers
        private List<Employee> createSUTLIstWithManagers(int no)
        {
            List<Employee> list = new List<Employee>();
            for (int iterator = 0; iterator < 5; iterator++)
            {
                list.Add(new Employee("Ciprian", "Cusmuliuc", DateTime.Now, 20));
            }

            for (int iterator = 0; iterator < no; iterator++)
            {
                list.Add(new Manager("Ciprian", "Cusmuliuc", DateTime.Now, 20));
            }

            return list;
        }
    }
}
