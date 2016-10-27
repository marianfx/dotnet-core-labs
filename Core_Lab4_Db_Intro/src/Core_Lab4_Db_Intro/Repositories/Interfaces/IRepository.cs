using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Lab4_Db_Intro.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
