using System;
using System.Collections.Generic;
using System.Linq;

namespace Laborator4
{
    public class ProductRepository
    {
        private readonly ProductManagement context;
        public ProductRepository()
        {
            context = new ProductManagement();
        }
        public void CreateProduct(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }
        public void Update(Product product)
        {
            context.Update(product);
            context.SaveChanges();
        }
        public void Detele(Product product)
        {
            context.Remove(product);
            context.SaveChanges();
        }
        public IEnumerable<Product> GetById(Guid Idd)
        {
            IEnumerable<Product>var= context.Produse.Where(p => p.Id == Idd);
            return var;
        }
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> var = context.Produse;
            return var;
        }

    }
}
