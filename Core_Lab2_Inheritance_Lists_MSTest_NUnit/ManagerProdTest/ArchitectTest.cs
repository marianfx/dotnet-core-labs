using BussinessManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerProdTest
{
    [TestClass]
    public class ArchitectTest
    {

        public Architect CreateSUT()
        {
            return new Architect("Mister", "Coder", DateTime.Now, 1000);
        }

        [TestMethod]
        public void When_ArchitectIsInstanciatedWith1000SalaryAndCurrentDate_Then_ShouldReturnValid()
        {
            Architect architect = CreateSUT();

            bool result = architect.isValid();
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void When_ArchitectIsInstanciatedWithName_MarianFX_Then_ShouldReturnFullName()
        {
            Architect architect = CreateSUT();

            string result = architect.GetFullName();
            Assert.AreEqual(result, "Mister Coder");
        }

        [TestMethod]
        public void When_ArchitectIsInstanciated_Then_VerifyALl()
        {
            Architect architect = CreateSUT();

            Guid guid = architect.Id;
            Assert.AreNotEqual(guid, Guid.Empty);

            string firstname = architect.FirstName;
            Assert.AreEqual(firstname, "Mister");

            string lastname = architect.LastName;
            Assert.AreEqual(lastname, "Coder");

            DateTime startdate = architect.EndDate;
            Assert.AreEqual(startdate.Date, DateTime.MinValue.Date);
        }

        [TestMethod]
        public void When_ArchitectIsInstanciated_Then_SalutationShouldReturnArchitect()
        {
            Architect architect = CreateSUT();

            string result = architect.Salutation();
            Assert.AreEqual(result, "Hello, architect!");
        }

    }
}
