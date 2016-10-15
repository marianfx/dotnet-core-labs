using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinessManager
{
    public class Architect : Employee
    {
        public Architect(string firstname, string lastname, DateTime startdate, int salary) : base(firstname, lastname, startdate, salary)
        {
        }

        public override string Salutation()
        {
            return "Hello, architect!";
        }
    }
}
