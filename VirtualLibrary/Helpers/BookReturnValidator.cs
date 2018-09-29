using System;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    class BookReturnValidator
    {
        private TakenBookRepository takenBookRepository = new TakenBookRepository(DataSources.Data.StaticDataSource._dataSource);

        public ITakenBook TakenBookListCheckForBook (string code)
        {
            var takenBooks = takenBookRepository.GetList();
            foreach (var book in takenBooks)
            {
                if (book.BookCode == code && book.User == DataSources.Data.StaticDataSource.currUser &&
                    book.HasToBeReturned >= DateTime.Now)
                {
                    return book;
                }
            }
            return null;
        } 
    }
}
