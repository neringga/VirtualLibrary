﻿using System;
using System.Collections.Generic;
using System.Linq;
using VILIB.DataSources;
using VILIB.DataSources.Data;
using VILIB.View;

namespace VILIB.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDataSource _dataSource;

        public BookRepository(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Add(IBook item)
        {
            _dataSource.AddBook(item);
        }

        public void Remove(IBook item)
        {
            _dataSource.RemoveBook(item);
        }

        public IList<IBook> GetList()
        {
            return _dataSource.GetBookList();
        }

        public IList<IBook> GetTakenBooks()
        {
            return _dataSource.GetBookList().Where(book => book.IsTaken).ToList();
        }

        public bool TakeBook(IBook book) // NOT USED, TODO: implement
        {
            if (book.IsTaken)
                return false;

            book.IsTaken = true;
            return true;
        }

        public bool ReturnBook(IBook book) // NOT USED, TODO: implement
        {
            return false;
        }

        public IBook CheckForTakenBook(string code)
        {
            var takenBooks = GetTakenBooks();
            foreach (var book in takenBooks)
                if (book.Code == code && book.TakenByUser == StaticDataSource.CurrUser &&
                    book.HasToBeReturned >= DateTime.Now)
                    return book;

            return null;
        }
    }
}