using Core_Lab4_Db_Intro.Repositories.Interfaces;
using System.Linq;

namespace Core_Lab4_Db_Intro
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
