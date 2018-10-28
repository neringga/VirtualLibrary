using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.DataSources.Data;
using VILIB.Presenters;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TakenBookController : ApiController
    {
        private TakenBookPresenter _takenBookPresenter;
        private BookPresenter _bookPresenter;
        private ScannerPresenter _scannerPresenter;

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

        public HttpResponseMessage Put(HttpPostedFileBase file)    //not tested
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads"), fileName);
                var decodedCode = _scannerPresenter.DecodedBarcode(path);
                var book = _bookPresenter.FindBookByCode(decodedCode.Text);
                var takenBook = _takenBookPresenter.AddTakenBook(book, StaticDataSource.CurrUser);
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(takenBook.HasToBeReturned),
                        System.Text.Encoding.UTF8, "application/json")
                };
                //file.SaveAs(path);
            }

            return new HttpResponseMessage
            {

            };
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
