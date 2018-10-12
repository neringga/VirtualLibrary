using System;
using System.Collections.Generic;
using System.Linq;
using VirtualLibrary.Model;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Presenters
{
    public class TakenBookPresenter
    {
        private readonly IBookRepository _mBookRepository;
        private readonly IBook _takenBook = new Book();

        public TakenBookPresenter(IBookRepository bookRepository)
        {
            _mBookRepository = bookRepository;
        }

        public void AddTakenBook(IBook view, string username)
        {
            _takenBook.IsTaken = true;
            _takenBook.TakenByUser = username;
            _takenBook.Code = view.Code;
            _takenBook.TakenWhen = DateTime.Now;

            var books = _mBookRepository.GetList();
            var book = books.First(item => item.Code == _takenBook.Code);

            _takenBook.HasToBeReturned = _takenBook.TakenWhen.AddDays(book.DaysForBorrowing);
            _mBookRepository.Add(_takenBook);
        }


        public void RemoveTakenBook(IBook takenBook)
        {
            _mBookRepository.Remove(takenBook);
        }

        public IList<IBook> GetTakenBooks()
        {
            return _mBookRepository.GetTakenBooks();
        }
    }
}