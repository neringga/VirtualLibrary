using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.View;
using VILIB.DataSources;
using VILIB.DataSources.Data;

namespace VILIB.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDataSource _dataSource;

        public BookRepository(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<int> Add(IBook item)
        {
            // INTERMMEDIATE IMPLEMENTATION. TODO: use database
            _dataSource.AddBook(item);
            return 1;
        }

        public async Task<int> Remove(IBook item)
        {
            // INTERMMEDIATE IMPLEMENTATION. TODO: use database
            _dataSource.RemoveBook(item);
            return 1;
        }


        public IList<IBook> GetList()
        {
            return _dataSource.GetBookList();
        }

        public IList<IBook> GetTakenBooks()
        {
            return _dataSource.GetBookList().Where(book => book.IsTaken).ToList();
        }


        public IBook CheckForTakenBook(string code)
        {
            var takenBooks = GetTakenBooks();
            foreach (var book in takenBooks)
                if (book.Code == code && book.TakenByUser == StaticDataSource.CurrUser &&
                    book.HasToBeReturned >= DateTime.Now)
                    return book;

            return null;
        }
    }
}