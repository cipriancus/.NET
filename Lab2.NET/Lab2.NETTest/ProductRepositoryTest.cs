using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Lab2.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2.NETTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        //testam constructor mai mic ca 3
        [TestMethod]
        public void WhenProductRepositoryInstantiatedWithLessThan3_Then_ShoudThrowException()
        {

            ProductRepository productRepository;
            Action action =()=> productRepository = new ProductRepository(createSUTList(2));
            action.ShouldThrow<Exception>();
        }
        [TestMethod]
        //testam constructor cand e ok
        public void WhenProductRepositoryInstantiatedWithMoreThan2_Then_ShoudNotThrowException()
        {

            ProductRepository productRepository;
            Action action = () => productRepository = new ProductRepository(createSUTList(3));
            action.ShouldNotThrow<Exception>();
        }


        [TestMethod]
        //testam getProductByName cand e null si empty
        public void WhenProductRepositoryCallsGetProductNameWithNull_Then_ShoudThrowException()
        {

            ProductRepository productRepository=new ProductRepository(createSUTList(3));
            Action action = () => productRepository.getProductByName(null);
            action.ShouldThrow<ArgumentNullException>();
        }
        [TestMethod]

        public void WhenProductRepositoryCallsGetProductNameWithEmpty_Then_ShoudThrowException()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));
            Action action = () => productRepository.getProductByName("");
            action.ShouldNotThrow<ArgumentNullException>();
        }
        [TestMethod]

        //testam getProductByName cand e ok
        public void WhenProductRepositoryCallsGetProductNameWithApple_Then_ShoudReturnProduct()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));
            Product product=productRepository.getProductByName("Apple");

            product.Name.Should().Be(createSUT().Name);
            product.Description.Should().Be(createSUT().Description);
            product.Price.Should().Be(createSUT().Price);
            product.Vat.Should().Be(createSUT().Vat);

        }

        //testam findAllProducts dc e ok
        [TestMethod]
        public void WhenProductRepositoryCallsFindAllProducts_Then_ShoudReturnAllProducts()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));
            List<Product> products = productRepository.findAllProducts();
            List<Product> expectedProduct = createSUTList(3);

            products.Count.Should().Be(expectedProduct.Count);

            for (int iterator = 0; iterator < products.Count; iterator++)
            {
                products[iterator].Name.Should().Be(expectedProduct[iterator].Name);
                products[iterator].Description.Should().Be(expectedProduct[iterator].Description);
                products[iterator].Price.Should().Be(expectedProduct[iterator].Price);
                products[iterator].Vat.Should().Be(expectedProduct[iterator].Vat);
            }
        }
        [TestMethod]

        //testam addProduct daca e null
        public void WhenProductRepositoryCallsAddProductNull_Then_ShoudThrowException()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));

            Action action = () => productRepository.addProduct(null);
            action.ShouldThrow<ArgumentNullException>();

        }

        [TestMethod]

        //testam addProduct daca e ok
        public void WhenProductRepositoryCallsAddProductNotNull_Then_ShoudNotThrowException()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));

            Action action = () => productRepository.addProduct(createSUT());
            action.ShouldNotThrow<ArgumentNullException>();

        }

        [TestMethod]

        //testam getProductByPosition dc punem negativ
        public void WhenProductRepositoryCallsGetProductByPositionWithNegative_Then_ShoudThrowException()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));

            Action action = () => productRepository.getProductByPosition(-1);
            action.ShouldThrow<Exception>();

        }
        [TestMethod]

        //testam getProductByPosition dc e ok
        public void WhenProductRepositoryCallsGetProductByPositionWithGood_Then_ShoudReturnProduct()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));

            Product product= productRepository.getProductByPosition(2);

            product.Name.Should().Be(createSUT().Name);
            product.Description.Should().Be(createSUT().Description);
            product.Price.Should().Be(createSUT().Price);
            product.Vat.Should().Be(createSUT().Vat);


        }
        //testam removeProductByName daca e ok return false si true
        [TestMethod]

        public void WhenProductRepositoryCallsRemoveProductByNameWithApple_Then_ShoudReturnTrue()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));

            bool result=productRepository.removeProductByName("Apple");
            result.Should().Be(true);

            result = productRepository.removeProductByName("car");
            result.Should().Be(false);

        }
        [TestMethod]

        //testam removeProductByName cand e null si empty
        public void WhenProductRepositoryCallsGetProductByPositionWithNullAndEmply_Then_ShoudThrowException()
        {

            ProductRepository productRepository = new ProductRepository(createSUTList(3));

            Action action = () => productRepository.removeProductByName(null);
            action.ShouldThrow<ArgumentNullException>();

            action = () => productRepository.removeProductByName("");
            action.ShouldThrow<Exception>();

        }

        private List<Product> createSUTList(int noOfInstances)
        {
            List<Product> newList = new List<Product>();
            
            for(int iterator = 0; iterator < noOfInstances; iterator++)
            {
                newList.Add(new Product("Apple", "green apple", DateTime.Now, 20, 25));
            }
            return newList;
        }

        private Product createSUT()
        {
            return new Product("Apple", "green apple", DateTime.Now, 20, 25);
        }
    }
}
