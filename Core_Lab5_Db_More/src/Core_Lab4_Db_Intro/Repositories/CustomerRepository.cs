using Core_Lab5_Db_More.Repositories.Interfaces;
using System.Linq;

namespace Core_Lab5_Db_More
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProductManagement pm) : base(pm)
        {
        }

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
