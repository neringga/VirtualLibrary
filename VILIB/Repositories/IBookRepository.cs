using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.View;

namespace VILIB.Repositories
{
    public interface IBookRepository : IRepository<IBook>
    {
        IList<IBook> GetTakenBooks();
        Task TakeBook(string isbnCode, string username);
        Task ReturnBook(string isbnCode, string username);
        IBook CheckForTakenBook(string code);
    }
}