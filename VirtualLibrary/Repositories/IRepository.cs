using System.Collections.Generic;

namespace VirtualLibrary.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetList();  //Generic type List 
        void Add(T item);
        void Remove(T item);
    }
}
