using Shared.View;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using System.Web.Mvc;
using VILIB.Repositories;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookSearchController : ApiController
    {
        private IBookRepository _bookRepository;
        public BookSearchController(IBookRepository bookRepo)
        {
            _bookRepository = bookRepo;
        }

        public async Task<IList<IBook>> Get()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var searchParams = JsonConvert.DeserializeObject<BookSearchParams>(jsonContent);
            return GetBooksThatMatchKeyword(searchParams.Keyword);
        }

        private IList<IBook> GetBooksThatMatchKeyword(string keyword)
        {
            IList<IBook> booksToReturn = new List<IBook>();
            IList<IBook> allBooks = _bookRepository.GetList();
            foreach (var book in allBooks)
            {
                if (book.Author.Contains(keyword) || book.Title.Contains(keyword))
                {
                    booksToReturn.Add(book);
                }
            }

            return booksToReturn;
        }
    }

    public class BookSearchParams
    {
        public string Keyword { get; set; }
    }
}