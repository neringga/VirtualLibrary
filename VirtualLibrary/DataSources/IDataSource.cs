using System.Collections.Generic;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources
{
    public interface IDataSource
    {
        IList<IBook> GetBookList();
        IList<IUser> GetUserList();
        IList<ITakenBook> GetTakenBookList();
        void AddUser(IUser user);
        void AddBook(IBook book);
        void AddTakenBook(ITakenBook takenBook);
    }
}
