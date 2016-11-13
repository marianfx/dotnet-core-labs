using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsProject.Services;

namespace WebFormsProjectTest
{
    [TestClass]
    public class PalindromTest
    {
        private PalindromTester palindromThatFails;
        private PalindromTester palindromThatPasses;

        [TestInitialize]
        public void SetUp()
        {
            palindromThatFails = new PalindromTester("abs");
            palindromThatPasses = new PalindromTester("aba");
        }

        [TestCleanup]
        public void TearDown()
        {
            palindromThatFails = palindromThatPasses = null;
        }

        [TestMethod]
        public void When_PalindromTesterIsInstanciatedWithNonPalindrome_SHouldReturnFalse()
        {
            Assert.AreEqual(palindromThatFails.IsItPalindrome(), false);
        }

        [TestMethod]
        public void When_PalindromTesterIsInstanciatedWithPalindrome_SHouldReturnTrue()
        {
            Assert.AreEqual(palindromThatPasses.IsItPalindrome(), true);
        }
    }
}
