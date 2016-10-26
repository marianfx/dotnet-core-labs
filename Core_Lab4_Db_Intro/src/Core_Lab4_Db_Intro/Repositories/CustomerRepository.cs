using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Lab4_Db_Intro
{
    public class CustomerRepository: Repository<Customer>
    {
        public Customer GetCustomerByEmail(string email)
        {
            using (ProductManagement context = new ProductManagement())
            {
                var queryResult = (from C in context.Customers
                                   where C.Email == email
                                   select C).FirstOrDefault();
                return queryResult;
            }
        }
    }
}
