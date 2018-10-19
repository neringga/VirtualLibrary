using System.Collections.Generic;
using VILIB.View;

namespace VILIB.Repositories
{
    public interface IBookRepository : IRepository<IBook>
    {
        IList<IBook> GetTakenBooks();
        bool TakeBook(IBook book);
        bool ReturnBook(IBook book);
        IBook CheckForTakenBook(string code);
    }
}