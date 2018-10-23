﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VILIB.Model;
using VILIB.Repositories;
using VILIB.View;

namespace VILIB.Presenters
{
    public class BookPresenter
    {
        private readonly IBookRepository _mBookRepository;

        public BookPresenter(IBookRepository bookRepository)
        {
            _mBookRepository = bookRepository;
        }

        public IEnumerable<IBook> GetNotTakenBooks()
        {
            return _mBookRepository.GetList().Where(book => book.IsTaken == false);
        }

        public IBook FindBookByCode(string code)
        {
            var books = _mBookRepository.GetList();
            if (books != null)
            {
                foreach (var book in books)
                {
                    if (book.Code.Equals(code))
                        return book;
                }
            }
            return null;
        }

    }
}