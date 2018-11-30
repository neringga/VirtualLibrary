using System;
using System.Collections.Generic;
using System.Linq;
using Shared.View;
using VILIB.DataSources.Data;
using VILIB.Model;
using VILIB.Repositories;

namespace VILIB.Presenters
{
    public class TakenBookPresenter
    {
        private readonly IBookRepository _mBookRepository;
        private readonly IBook _takenBook = new Book();

        public TakenBookPresenter(IBookRepository bookRepository)
        {
            _mBookRepository = bookRepository;
        }

        public IBook AddTakenBook(string isbnCode, string username)
        {
            _takenBook.IsTaken = true;
            _takenBook.TakenByUser = username;
            _takenBook.Code = isbnCode;
            _takenBook.TakenWhen = DateTime.Now;

            var books = _mBookRepository.GetList();
            var book = books.First(item => item.Code == _takenBook.Code);

            _takenBook.Author = book.Author;
            _takenBook.Title = book.Title;
            _takenBook.HasToBeReturned = ((DateTime) _takenBook.TakenWhen).AddDays(book.DaysForBorrowing);
            _mBookRepository.Add(_takenBook);

            return _takenBook;
        }

        public List<IBook> FindUserTakenBooks()
        {
            return (List<IBook>) _mBookRepository.GetTakenBooks().Where(
                book => book.TakenByUser == StaticDataSource.CurrUser);
        }

        public IBook FindTakenBookByCode(string code, string user)
        {
            var books = _mBookRepository.GetTakenBooks();
            foreach (var book in books)
                if (book.Code == code)
                    return book;
            return null;
        }

        public bool IsTaken(string code)
        {
            var books = _mBookRepository.GetTakenBooks().FirstOrDefault(book => book.Code == code);
            return books != null;
        }


        public void RemoveTakenBook(IBook takenBook)
        {
            _mBookRepository.Remove(takenBook);
        }

        public IList<IBook> GetTakenBooks()
        {
            return _mBookRepository.GetTakenBooks();
        }

        public List<IBook> GetUserTakenBooks(string user)
        {
            var list = new List<IBook>();
            //var a = _mBookRepository.GetTakenBooks().Where(book => book.TakenByUser == user);
            var b = _mBookRepository.GetTakenBooks();
            foreach (var a in b)
                if (a.TakenByUser == user)
                    list.Add(a);
            return list;
        }
    }
}