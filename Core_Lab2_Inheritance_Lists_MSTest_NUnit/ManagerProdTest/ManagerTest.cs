using BussinessManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerProdTest
{
    [TestClass]
    public class ManagerTest
    {
        public Manager CreateSUT()
        {
            return new Manager("Mister", "Coder", DateTime.Now, 1000);
        }

        [TestMethod]
        public void When_ManagerIsInstanciated_Then_SalutationShouldReturnManager()
        {
            Manager architect = CreateSUT();

            string result = architect.Salutation();
            Assert.AreEqual(result, "Hello, manager!");
        }
    }
}
