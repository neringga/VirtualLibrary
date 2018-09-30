using System.Collections.Generic;
using System.Linq;
using VirtualLibrary.Data;
using VirtualLibrary.Model;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources
{
    class LocalDataSource : IDataSource
    {
        private IList<IBook> _books;
        private IList<IUser> _users;
        // private IList<ITakenBook> _takenBooks;

        public LocalDataSource()
        {
            var booksSource = new BookListFromFile();
            var existingBooks = booksSource.GetBookList();
            _books = new List<IBook>();

            foreach (var book in existingBooks)
                _books.Add(book);

            _users = new List<IUser>();
            //_takenBooks = new List<ITakenBook>();
        }

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
