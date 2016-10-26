using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Lab4_Db_Intro
{
    public abstract class Repository<T>
        where T: IdAble
    {
        public void Create(T p)
        {
            using (ProductManagement context = new ProductManagement())
            {
                context.Add(p);
                context.SaveChanges();
            }
        }

        public void Update(T p)
        {
            using (ProductManagement context = new ProductManagement())
            {
                context.Update(p);
                context.SaveChanges();
            }
        }

        public void Delete(T p)
        {
            using (ProductManagement context = new ProductManagement())
            {
                context.Remove(p);
                context.SaveChanges();
            }
        }

        public IEnumerable<T> GetById(Guid id)
        {
            using (ProductManagement context = new ProductManagement())
            {
                var queryResult = from R in context.Set<T>()
                                  where R.Id == id
                                  select R;

                return queryResult;
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (ProductManagement context = new ProductManagement())
            {
                var queryResult = from R in context.Set<T>()
                                  select R;

                return queryResult;
            }
        }
    }
}
