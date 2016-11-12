using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator4
{
    public class CustomerRepository
    {
        private readonly ProductManagement context;
        public CustomerRepository()
        {
            context = new ProductManagement();
        }
        public void CreateCustomer(Customer product)
        {
            context.Add(product);
            context.SaveChanges();
        }
        public void Update(Customer product)
        {
            context.Update(product);
            context.SaveChanges();
        }
        public void Detele(Customer product)
        {
            context.Remove(product);
            context.SaveChanges();
        }
        public IEnumerable<Customer> GetById(Guid Idd)
        {
            IEnumerable<Customer> var = context.Clienti.Where(p => p.Id == Idd);
            return var;
        }
        public IEnumerable<Customer> GetAll()
        {
            IEnumerable<Customer> var = context.Clienti;
            return var;
        }

    }
}
