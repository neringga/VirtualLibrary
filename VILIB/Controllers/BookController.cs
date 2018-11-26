using Newtonsoft.Json;
using Shared.View;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.DataSources.Data;
using VILIB.Helpers;
using VILIB.Model;
using VILIB.Presenters;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TakenBookController : ApiController
    {
        private TakenBookPresenter _takenBookPresenter;
        private BookPresenter _bookPresenter;
        private ScannerPresenter _scannerPresenter;
        private IBook _book;

        public TakenBookController(TakenBookPresenter takenBookPresenter, BookPresenter bookPresenter,
                                    ScannerPresenter scannerPresenter)
        {
            _takenBookPresenter = takenBookPresenter;
            _bookPresenter = bookPresenter;
            _scannerPresenter = scannerPresenter;
        }

        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(_takenBookPresenter.GetTakenBooks()),
                    System.Text.Encoding.UTF8, "application/json")
            };
        }



        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<Book>(jsonContent);

            if (!book.IsTaken) //TODO book check
            {
                var takenBook = _takenBookPresenter.AddTakenBook((IBook)book, "ner"); //TODO user authentification
                return JsonResponse.JsonHttpResponse<Object>(takenBook.HasToBeReturned);
            }
            return JsonResponse.JsonHttpResponse<Object>(false);
        }


    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookController : ApiController
    {
        private BookPresenter _bookPresenter;

        public BookController(BookPresenter bookPresenter)
        {
            _bookPresenter = bookPresenter;
        }

        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(_bookPresenter.GetNotTakenBooks()),
                    System.Text.Encoding.UTF8, "application/json")
            };
        }


    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReturnBookController : ApiController
    {
        private TakenBookPresenter _takenBookPresenter;

        public ReturnBookController(TakenBookPresenter takenBookPresenter)
        {
            _takenBookPresenter = takenBookPresenter;
        }

        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var bookCode = JsonConvert.DeserializeObject<Code>(jsonContent);
            StaticDataSource.CurrUser = "ner"; //TODO user authentification
            try
            {
                var takenBook = _takenBookPresenter.FindTakenBookByCode(bookCode.isbnCode,
                    StaticDataSource.CurrUser);
                _takenBookPresenter.RemoveTakenBook(takenBook);
                return JsonResponse.JsonHttpResponse<Object>(true);
            }
            catch (Exception)
            {
                return JsonResponse.JsonHttpResponse<Object>(false);
            }

        }

    }

}
