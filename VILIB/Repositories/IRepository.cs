using System.Collections.Generic;

namespace VILIB.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetList();
        void Add(T item);
        void Remove(T item);
    }
}