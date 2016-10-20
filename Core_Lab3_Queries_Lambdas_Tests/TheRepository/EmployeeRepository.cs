using System;
using BussinessManager;
using System.Collections.Generic;
using System.Linq;

namespace TheRepository
{
    public enum Style { Query, Method }

    public class EmployeeRepository
    {
        public IEnumerable<Employee> Employees { get; set; }
        public Style Style { get; set; }

        public EmployeeRepository(IEnumerable<Employee> employees, Style stail = Style.Query)
        {
            if (employees == null || employees.Count() == 0)
                Employees = CreateDefaultEmployees();
            else
                Employees = employees;

            Style = stail;
        }

        private IEnumerable<Employee> CreateDefaultEmployees()
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

            return employees;
        }
        
        
        public IEnumerable<Architect> RetrieveArchitects()
        {
            IEnumerable<Architect> queryResult = null;
            switch (Style)
            {
                case Style.Query:
                    queryResult = from A in Employees.OfType<Architect>()
                                  select A as Architect;
                    break;
                case Style.Method:
                    queryResult = Employees
                                    .OfType<Architect>();
                    break;
            }
            return queryResult;
        }
        
        public IEnumerable<Manager> RetrieveManagers()
        {
            IEnumerable<Manager> queryResult = null;

            switch (Style)
            {
                case Style.Query:
                    queryResult = from A in Employees.OfType<Manager>()
                                  select A as Manager;
                    break;
                case Style.Method:
                    queryResult = Employees
                                    .OfType<Manager>();
                    break;
            }
            return queryResult;
        }
        
        public IEnumerable<Employee> RetrieveActiveEmployees()
        {
            IEnumerable<Employee> queryResult = null;

            switch (Style)
            {
                case Style.Query:
                    queryResult = from A in Employees
                                  where A.isValid()
                                  select A;
                    break;
                case Style.Method:
                    queryResult = Employees
                                    .Where(em => em.isValid());
                    break;
            }
            return queryResult;
        }

        public IEnumerable<Employee> RetrieveAllOrderBySalaryDescending()
        {
            IEnumerable<Employee> queryResult = null;

            switch (Style)
            {
                case Style.Query:
                    queryResult = from A in Employees
                                  orderby A.Salary descending
                                  select A;
                    break;
                case Style.Method:
                    queryResult = Employees
                                    .OrderBy(em => em.Salary);
                    break;
            }
            return queryResult;
        }

        public IEnumerable<Employee> RetrieveAllOrderBySalaryAscending()
        {
            IEnumerable<Employee> queryResult = null;

            switch (Style)
            {
                case Style.Query:
                    queryResult = from A in Employees
                                  orderby A.Salary
                                  select A;
                    break;
                case Style.Method:
                    queryResult = Employees
                                    .OrderByDescending(em => em.Salary);
                    break;
            }
            return queryResult;
        }

        public IEnumerable<Employee> RetrieveAll(string name)
        {
            IEnumerable<Employee> queryResult = null;

            switch (Style)
            {
                case Style.Query:
                    queryResult = from A in Employees
                                  where A.GetFullName() == name
                                  select A;
                    break;
                case Style.Method:
                    queryResult = Employees
                                    .Where(em => em.GetFullName() == name);
                    break;
            }
            return queryResult;
        }

        public IEnumerable<Employee> RetrieveAll(DateTime startDate, DateTime endDate)
        {
            IEnumerable<Employee> queryResult = null;

            switch (Style)
            {
                case Style.Query:
                    queryResult = from A in Employees
                                  where A.StartDate >= startDate
                                     && A.EndDate <= endDate
                                  select A;
                    break;
                case Style.Method:
                    queryResult = Employees
                                    .Where(em => em.StartDate >= startDate && em.EndDate <= endDate);
                    break;
            }
            return queryResult;
        }
        
    }
}
