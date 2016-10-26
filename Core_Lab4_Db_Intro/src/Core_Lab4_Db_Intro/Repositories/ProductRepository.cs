using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Lab4_Db_Intro
{
    public class ProductRepository: Repository<Product>
    {
        public Product GetProductByPrice(int price)
        {
            using (ProductManagement context = new ProductManagement())
            {
                var queryResult = (from P in context.Products
                                  where P.Price == price
                                  select P).FirstOrDefault();
                return queryResult;
            }
        }
    }
}
