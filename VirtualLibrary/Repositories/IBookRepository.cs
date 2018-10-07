using System.Collections.Generic;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public interface IBookRepository : IRepository<IBook>
    {
        IList<IBook> GetTakenBooks();
        bool TakeBook(IBook book);
        bool ReturnBook(IBook book);
    }
}