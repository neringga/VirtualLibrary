using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources
{
    public interface IDataSource
    {
        IList<IBook> GetBookList();
        IList<IUser> GetUserList();
        void AddUser (IUser user);
        void AddBook (IBook book);
    }
}
