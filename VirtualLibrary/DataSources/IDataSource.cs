using System.Collections.Generic;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources
{
    public interface IDataSource
    {
        IList<IBook> GetBookList();
        IList<IUser> GetUserList();
        IList<IBook> GetTakenBookList();
        void RemoveUser(IUser user);
        void AddUser(IUser user);
        void RemoveBook(IBook book);
        void AddBook(IBook book);
        void RemoveTakenBook(IBook takenBook);
        void AddTakenBook(IBook takenBook);
    }
}