
using System;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    internal class BookReturnValidator
    {
        private readonly BookRepository _bookRepository = new BookRepository(StaticDataSource.DataSource);

        public IBook TakenBookListCheckForBook(string code)
        {
            var takenBooks = _bookRepository.GetTakenBooks();
            foreach (var book in takenBooks)
            {
                if (book.Code == code && book.TakenByUser == StaticDataSource.CurrUser &&
                    book.HasToBeReturned >= DateTime.Now)
                    return book;
            }

            return null;
        }
    }
}