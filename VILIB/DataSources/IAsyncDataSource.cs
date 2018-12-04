using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.View;

namespace VILIB.DataSources
{
    public interface IAsyncDataSource
    {
        string CurrUser { get; set; }
        IList<IBook> GetBookList();
        IList<IUser> GetUserList();
        IList<IBook> GetTakenBookList();
        IList<string> GetHashtagList();
        IList<string> GetGenreList();
        Task<int> RemoveUser(IUser user);
        Task<int> AddUser(IUser user);
        Task<int> RemoveBook(IBook book);
        Task<int> AddBook(IBook book);
        Task<int> RemoveTakenBook(IBook takenBook);
        Task<int> AddTakenBook(IBook takenBook);

        //TODO: decide which to keep - generic implementations or concrete
        Task<int> RemoveItem<T>(T item);
    }
}