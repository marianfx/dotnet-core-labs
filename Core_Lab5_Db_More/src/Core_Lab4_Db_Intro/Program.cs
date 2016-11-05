namespace Core_Lab5_Db_More
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProductManagementService service = new ProductManagementService();
            service.ExecuteAll();
        }
    }
}
