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
        private readonly IAsyncDataSource _dataSource;

        public BookRepository(IAsyncDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<int> Add(IBook item)
        {
            return await _dataSource.AddBook(item);
        }

        public async Task<int> Remove(IBook item)
        {
            return await _dataSource.RemoveBook(item);
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

        public async Task TakeBook(string isbnCode, string username)
        {
            await _dataSource.TakeBook(isbnCode, username);
        }

        public async Task ReturnBook(string isbnCode, string username)
        {
            await _dataSource.ReturnBook(isbnCode, username);
        }
    }
}