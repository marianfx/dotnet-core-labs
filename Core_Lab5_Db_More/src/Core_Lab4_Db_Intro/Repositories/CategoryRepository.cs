using Core_Lab5_Db_More.Models;
using Core_Lab5_Db_More.Repositories.Interfaces;

namespace Core_Lab5_Db_More.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductManagement pm) : base(pm)
        {
        }
    }
}
