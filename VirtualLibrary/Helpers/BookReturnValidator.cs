using System;
using System.Linq;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    public class BookReturnValidator
    {
        private readonly BookRepository _bookRepository = new BookRepository(StaticDataSource.DataSource);

        public IBook TakenBookListCheckForBook(string code)
        {
            var takenBooks = _bookRepository.GetTakenBooks();
            return takenBooks.FirstOrDefault(book => book.Code == code && book.TakenByUser == StaticDataSource.CurrUser && book.HasToBeReturned >= DateTime.Now);
        }
    }
}