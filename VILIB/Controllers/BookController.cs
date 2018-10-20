using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using VILIB.Presenters;
using VILIB.Repositories;
using VILIB.View;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TakenBookController : ApiController
    {
        private TakenBookPresenter _takenBookPresenter;
        private ILibraryData _libraryData;

        public TakenBookController(TakenBookPresenter takenBookPresenter, ILibraryData libraryData)
        {
            _takenBookPresenter = takenBookPresenter;
            _libraryData = libraryData;
        }

        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(_takenBookPresenter.GetTakenBooks()),
                    System.Text.Encoding.UTF8, "application/json")
            };
        }

        //public HttpResponseMessage Put(string bookCode)
        //{
       
        //}

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
