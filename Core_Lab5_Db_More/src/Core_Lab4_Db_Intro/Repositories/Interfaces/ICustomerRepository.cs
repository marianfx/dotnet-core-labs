namespace Core_Lab5_Db_More.Repositories.Interfaces
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer GetCustomerByEmail(string email);
    }
}
