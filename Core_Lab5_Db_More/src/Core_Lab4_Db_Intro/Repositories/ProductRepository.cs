using Core_Lab5_Db_More.Repositories.Interfaces;
using System.Linq;

namespace Core_Lab5_Db_More
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagement pm) : base(pm)
        {
        }

        public Product GetProductByPrice(int price)
        {
            var queryResult = (from P in context.Products
                                where P.Price == price
                                select P).FirstOrDefault();
            return queryResult;
        }
    }
}
