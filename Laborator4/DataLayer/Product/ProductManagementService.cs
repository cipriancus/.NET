using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Laborator4
{
    public class ProductManagementService
    {

        public List<Product> AddTenProducts(List<Product> productList)
        {
            if (productList.Count != 10)
                throw new Exception("List must have 10 products");

            ProductRepository productRepo = new ProductRepository();

            foreach (Product iterator in productList)
                productRepo.CreateProduct(iterator);
            return productList;
        }

        public void AddFiveCategory(List<Category> categoryList)
        {

            if (categoryList.Count != 5)
                throw new Exception("List must have 5 categories");

            CategoryRepository categoryRepo = new CategoryRepository();

            foreach (Category iterator in categoryList)
                categoryRepo.CreateCategory(iterator);
        }

      
        public void lazyLoadingAllCategories()
        {
            var DB= new ProductManagement();

            var query = DB.Categorii;
            foreach(var item in query)
            {
                Console.WriteLine(item.name + " " + item.description);
            }
        }

        public void lazyLoadingAllProducts()
        {
            var DB = new ProductManagement();

            var query = DB.Produse;
            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " " + item.description);
            }
        }

        public void lazyLoadingAllCategoryAndNo()
        {
            var DB = new ProductManagement();

            var query = DB.Categorii;
            foreach (var item in query)
            {
                if(item.allProductsInCategory==null)
                    Console.WriteLine(item.name + " has "+0);
                else
                    Console.WriteLine(item.name + " has " + item.allProductsInCategory.Count);
            }
        }

        public void eagerLoadingAllCategoryAndNo()
        {
                var DB = new ProductManagement();
            
                var query = DB.Categorii.Include("allProductsInCategory");

                foreach (var item in query)
                {
                    if (item.allProductsInCategory == null)
                        Console.WriteLine(item.name + " has " + 0);
                    else
                        Console.WriteLine(item.name + " has " + item.allProductsInCategory.Count);
                }         
        }


        public void explicitLoadingAllCategoryAndNo()
        {
            var DB = new ProductManagement();

            var query = DB.Categorii.Include("allProductsInCategory");

            foreach (var item in query)
            {

                var products = DB.Entry(item).Collection(c => c.allProductsInCategory);
                if (!products.IsLoaded)
                {
                    products.Load();
                }
                           
                Console.WriteLine(item.name + " has " + item.allProductsInCategory.Count);
            }
        }

    }
}
