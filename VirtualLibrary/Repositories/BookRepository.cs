using System.Collections.Generic;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public class BookRepository : IRepository<IBook>
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
    }
}
