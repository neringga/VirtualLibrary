using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using VILIB.Helpers;
using VILIB.Presenters;

namespace VILIB.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TakenBookController : ApiController
    {
        private BookPresenter _bookPresenter;
        private ScannerPresenter _scannerPresenter;
        private readonly TakenBookPresenter _takenBookPresenter;

        public TakenBookController(TakenBookPresenter takenBookPresenter, BookPresenter bookPresenter,
            ScannerPresenter scannerPresenter)
        {
            _takenBookPresenter = takenBookPresenter;
            _bookPresenter = bookPresenter;
            _scannerPresenter = scannerPresenter;
        }

        public async Task<HttpResponseMessage> Post()
        {
            var requestContent = Request.Content;
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
        }


        public async Task<HttpResponseMessage> Put()
        {
            var requestContent = Request.Content;
            var jsonContent = await requestContent.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Code>(jsonContent);

            if (!_takenBookPresenter.IsTaken(data.isbnCode))
            {
                await _takenBookPresenter.TakeBook(data.isbnCode, data.user);
                try
                {
                    var returnDate = DateTime.UtcNow.AddDays(30);
                    var s = returnDate.ToString("MM/dd/yyyy");
                    return JsonResponse.JsonHttpResponse<object>(s);
                }
                catch (InvalidOperationException)
                {
                    return JsonResponse.JsonHttpResponse<object>(false);
                }


            }

            return JsonResponse.JsonHttpResponse<object>(false);
        }
    }

    [EnableCors("*", "*", "*")]
    public class BookController : ApiController
    {
        private readonly BookPresenter _bookPresenter;

        public BookController(BookPresenter bookPresenter)
        {
            _bookPresenter = bookPresenter;
        }

        public HttpResponseMessage Get()
        {
            return JsonResponse.JsonHttpResponse(_bookPresenter.GetNotTakenBooks());
        }
    }

    [EnableCors("*", "*", "*")]
    public class ReturnBookController : ApiController
    {
        private readonly TakenBookPresenter _takenBookPresenter;

        public ReturnBookController(TakenBookPresenter takenBookPresenter)
        {
            _takenBookPresenter = takenBookPresenter;
        }

        public async Task<HttpResponseMessage> Put()
        {
            var requestContent = Request.Content;
            var jsonContent = await requestContent.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Code>(jsonContent);
            try
            {
                await _takenBookPresenter.ReturnBook(data.isbnCode, data.user);
                return JsonResponse.JsonHttpResponse<object>(true);
            }
            catch (Exception)
            {
                return JsonResponse.JsonHttpResponse<object>(false);
            }
        }
    }
}