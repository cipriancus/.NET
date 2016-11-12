using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Class
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

        public void UpdateProduct(Product product)
        {
            context.Update(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Remove(product);
            context.SaveChanges();
        }

        public Product GetByIdProduct(Guid id)
        {
            IQueryable<Product> query = context.productDB.Where(product => product.Id == id);
            return query.FirstOrDefault();
        }

        public List<Product> GetAllProduct()
        {
           return context.productDB.ToList();
        }

        public IEnumerable<Product> getProductByPrice(double price)
        {
            IQueryable<Product> query = context.productDB.Where(product => product.Price == price);

            return query;
        }
    }
}
