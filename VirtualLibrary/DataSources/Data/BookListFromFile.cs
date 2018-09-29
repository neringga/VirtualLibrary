using System;
using System.Collections.Generic;
using System.IO;
using VirtualLibrary.Model;
using VirtualLibrary.View;

namespace VirtualLibrary.Data
{
    class BookListFromFile
    {
        readonly System.IO.StreamReader file = new StreamReader(
            Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "BookList.txt"));
        private string _line;
        private readonly string[] _words;
        private List<IBook> _bookList = new List<IBook>();

        public BookListFromFile ()
        {
            while ((_line = file.ReadLine()) != null)
            {
                var book = new Book();
                _words = _line.Split(',');
                book.Title = _words[0];
                book.Author = _words[1];
                book.Code = _words[2];
                book.DaysForBorrowing = Int32.Parse(_words[3]);
                _bookList.Add(book);
            }
        }

        public IList<IBook> GetBookList ()
        {
            return _bookList;
        }
    }
}
