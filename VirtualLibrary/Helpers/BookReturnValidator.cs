
using System;
using VirtualLibrary.DataSources;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    public class BookReturnValidator
    {
        private IBookRepository br;
        private IDataSource ds;

        public BookReturnValidator(IBookRepository bookRepo, IDataSource data)
        {
            br = bookRepo;
            ds = data;
        }

        public IBook TakenBookListCheckForBook(string code)
        {
            var takenBooks = br.GetTakenBooks();
            foreach (var book in takenBooks)
            {
                if (book.Code == code && book.TakenByUser == ds.CurrUser &&
                    book.HasToBeReturned >= DateTime.Now)
                    return book;
            }

            return null;
        }
    }
}