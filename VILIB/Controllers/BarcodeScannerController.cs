using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Shared.View;
using VILIB.Helpers;
using VILIB.Presenters;

namespace VILIB.Controllers
{
    [EnableCors("*", "*", "*")]
    public class BarcodeScannerController : ApiController
    {
        private IBook _book;
        private readonly BookPresenter _bookPresenter;
        private ScannerPresenter _scannerPresenter;
        private TakenBookPresenter _takenBookPresenter;

        public BarcodeScannerController(TakenBookPresenter takenBookPresenter, BookPresenter bookPresenter,
            ScannerPresenter scannerPresenter)
        {
            _takenBookPresenter = takenBookPresenter;
            _bookPresenter = bookPresenter;
            _scannerPresenter = scannerPresenter;
        }

        public async Task<HttpResponseMessage> Put()
        {
            var requestContent = Request.Content;
            var jsonContent = await requestContent.ReadAsStringAsync();
            var isbn = JsonConvert.DeserializeObject<Code>(jsonContent);

            _book = _bookPresenter.FindBookByCode(isbn.isbnCode);
            if (_book != null)
                return JsonResponse.JsonHttpResponse<object>(_book);
            return JsonResponse.JsonHttpResponse<object>(null);
        }
    }
}