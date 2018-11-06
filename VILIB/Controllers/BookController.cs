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

        //public async Task<HttpResponseMessage> Post()
        //{
        //    Dictionary<string, object> dict = new Dictionary<string, object>();
        //    try
        //    {

        //        var httpRequest = HttpContext.Current.Request;

        //        foreach (string file in httpRequest.Files)
        //        {
        //            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

        //            var postedFile = httpRequest.Files[file];
        //            if (postedFile != null && postedFile.ContentLength > 0)
        //            {

        //                int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

        //                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
        //                var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
        //                var extension = ext.ToLower();
        //                if (!AllowedFileExtensions.Contains(extension))
        //                {

        //                    var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

        //                    dict.Add("error", message);
        //                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
        //                }
        //                else if (postedFile.ContentLength > MaxContentLength)
        //                {

        //                    var message = string.Format("Please Upload a file upto 1 mb.");

        //                    dict.Add("error", message);
        //                    return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
        //                }
        //                else
        //                {

        //                    var filePath = HttpContext.Current.Server.MapPath("~/userImage/" + postedFile.FileName + extension);
        //                    postedFile.SaveAs(filePath);
        //                    var bookCode = _scannerPresenter.DecodedBarcode(filePath);
        //                    var book = _bookPresenter.FindBookByCode(bookCode);
        //                    var takenBook = _takenBookPresenter.AddTakenBook(book, StaticDataSource.CurrUser);
        //                    return JsonResponse.JsonHttpResponse<Object>(takenBook.HasToBeReturned);

        //                }
        //            }


        //        }
        //        var res = string.Format("Please Upload a image.");
        //        dict.Add("error", res);
        //        return Request.CreateResponse(HttpStatusCode.NotFound, dict);
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = string.Format("some Message");
        //        dict.Add("error", res);
        //        return Request.CreateResponse(HttpStatusCode.NotFound, dict);
        //    }
        //}

        //public async Task<HttpResponseMessage> Post()    //not tested
        //{
        //    HttpContent requestContent = Request.Content;
        //    string jsonContent = await requestContent.ReadAsStringAsync();
        //    var imageUrl = JsonConvert.DeserializeObject<Bitmap>(jsonContent);

        //    if (imageUrl != null)
        //    {
        //        var bookCode = _scannerPresenter.DecodeToText(imageUrl);
        //        var book = _bookPresenter.FindBookByCode(bookCode);

        //        var takenBook = _takenBookPresenter.AddTakenBook(book, StaticDataSource.CurrUser);
        //        return JsonResponse.JsonHttpResponse<Object>(takenBook.HasToBeReturned);
        //        //file.SaveAs(path);
        //    }

        //    return JsonResponse.JsonHttpResponse<Object>(null);
        //}

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
