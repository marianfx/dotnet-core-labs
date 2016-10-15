using Business;
using System;
using Xunit;

namespace BussinessNUnitTest
{
    public class ProductTest
    {
        private Product greenApple;

        //here change
        protected void SetUp()
        {
            greenApple = new Product("Apple", "green apple", DateTime.Now, 20, 25);
        }

        //!here change
        //Facts and theories. Facts should always be true, Theories might not.
        [Fact]
        public void When_ProductIsInstanciatedWithPrice20AndVat25_then_ComputeVatShouldReturn5()
        {
            SetUp();
            var result = greenApple.ComputeVat();

            Assert.Equal(result, 5);
        }

        [Fact]
        public void When_ProductIsInstanciatedWithStartDateToday_then_IsValidShouldReturnTrue()
        {
            SetUp();
            var result = greenApple.IsValid();

            Assert.Equal(result, true);
        }

        [Fact]
        public void When_ProductIsInstanciated_Then_VerifyAll()
        {
            SetUp();
            Assert.NotEqual(greenApple.Id, Guid.Empty);

            Assert.Equal(!String.IsNullOrEmpty(greenApple.Description), true);
            Assert.Equal(!String.IsNullOrEmpty(greenApple.Name), true);

            Assert.True(greenApple.Vat > 0);
            Assert.True(greenApple.Price > 0);
            Assert.Equal(greenApple.EndDate, DateTime.MinValue);
        }

        [Fact]
        public void When_ProductIsInstanciatedWithEndDateGreaterThenStartDate_Then_ShouldVerifyAll()
        {
            SetUp();
            greenApple.SetValability(DateTime.Now.AddDays(1));

            Assert.Equal(greenApple.EndDate.Date, DateTime.Now.AddDays(1).Date);
        }

        [Fact]
        public void When_ProductIsInstanciatedWithEndDateSmallerThenStartDate_Then_ShouldThrowException()
        {
            Product product = new Product("Apple", "green apple", DateTime.Now, 20, 25);

            //!here change
            Action action = () => product.SetValability(DateTime.Now.AddDays(-1));

            Assert.Throws<ArgumentException>(action);
        }
    }
}
