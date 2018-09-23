using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.Model;
using VirtualLibrary.View;

namespace VirtualLibrary.Data
{
    class BookListFromFile
    {
        readonly System.IO.StreamReader file = new StreamReader(
            Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "BookList.txt"));
        private string line;
        private readonly string[] words;

        private List<IBook> bookList = new List<IBook>();

        public BookListFromFile ()
        {
            while ((line = file.ReadLine()) != null)
            {
                var book = new Book();
                words = line.Split(',');
                book.Title = words[0];
                book.Author = words[1];
                book.Code = words[2];
                bookList.Add(book);
            }
        }

        public IList<IBook> GetBookList ()
        {
            return bookList;
        }
    }
}
