using System.Collections.Generic;

namespace VirtualLibrary.Repositories
{
    interface IRepository<T>
    {
        IList<T> GetList();
        void Add(T item);
    }
}
