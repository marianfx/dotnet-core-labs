using Core_Lab4_Db_Intro;
using Core_Lab4_Db_Intro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceUser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductManagement pm = new ProductManagement();
            ICustomerRepository repo = new CustomerRepository(pm);
            
        }
    }
}
