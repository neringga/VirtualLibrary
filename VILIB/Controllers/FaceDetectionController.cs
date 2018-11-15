using System;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using VILIB.DataSources.Data;
using VILIB.Helpers;
using VILIB.Model;

using Emgu.CV;
using Emgu.CV.Structure;
using System.Web.Http.Cors;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using System.Diagnostics;
using VILIB.View;
using System.Web.Hosting;
using System.Security.Cryptography;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FaceDetectionController : ApiController
    {
        private readonly CascadeClassifier _detection;
        private readonly int _faceImagesPerUser;
        private readonly IExceptionLogger _exceptionLogger;

        public FaceDetectionController(string faceDetectionTrainingFileName, int faceImagesPerUser, IExceptionLogger exceptionLogger)
        {
            _faceImagesPerUser = faceImagesPerUser;
            _exceptionLogger = exceptionLogger;

            _detection = new CascadeClassifier(
                new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UserInformation/" +
                "haarcascade_frontalface_alt2.xml")).ToString());
        }

        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
           
            };
        }


        public async Task<HttpResponseMessage> Post()
        {
            int numberOfImagesWithFace = 0;
            var lol = await Request.Content.ReadAsStreamAsync();
            MemoryStream memStr = new MemoryStream();
            try
            {
                lol.CopyTo(memStr);
                lol.Close();
                var bitmap = new Bitmap(memStr);
                var currentFrame = new Emgu.CV.Image<Bgr, Byte>(bitmap);
                Console.WriteLine(_detection);
                var face = _detection.DetectMultiScale(currentFrame, 1.2, 0);
                if (face.Length > 0)
                    return JsonResponse.JsonHttpResponse<Object>("Enough");
                else
                    return JsonResponse.JsonHttpResponse<Object>("Not Enough");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
            return JsonResponse.JsonHttpResponse<Object>(null);
            //var result = new HttpResponseMessage(HttpStatusCode.OK);
            //if (Request.Content.IsMimeMultipartContent())
            //{

            //}
            //else
            //{

            //}

            //var imagesInStrings = JsonConvert.DeserializeObject<string[]>(jsonContent);

            //for (int i = 0; i < lol.Length; i++)
            //{
            //    Image image = Image.FromStream(new MemoryStream(Convert.FromBase64String(imagesInStrings[i])));
            //    Image<Bgr, byte> bgrImage = new Image<Bgr, byte>(new Bitmap(image));
            //    var face = _detection.DetectMultiScale(bgrImage, 1.2, 0);

            //    if (face.Length > 0)
            //    {
            //        numberOfImagesWithFace++;
            //    }
            //}

            //if (numberOfImagesWithFace >= _faceImagesPerUser)
            //{
            //    return JsonResponse.JsonHttpResponse<Object>("Enough faces");
            //}
            //else
            //{
            //return JsonResponse.JsonHttpResponse<Object>("Not enough faces");
            //}
        }
    }
}