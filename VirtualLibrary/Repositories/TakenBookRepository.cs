using System.Collections.Generic;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public class TakenBookRepository : IRepository<ITakenBook>
    {
        private IDataSource _dataSource;

        public TakenBookRepository(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Add(ITakenBook item)
        {
            _dataSource.AddTakenBook(item);
        }

        public void Remove(ITakenBook book)
        {
            _dataSource.RemoveTakenBook(book);
        }

        public IList<ITakenBook> GetList()
        {
            return _dataSource.GetTakenBookList();
        }
    }
}
