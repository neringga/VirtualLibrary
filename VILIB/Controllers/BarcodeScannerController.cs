using Newtonsoft.Json;
using Shared.View;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.Helpers;
using VILIB.Presenters;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BarcodeScannerController : ApiController
    {
        private TakenBookPresenter _takenBookPresenter;
        private BookPresenter _bookPresenter;
        private ScannerPresenter _scannerPresenter;
        private IBook _book;

        public BarcodeScannerController(TakenBookPresenter takenBookPresenter, BookPresenter bookPresenter,
            ScannerPresenter scannerPresenter)
        {
            _takenBookPresenter = takenBookPresenter;
            _bookPresenter = bookPresenter;
            _scannerPresenter = scannerPresenter;
        }
        public async Task<HttpResponseMessage> Post()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var isbnCode = JsonConvert.DeserializeObject<string>(jsonContent);

            _book = _bookPresenter.FindBookByCode(isbnCode);
            if (_book != null)
            {
                return JsonResponse.JsonHttpResponse<Object>(_book);
            }
            else
            {
                return JsonResponse.JsonHttpResponse<Object>(null);
            }
        }
    }
}
