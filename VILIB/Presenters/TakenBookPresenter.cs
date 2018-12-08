using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task TakeBook(string isbnCode, string username)
        {
            await _mBookRepository.TakeBook(isbnCode, username);
        }

        public async Task ReturnBook(string isbnCode, string username)
        {
            await _mBookRepository.ReturnBook(isbnCode, username);
        }

        public List<IBook> FindUserTakenBooks()
        {
            return (List<IBook>)_mBookRepository.GetTakenBooks().Where(
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

        public IList<IBook> GetTakenBooks()
        {
            return _mBookRepository.GetTakenBooks();
        }

        public List<IBook> GetUserTakenBooks(string user)
        {
            var list = new List<IBook>();
            var b = _mBookRepository.GetTakenBooks();
            foreach (var a in b)
                if (a.TakenByUser == user)
                {
                    list.Add(a);
                }

            return list;
        }
    }
}