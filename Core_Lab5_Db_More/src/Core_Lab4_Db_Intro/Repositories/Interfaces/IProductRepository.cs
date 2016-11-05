namespace Core_Lab5_Db_More.Repositories.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        Product GetProductByPrice(int price);
    }
}
