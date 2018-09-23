using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    class BookRepository : IRepository<IBook>
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

        public IList<IBook> GetList()
        {
            return _dataSource.GetBookList();
        }
    }
}
