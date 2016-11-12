using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Class
{
    public class CustomerRepository
    {

        private readonly ProductManagement context;

        public CustomerRepository()
        {
            context = new ProductManagement();
        }

        public void CreateCustomer(Customer customer)
        {
            context.Add(customer);
            context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Update(customer);
            context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            context.Remove(customer);
            context.SaveChanges();
        }

        public Customer GetByIdCustomer(Guid id)
        {
            IQueryable<Customer> query = context.customerDB.Where(customer => customer.Id == id);
            return query.FirstOrDefault();
        }

        public List<Customer> GetAllCustomer()
        {
            return context.customerDB.ToList();
        }

        public IEnumerable<Customer> getCustomerByEmail(string  email)
        {
            IQueryable<Customer> query = context.customerDB.Where(customer => customer.email == email);

            return query;
        }
    }
}
