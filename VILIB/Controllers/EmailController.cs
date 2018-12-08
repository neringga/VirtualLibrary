using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Shared.View;
using VILIB.Helpers;
using VILIB.Model;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmailController : ApiController
    {
        public EmailController() { }
        public HttpResponseMessage Get()
        {
            var b = new Book();
            var e = new BookTakingWarning();
            b.Title = "a";
            b.Author = "b";
            b.HasToBeReturned = DateTime.Today;
            try
            {
                e.SendWarningEmail("geigalaite@gmail.com", (IBook) b);
                return JsonResponse.JsonHttpResponse("ok");
            }
            catch (Exception)
            {
                return JsonResponse.JsonHttpResponse("ne ok");
            }
            
        }
    }
}