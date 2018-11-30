using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.Helpers;
using VILIB.Presenters;
using User = VILIB.Model.User;

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

        public async Task<HttpResponseMessage> Post()
        {
            HttpContent requestContent = Request.Content;
            //string jsonContent = await requestContent.ReadAsStringAsync();
            var user = await requestContent.ReadAsStringAsync();
            try
            {
                var list = _takenBookPresenter.GetUserTakenBooks(user);
                return JsonResponse.JsonHttpResponse<object>(list);
            }
            catch (ArgumentNullException)
            {
                return JsonResponse.JsonHttpResponse<object>(null);
            }
            //return new HttpResponseMessage
            //{
            //    Content = new StringContent(JsonConvert.SerializeObject(_takenBookPresenter.GetTakenBooks()),
            //        System.Text.Encoding.UTF8, "application/json")
            //};
        }



        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Code>(jsonContent);

            if (!_takenBookPresenter.IsTaken(data.isbnCode))
            {
                var takenBook = _takenBookPresenter.AddTakenBook(data.isbnCode, data.user);
                return JsonResponse.JsonHttpResponse<object>(takenBook.HasToBeReturned);
            }
            return JsonResponse.JsonHttpResponse<object>(false);
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
            return JsonResponse.JsonHttpResponse(_bookPresenter.GetNotTakenBooks());
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
            var data = JsonConvert.DeserializeObject<Code>(jsonContent);
            try
            {
                var takenBook = _takenBookPresenter.FindTakenBookByCode(data.isbnCode,
                    data.user);
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
