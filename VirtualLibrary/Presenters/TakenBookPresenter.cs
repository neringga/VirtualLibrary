using System;
using System.Collections.Generic;
using System.Linq;
using VirtualLibrary.Model;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Presenters
{
    class TakenBookPresenter
    {
        private IRepository<ITakenBook> m_takenBookRepository;
        private TakenBook takenBook = new TakenBook();

        public TakenBookPresenter(IRepository<ITakenBook> takenBookRepository)
        {
            m_takenBookRepository = takenBookRepository;
        }

        public DateTime AddTakenBook(IBook view, string username)
        {
            takenBook.User = username;
            takenBook.BookCode = view.Code;
            takenBook.Taken = DateTime.Now;
            var bookRepository = new BookRepository(DataSources.Data.StaticDataSource._dataSource);
            var books = bookRepository.GetList();
            var book = books.First(item => item.Code == takenBook.BookCode);
            takenBook.HasToBeReturned = takenBook.Taken.AddDays(book.DaysForBorrowing);
            m_takenBookRepository.Add(takenBook);

            return takenBook.HasToBeReturned;
        }

        public void RemoveTakenBook(ITakenBook takenBook)
        {
            m_takenBookRepository.Remove(takenBook);
        }


        public IList<ITakenBook> GetTakenBooks ()
        {
            return m_takenBookRepository.GetList();
        }
    }
}
