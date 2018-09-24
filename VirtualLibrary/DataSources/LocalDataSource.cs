﻿using System.Collections.Generic;
using VirtualLibrary.Data;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources
{
    class LocalDataSource : IDataSource
    {
        private IList<IBook> _books;
        private IList<IUser> _users;

        public LocalDataSource()
        {
            var booksSource = new BookListFromFile();
            var existingBooks = booksSource.GetBookList();
            _books = new List<IBook>();

            foreach (var book in existingBooks)
                _books.Add(book);

            _users = new List<IUser>();
        }

        public void AddBook(IBook book)
        {
            _books.Add(book);
        }

        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public IList<IBook> GetBookList()
        {
            return _books;
        }

        public IList<IUser> GetUserList()
        {
            return _users;
        }
    }
}
