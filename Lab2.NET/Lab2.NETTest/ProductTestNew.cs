using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Lab2.NET;

namespace Lab2.NETtest
{
    public class ProductTestNew
    {
        [Fact]
        public void When_ProductIsInstanciatedWithPrice20AndVat25_then_ComputeVatShouldReturn5()
        {
            Product product = CreateSUT();

            var result = product.ComputeVat();

            Assert.Equal(result, 5);
            
        }

        [Fact]
        public void When_ProductIsInstanciatedWithStartDateToday_then_IsValidShouldReturnTrue()
        {
            Product product = CreateSUT();

            var result = product.IsValid();

            Assert.Equal(result,true);
        }

        [Fact]
        public void When_ProductIsInstanciated_Then_VerifyAll()
        {
            Product product = CreateSUT();

            Assert.NotEqual(product.Id, Guid.Empty);
            Assert.NotEmpty(product.Description);
            Assert.NotEmpty(product.Name);
            
            //product.Vat.Should().BeGreaterThan(0);
            //product.Price.Should().BeGreaterThan(0);

            Assert.Equal(product.EndDate, DateTime.MinValue);
        }

        [Fact]
        public void When_ProductIsInstanciatedWithEndDateGreaterThenStartDate_Then_ShouldVerifyAll()
        {
            Product product = CreateSUT();

            DateTime time = DateTime.Now.AddDays(1).Date;
            product.SetValability(time);

            Assert.Equal(product.EndDate,time);
          

        }

        [Fact]
        public void When_ProductIsInstanciatedWithEndDateSmallerThenStartDate_Then_ShouldThrowException()
        {
            Product product = CreateSUT();

            Action action = () => product.SetValability(DateTime.Now.AddDays(-1));

            Assert.Throws<ArgumentException>(action);

        }

        private Product CreateSUT()
        {
            return new Product("Apple", "green apple", DateTime.Now, 20, 25);
        }

    }
}
