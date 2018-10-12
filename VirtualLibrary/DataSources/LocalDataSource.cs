using System.Collections.Generic;
using System.Linq;
using VirtualLibrary.Data;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources
{
    internal class LocalDataSource : IDataSource
    {
        private readonly IList<IBook> _books;
        private readonly IList<IUser> _users;

        public LocalDataSource()
        {
            var booksSource = new BookList();
            var existingBooks = booksSource.GetBookList();
            _books = new List<IBook>();

            foreach (var book in existingBooks)
                _books.Add(book);

            _users = new List<IUser>();
        }

        public string CurrUser { get; set; }

        public void AddBook(IBook book)
        {
            _books.Add(book);
        }

        public void AddTakenBook(IBook takenBook)
        {
            _books.Add(takenBook);
        }

        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public IList<IBook> GetBookList()
        {
            return _books;
        }

        public IList<IBook> GetTakenBookList()
        {
            return _books.Where(book => book.IsTaken).ToList();
        }

        public IList<IUser> GetUserList()
        {
            return _users;
        }

        public void RemoveUser(IUser user)
        {
            _users.Remove(user);
        }

        public void RemoveBook(IBook book)
        {
            _books.Remove(book);
        }

        public void RemoveTakenBook(IBook takenBook)
        {
            _books.Remove(takenBook);
        }
    }
}