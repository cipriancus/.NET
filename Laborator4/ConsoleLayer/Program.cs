using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laborator4;

namespace ConsoleLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomerRepository customerRepo = new CustomerRepository();

            Customer customer = new Customer();
            customer.Name = "cirpian";
            customer.Address = "ana";
            customer.PhoneNumber = 23312;
            customer.Email = "ciprian@wawd.com";
            customerRepo.CreateCustomer(customer);

            ProductManagementService productManagementService = new ProductManagementService();
            
            List<Product> productList = createProductNo(10);
            List<Category> categoryList = createCategoryNo(5, productList);

            productManagementService.AddFiveCategory(categoryList);
            productManagementService.lazyLoadingAllCategories();
            productManagementService.lazyLoadingAllProducts();
            productManagementService.lazyLoadingAllCategoryAndNo();
            productManagementService.eagerLoadingAllCategoryAndNo();
            productManagementService.explicitLoadingAllCategoryAndNo();
            int a = 2;
            //productManagementService.AddTenProducts(productList);
            
        }

        static List<Category> createCategoryNo(int no, List<Product> allProd)
        {
            if (allProd.Count < no)
                throw new Exception("Not enough products in list of products");

            List<Category> categoryList = new List<Category>();
            for (int iterator = 0; iterator < no; iterator++)
            {
                Category category = new Category();
                category.description = "sunt categoria numarul " + iterator;
                category.name = "NumeCategori" + iterator;
                List<Product> newList = new List<Product>();

                newList.Add(allProd[iterator]);
                newList.Add(allProd[iterator+no]);

                category.allProductsInCategory = newList;
                categoryList.Add(category);

            }
            return categoryList;
        }
        static List<Product> createProductNo(int no)
        {
            List<Product> productList = new List<Product>();
            for (int iterator = 0; iterator < no; iterator++)
            {
                Product product = new Product();
                product.Name = "nume" + iterator;
                product.Price = iterator * 5 + 1;
                product.description = "sunt un produs nr" + iterator;
                product.StardDate = DateTime.Now;
                product.EndDate = DateTime.Now;
                product.Vat = 20 + iterator;
                productList.Add(product);
            }
            return productList;
        }


    }
}
