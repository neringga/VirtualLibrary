using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.DataSources;
using VILIB.FaceRecognision;
using VILIB.Helpers;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImageSavingController : ApiController
    {
        private readonly IAsyncDataSource _dataSource;

        public ImageSavingController(IAsyncDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<HttpResponseMessage> Put()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var imageFromFrontend = JsonConvert.DeserializeObject<FaceImage>(jsonContent);

            try
            {
                Random random = new Random();
                MemoryStream streamM = new MemoryStream(imageFromFrontend.Bytes);
                string fileName = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UserInformation/" +
                                     imageFromFrontend.Nickname + "_" + random.Next() + ".png")).ToString();
                new Bitmap(streamM).Save(fileName);
                //await _dataSource.AddFaceImage(imageFromFrontend);
                return JsonResponse.JsonHttpResponse<Object>(fileName);
            }
            catch (Exception e)
            {
                return JsonResponse.JsonHttpResponse<Object>(null);
            }


        }
    }
}