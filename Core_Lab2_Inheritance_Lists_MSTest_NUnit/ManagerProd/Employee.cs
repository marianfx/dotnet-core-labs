using System;

namespace BussinessManager
{
    public abstract class Employee
    {
        private const string SEP = " ";

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public int Salary { get; }

        public Employee(string firstname, string lastname, DateTime startdate, int salary)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
            StartDate = startdate;
            EndDate = DateTime.MinValue;
            Salary = salary;
        }

        public string GetFullName()
        {
            return string.Join(SEP, FirstName, LastName);
        }

        public bool isValid()
        {
            return EndDate.Subtract(StartDate).Seconds <= 0 && Salary > 0;
        }

        public abstract string Salutation();
    }
}
