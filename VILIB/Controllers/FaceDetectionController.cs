using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.WebPages;
using VILIB.Helpers;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FaceDetectionController : ApiController
    {
        private readonly CascadeClassifier _detection;
        private readonly int _faceImagesPerUser;

        public FaceDetectionController(string faceDetectionTrainingFileName, string faceImagesPerUser)
        {
            _faceImagesPerUser = Int32.Parse(faceImagesPerUser);
            _detection = new CascadeClassifier(
                new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UserInformation/" +
                                  System.Configuration
                                   .ConfigurationManager.AppSettings["faceDetectionTrainingFile"]))
                                  .ToString());
        }

        public async Task<HttpResponseMessage> Post()
        {
            int numberOfImagesWithFace = 0;
            var stream = await Request.Content.ReadAsStreamAsync();
            MemoryStream memStr = new MemoryStream();
            try
            {
                stream.CopyTo(memStr);
                stream.Close();
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
               return JsonResponse.JsonHttpResponse<Object>(null);
            }
            

        }
    }
}