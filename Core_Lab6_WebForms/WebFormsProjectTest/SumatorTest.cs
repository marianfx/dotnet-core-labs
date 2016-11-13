using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsProject.Services;

namespace WebFormsProjectTest
{
    [TestClass]
    public class SumatorTest
    {
        private Sumator sumator;

        [TestInitialize]
        public void SetUp()
        {
            sumator = new Sumator(2.0, 3.0, 4.0);
        }

        [TestCleanup]
        public void TearDown()
        {
            sumator = null;
        }

        [TestMethod]
        public void When_SumatorIsInstanciatedWithThreeNumbers_Then_ShouldReturnTheirSum()
        {
            Assert.AreEqual(sumator.GetSum(), 9);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void When_SumatorHasNoNumberList_Then_ShouldThrowException()
        {
            sumator.Numbers = null;
            var sum = sumator.GetSum();
        }
    }
}
