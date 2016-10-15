using System;
using Business;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void When_ProductIsInstanciatedWithPrice20AndVat25_then_ComputeVatShouldReturn5()
        {
            Product product = CreateSUT();

            var result = product.ComputeVat();

            result.Should().Be(5);
        }

        [TestMethod]
        public void When_ProductIsInstanciatedWithStartDateToday_then_IsValidShouldReturnTrue()
        {
            Product product = CreateSUT();

            var result = product.IsValid();

            result.Should().Be(true);
        }

        [TestMethod]
        public void When_ProductIsInstanciated_Then_VerifyAll()
        {
            Product product = CreateSUT();

            product.Id.Should().NotBe(Guid.Empty);

            product.Description.Should().NotBeNullOrEmpty();
            product.Name.Should().NotBeNullOrEmpty();

            product.Vat.Should().BeGreaterThan(0);
            product.Price.Should().BeGreaterThan(0);
            product.EndDate.Should().Be(DateTime.MinValue);
        }

        [TestMethod]
        public void When_ProductIsInstanciatedWithEndDateGreaterThenStartDate_Then_ShouldVerifyAll()
        {
            Product product = CreateSUT();

            product.SetValability(DateTime.Now.AddDays(1));

            product.EndDate.Date.Should().Be(DateTime.Now.AddDays(1).Date);
        }

        [TestMethod]
        public void When_ProductIsInstanciatedWithEndDateSmallerThenStartDate_Then_ShouldThrowException()
        {
            Product product = new Product("Apple", "green apple", DateTime.Now,  20, 25);

            Action action = () => product.SetValability(DateTime.Now.AddDays(-1));

            action.ShouldThrow<ArgumentException>();
        }

        private Product CreateSUT()
        {
            return new Product("Apple", "green apple", DateTime.Now,  20, 25);
        }
    }
}
