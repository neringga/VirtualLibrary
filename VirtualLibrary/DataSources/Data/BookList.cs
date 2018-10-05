using System.Collections.Generic;
using VirtualLibrary.Model;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources.Data
{
    public class BookList
    {
        private readonly List<IBook> _bookList = new List<IBook>();

        public BookList()
        {
            var textFile = new TextFile();
            var list = textFile.ReadTextFile(Constants.BookFile);
            foreach (var line in list)
            {
                var book = new Book();
                string[] words = line.Split(',');
                book.Title = words[0];
                book.Author = words[1];
                book.Code = words[2];
                book.DaysForBorrowing = int.Parse(words[3]);
                _bookList.Add(book);
            }
        }

        public IList<IBook> GetBookList()
        {
            return _bookList;
        }
    }
}