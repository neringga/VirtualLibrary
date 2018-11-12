using System.Collections.Generic;
using System.Threading.Tasks;

namespace VILIB.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetList();
        Task<int> Add(T item);
        Task<int> Remove(T item);
    }
}