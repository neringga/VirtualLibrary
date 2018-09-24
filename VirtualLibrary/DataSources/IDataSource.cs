using System.Collections.Generic;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources
{
    public interface IDataSource
    {
        IList<IBook> GetBookList();
        IList<IUser> GetUserList();
        void AddUser(IUser user);
        void AddBook(IBook book);
    }
}
