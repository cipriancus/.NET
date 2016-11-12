using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.NET
{
    public class EmployeeRepository
    {
        private IEnumerable<Employee> list;

        public EmployeeRepository(List<Employee> list)
        {
            if (list.Count < 10)
                throw new Exception("Not enough employees in list, min 10");

            this.list = list;
        }

        public IEnumerable<Employee> retrieveArchitectsQuery()
        {

            IEnumerable<Employee> selectedList = (from architect in list.OfType<Architect>() select architect);

            return selectedList;
        }

        public IEnumerable<Employee> RetriveManagersQuery()
        {
            IEnumerable<Employee> selectedList = (from manager in list.OfType<Architect>() select manager);

            return selectedList;
        }

        public IEnumerable<Employee> RetriveActiveEmployeeQuery()
        {
            IEnumerable<Employee> selectedList = (from employee in list where employee.isActive() select employee);

            return selectedList;
        }


        public IEnumerable<Employee> RetriveAllOrderBySalaryDescendingQuery()
        {
            IEnumerable<Employee> selectedList = (from employee in list
                                                  orderby employee.Salary descending
                                                  select employee);

            return selectedList;
        }

        public IEnumerable<Employee> RetriveAllOrderBySalaryAscendingQuery()
        {
            IEnumerable<Employee> selectedList = (from employee in list
                                                  orderby employee.Salary ascending
                                                  select employee);

            return selectedList;
        }

        public IEnumerable<Employee> RetriveAllByNameQuery(string firstName,string lastName)
        {
            IEnumerable<Employee> selectedList = (from employee in list
                                                  where employee.FirstName==firstName && 
                                                  employee.LastName==lastName
                                                  select employee);

            return selectedList;
        }

        public IEnumerable<Employee> RetriveAllByStartEndDateQuery(DateTime startDate, DateTime endDate)
        {
            IEnumerable<Employee> selectedList = (from employee in list
                                                  where employee.StartDate >= startDate &&
                                                  employee.EndDate <= endDate
                                                  orderby employee.Salary ascending
                                                  select employee);

            return selectedList;
        }

        public IEnumerable<Employee> retrieveArchitectsMethod()
        {

            return list.OfType<Architect>();
        }

        public IEnumerable<Employee> RetriveManagersMethod()
        {
            return list.OfType<Manager>();
        }



        public IEnumerable<Employee> RetriveActiveEmployeeMethod()
        {
            return list.Where(employee => employee.isActive() == true);
        }


        public IEnumerable<Employee> RetriveAllOrderBySalaryDescendingMethod()
        {
            return list.OrderByDescending(employee => employee.Salary);
        }

        public IEnumerable<Employee> RetriveAllOrderBySalaryAscendingMethod()
        {
            return list.OrderBy(employee => employee.Salary);
        }

        public IEnumerable<Employee> RetriveAllByNameMethod(string firstName, string lastName)
        {
            return list.Where(employee => employee.FirstName == firstName && employee.LastName == lastName);
        }

        public IEnumerable<Employee> RetriveAllByStartEndDateMethod(DateTime startDate, DateTime endDate)
        {
            return list.Where(employee => employee.StartDate <= startDate && employee.EndDate <= endDate);
        }
    }
}
