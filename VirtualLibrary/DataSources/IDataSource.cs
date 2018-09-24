using System.Collections.Generic;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources
{
    interface IDataSource
    {
        IList<IBook> GetBookList();
        IList<IUser> GetUserList();
        void AddUser(IUser user);
        void AddBook(IBook book);
    }
}
