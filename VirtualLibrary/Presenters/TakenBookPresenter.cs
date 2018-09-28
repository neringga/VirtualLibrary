using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.DataSources;
using VirtualLibrary.Helpers;
using VirtualLibrary.Model;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Presenters
{
    class TakenBookPresenter
    {
        //private ITakenBook takenBookView;
        private IRepository<ITakenBook> m_takenBookRepository;
        private TakenBook takenBook = new TakenBook();

        public TakenBookPresenter(IBook view, string username, IRepository<ITakenBook> takenBookRepository)
        {
            takenBook.User = username;
            takenBook.BookCode = view.Code;
            takenBook.Taken = DateTime.Now;
            //takenBookView.User = username;
            //takenBookView.BookCode = view.Code;
            //takenBookView.Taken = DateTime.Now;
            m_takenBookRepository = takenBookRepository;
        }

        public DateTime AddTakenBook()
        {
            var bookRepository = new BookRepository(DataSources.Data.StaticDataSource._dataSource);
            var books = bookRepository.GetList();
            var book = books.First(item => item.Code == takenBook.BookCode);

            takenBook.HasToBeReturned = takenBook.Taken.AddDays(book.DaysForBorrowing);
            m_takenBookRepository.Add(takenBook);

            return takenBook.HasToBeReturned;
        }


        public IList<ITakenBook> GetTakenBooks ()
        {
            return m_takenBookRepository.GetList();
        }
    }
}
