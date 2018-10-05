using System;
using System.Collections.Generic;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Model;
using VirtualLibrary.View;

namespace VirtualLibrary.Data
{
    class BookList 
    {
        private List<IBook> _bookList = new List<IBook>();

        public BookList ()
        {
            TextFile textFile = new TextFile();
            var list = textFile.ReadTextFile(Constants.bookFile);
            string[] words;

            foreach (string line in list)
            {
                var book = new Book();
                words = line.Split(',');
                book.Title = words[0];
                book.Author = words[1];
                book.Code = words[2];
                book.DaysForBorrowing = Int32.Parse(words[3]);
                _bookList.Add(book);
            }
        }

        public IList<IBook> GetBookList ()
        {
            return _bookList;
        }
    }
}
