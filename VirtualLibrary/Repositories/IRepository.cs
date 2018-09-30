using System.Collections.Generic;

namespace VirtualLibrary.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetList();  
        void Add(T item);
        void Remove(T item);
    }
}
