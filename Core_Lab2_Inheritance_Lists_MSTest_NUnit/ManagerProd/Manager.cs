using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessManager
{
    public class Manager : Employee
    {
        public Manager(string firstname, string lastname, DateTime startdate, int salary) : base(firstname, lastname, startdate, salary)
        {
        }

        public override string Salutation()
        {
            return "Hello, manager!";
        }
    }
}
