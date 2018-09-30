using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public interface IBookRepository : IRepository<IBook>
    {
        IList<IBook> getTakenBooks();
        bool TakeBook(IBook book);
        bool ReturnBook(IBook book);
    }
}
