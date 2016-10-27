using Core_Lab4_Db_Intro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core_Lab4_Db_Intro
{
    public abstract class Repository<T>: IRepository<T>
        where T : IdAble
    {
        protected readonly ProductManagement context;
        public Repository(ProductManagement pm)
        {
            context = pm;
        }

        public void Create(T p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void Update(T p)
        {
            context.Update(p);
            context.SaveChanges();
        }

        public void Delete(T p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

        public IEnumerable<T> GetById(Guid id)
        {
            var queryResult = from R in context.Set<T>()
                                where R.Id == id
                                select R;

            return queryResult;
        }

        public IEnumerable<T> GetAll()
        {
            var queryResult = from R in context.Set<T>()
                                select R;

            return queryResult;
        }
    }
}
