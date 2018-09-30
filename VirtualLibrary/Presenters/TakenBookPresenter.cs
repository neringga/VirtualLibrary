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
        private IBookRepository m_bookRepository;
        private IBook takenBook = new Book();

        public TakenBookPresenter(IBookRepository bookRepository)
        {
            m_bookRepository = bookRepository;
        }

        public void AddTakenBook(IBook view, string username)
        {
            takenBook.IsTaken = true;
            takenBook.TakenByUser = username;
            takenBook.Code = view.Code;
            takenBook.TakenWhen = DateTime.Now;

            var bookRepository = new BookRepository(DataSources.Data.StaticDataSource._dataSource);
            var books = bookRepository.GetList();
            var book = books.First(item => item.Code == takenBook.Code);

            takenBook.HasToBeReturned = takenBook.TakenWhen.AddDays(book.DaysForBorrowing);
            m_bookRepository.Add(takenBook);

        }


        public void RemoveTakenBook(IBook takenBook)
        {
            m_bookRepository.Remove(takenBook);
        }

        public IList<IBook> GetTakenBooks ()
        {
            return m_bookRepository.getTakenBooks();
        }
    }
}
