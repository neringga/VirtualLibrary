using System.Collections.Generic;
using System.Linq;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private IDataSource _dataSource;

        public BookRepository(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Add(IBook item)
        {
            _dataSource.AddBook(item);
        }

        public void Remove(IBook item)
        {
            _dataSource.RemoveBook(item);
        }

        public IList<IBook> GetList()
        {
            return _dataSource.GetBookList();
        }

        public IList<IBook> getTakenBooks()
        {
            return _dataSource.GetBookList().Where(book => book.IsTaken).ToList();
        }

        public bool TakeBook(IBook book) // NOT USED, TODO: implement
        {
            if (book.IsTaken)
                return false;

            book.IsTaken = true;
            return true;
        }

        public bool ReturnBook(IBook book) // NOT USED, TODO: implement
        {
            return false; 
        }
    }
}
