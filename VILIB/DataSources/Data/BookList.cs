using Shared.View;
using System;
using System.Collections.Generic;
using VILIB.DataSources.Data;
using VILIB.Model;

namespace VILIB.Data
{
    public class BookList
    {
        private readonly Lazy<List<IBook>> _bookList = new Lazy<List<IBook>>( ()=> new List<IBook>() );
        public BookList()
        {
            var textFile = new TextFile();
            var list = textFile.ReadTextFile(
                System.Configuration.ConfigurationManager.AppSettings["books"]);

            foreach (var line in list)
            {
                var book = new Book() ;
                var words = line.Split(',');
                book.Title = words[0];
                book.Author = words[1];
                book.Code = words[2];
                book.DaysForBorrowing = int.Parse(words[3]);
                _bookList.Value.Add(book);
            }
        }

        public IList<IBook> GetBookList()
        {
            return _bookList.Value;
        }
    }
}