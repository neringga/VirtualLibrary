using System;
using System.Linq;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    class BookReturnValidator
    {
        private BookRepository _bookRepository = new BookRepository(DataSources.Data.StaticDataSource._dataSource);

        public IBook TakenBookListCheckForBook (string code)
        {
            var takenBooks = _bookRepository.getTakenBooks();
            foreach (var book in takenBooks)
            {
                if (book.Code == code && book.TakenByUser == DataSources.Data.StaticDataSource.currUser &&
                    book.HasToBeReturned >= DateTime.Now)
                {
                    return book;
                }
            }
            return null;
        } 
    }
}
