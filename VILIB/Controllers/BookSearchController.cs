using Shared.View;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using VILIB.Repositories;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

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

        public async Task<IList<IBook>> Post()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var searchParams = JsonConvert.DeserializeObject<BookSearchParams>(jsonContent);

            var booksToReturn = new List<IBook>();
            var allBooks = _bookRepository.GetList();

            return allBooks
                .Where(book =>
                    ApplyGenreFilter(book, searchParams.Genre) &&
                    ApplyHastagFilter(book, searchParams.Hashtags) &&
                    ApplyKeywordFilter(book, searchParams.Keyword))
                .ToList();
        }

        private bool ApplyKeywordFilter(IBook book, string keyword)
        {
            if (keyword == null) return true;

            return book.Author.Contains(keyword) || book.Title.Contains(keyword);
        }

        private bool ApplyGenreFilter(IBook book, string genre)
        {
            if (genre == null) return true;

            return book.Genre == genre;
        }

        private bool ApplyHastagFilter(IBook book, IList<string> hashtags)
        {
            if (hashtags == null || hashtags.Count == 0) return true;

            foreach (var h in hashtags)
                if (!book.Hashtags.Contains(h)) return false;

            return true;
        }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GenreController : ApiController
    {
        private IRepository<string> _genreRepo;
        public GenreController(IRepository<string> genreRepo)
        {
            _genreRepo = genreRepo;
        }

        public IList<string> Get()
        {
            return _genreRepo.GetList();
        }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HashtagController : ApiController
    {
        private IRepository<string> _hashtagRepo;
        public HashtagController(IRepository<string> hashtagRepo)
        {
            _hashtagRepo = hashtagRepo;
        }

        public IList<string> Get()
        {
            return _hashtagRepo.GetList();
        }
    }

    public class BookSearchParams
    {
        public string Keyword { get; set; }
        public IList<string> Hashtags { get; set; }
        public string Genre { get; set; }
    }
}