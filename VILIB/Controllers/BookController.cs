using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.DataSources.Data;
using VILIB.Helpers;
using VILIB.Model;
using VILIB.Presenters;
using VILIB.View;

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

            if (!book.IsTaken)
            {
                var takenBook = _takenBookPresenter.AddTakenBook(book, "ner"); //TODO user authentification
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


}
