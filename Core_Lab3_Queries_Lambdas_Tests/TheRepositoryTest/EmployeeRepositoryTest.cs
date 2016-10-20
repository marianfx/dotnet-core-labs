using BussinessManager;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheRepository;

namespace TheRepositoryTest
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private EmployeeRepository repo;

        [TestInitialize]
        public void SetUp()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Manager("1", "1", DateTime.Now, 1000),
                new Manager("2", "2", DateTime.Now, 2000),
                new Manager("3", "3", DateTime.Now, 3000),
                new Architect("4", "4", DateTime.Now, 4000),
                new Architect("5", "5", DateTime.Now, 5000),
                new Manager("6", "6", DateTime.Now, 6000),
                new Manager("7", "7", DateTime.Now, 7000),
                new Manager("8", "8", DateTime.Now, 8000),
                new Manager("9", "9", DateTime.Now, 9000),
                new Manager("10", "10", DateTime.Now, 10000)
            };

            repo = new EmployeeRepository(employees, Style.Query);
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        public EmployeeRepository CreateSUT(Style style = Style.Query)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Manager("1", "1", DateTime.Now, 1000),
                new Manager("2", "2", DateTime.Now, 2000),
                new Manager("3", "3", DateTime.Now, 3000),
                new Architect("4", "4", DateTime.Now, 4000),
                new Architect("5", "5", DateTime.Now, 5000),
                new Manager("6", "6", DateTime.Now, 6000),
                new Manager("7", "7", DateTime.Now, 7000),
                new Manager("8", "8", DateTime.Now, 8000),
                new Manager("9", "9", DateTime.Now, 9000),
                new Manager("10", "10", DateTime.Now, 10000)
            };

            return new EmployeeRepository(employees, style);
        }

        [TestMethod]
        public void When_RepoIsInstanciated_Then_ShouldCountTenAndNotBeNull()
        {
            EmployeeRepository repo = CreateSUT();

            repo.Should().NotBeNull();
            repo.Employees.Should().NotBeNullOrEmpty();

            Employee em = repo.Employees.ElementAt(0);
            em.Should().NotBeNull();
            em.Id.Should().NotBeEmpty();
            em.FirstName.Should().NotBeNullOrEmpty();
            em.LastName.Should().NotBeNullOrEmpty();
            em.Salary.Should().BeGreaterThan(0);
            em.StartDate.Should().NotBeBefore(em.EndDate);
        }

        [TestMethod]
        public void When_RepoIsInstanciated_Then_ShouldReturnTwoArchitects()
        {
            var result = repo.RetrieveArchitects();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(2);
        }

        [TestMethod]
        public void When_RepoIsInstanciated_Then_ShouldReturnEightManagers()
        {
            EmployeeRepository repo = CreateSUT();

            var result = repo.RetrieveManagers();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(8);

            Employee em = repo.Employees.ElementAt(0);
            em.Should().BeOfType<Manager>();
        }
        
        [TestMethod]
        public void When_RepoIsInstanciated_Then_ShouldReturnAllActiveEmployees()
        {
            EmployeeRepository repo = CreateSUT();

            var result = repo.RetrieveActiveEmployees();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(10);

            Employee em = repo.Employees.ElementAt(0);
            em.isValid().Should().BeTrue();
        }

        [TestMethod]
        public void When_RepoIsInstanciated_Then_ShouldReturnAllOrderedDescBySalary()
        {
            EmployeeRepository repo = CreateSUT();

            var result = repo.RetrieveAllOrderBySalaryDescending();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(10);

            Employee first = result.ElementAt(0);
            Employee last = result.ElementAt(result.Count() - 1);
            first.FirstName.Should().Be("10");
            last.FirstName.Should().Be("1");
        }

        [TestMethod]
        public void When_RepoIsInstanciated_Then_ShouldReturnAllOrderedAscBySalary()
        {
            EmployeeRepository repo = CreateSUT();

            var result = repo.RetrieveAllOrderBySalaryAscending();
            result.Should().NotBeEmpty();
            result.Count().Should().Be(10);

            Employee first = result.ElementAt(0);
            Employee last = result.ElementAt(result.Count() - 1);
            first.FirstName.Should().Be("1");
            last.FirstName.Should().Be("10");
        }

        [TestMethod]
        public void When_RepoIsInstanciated_Then_AllByName_ShouldReturnEmptyList()
        {
            EmployeeRepository repo = CreateSUT();

            var result = repo.RetrieveAll("Marian");
            result.Should().BeEmpty();
        }

        [TestMethod]
        public void When_RepoIsInstanciated_Then_AllByName_ShouldReturnOne()
        {
            EmployeeRepository repo = CreateSUT();

            var result = repo.RetrieveAll("1 1");
            result.Should().NotBeEmpty();
            result.Count().Should().Be(1);
            result.ElementAt(0).GetFullName().Should().Be("1 1");
        }

        [TestMethod]
        public void When_RepoIsInstanciated_Then_AllByDate_ShouldReturnAll()
        {
            EmployeeRepository repo = CreateSUT();

            DateTime startDate = DateTime.Now;
            startDate.AddDays(-1);
            var result = repo.RetrieveAll(startDate, DateTime.MinValue);
            result.Should().NotBeEmpty();
            result.Count().Should().Be(10);

            Employee em = repo.Employees.ElementAt(0);
            em.StartDate.Should().BeOnOrAfter(startDate);
            em.EndDate.Should().BeOnOrBefore(DateTime.MinValue);
        }
    }
}
