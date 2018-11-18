using Shared.View;
using System.Collections.Generic;

namespace VILIB.Repositories
{
    public interface IBookRepository : IRepository<IBook>
    {
        IList<IBook> GetTakenBooks();
        //bool TakeBook(IBook book);
        //bool ReturnBook(IBook book);
        IBook CheckForTakenBook(string code);
    }
}