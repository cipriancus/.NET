using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.NET
{
    public class ProductRepository
    {
        private List<Product> productArray;

        public ProductRepository(List<Product> productArray)
        {
            if (productArray.Count() < 3)
                throw new Exception("Not enough products in list");
            this.productArray = productArray;
        }


        public Product getProductByName(string productName)
        {
            if (productName == null)
                throw new ArgumentNullException();

            if (productName.Length == 0)
                throw new Exception("String shouldn't be empty");
                   
            foreach (Product iterator in productArray)
            {
                if (iterator.Name.CompareTo(productName) == 0)
                    return iterator;
            }
            return null;
        }

        public List<Product> findAllProducts()
        {
            return productArray;
        }

        public void addProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            this.productArray.Add(product);
        }

        public Product getProductByPosition(int position)
        {
            if (position < 0)
                throw new Exception("Position must be positive");
            return productArray[position]; 
        }

        public bool removeProductByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            if (name.Length == 0)
                throw new Exception("String shouldn't be empty");

            for (int iterator=0;iterator<productArray.Count;iterator++)
            {
                if (productArray[iterator].Name.CompareTo(name) == 0)
                {
                    productArray.Remove(productArray[iterator]);
                    return true;
                }  
            }
            return false;
        }

    }
}
