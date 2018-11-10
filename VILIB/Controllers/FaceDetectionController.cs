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

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FaceDetectionController : ApiController
    {
        private readonly CascadeClassifier _detection;
        private readonly int _faceImagesPerUser;
        private readonly IExceptionLogger _exceptionLogger;

        //public FaceDetectionController(string faceDetectionTrainingFileName, int faceImagesPerUser, IExceptionLogger exceptionLogger)
        //{
        //    _faceImagesPerUser = faceImagesPerUser;
        //    _exceptionLogger = exceptionLogger;

        //    //_detection = new CascadeClassifier(faceDetectionTrainingFileName);
        //}

        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
           
            };
        }


        public async Task<HttpResponseMessage> Post(string base64image)
        {
            var bytes = Convert.FromBase64String(base64image);
            return JsonResponse.JsonHttpResponse<Object>("Good");
            //for (int i = 0; i < image.Length; i++)
            //{
            //Image image = Image.FromStream(new MemoryStream(Convert.FromBase64String(imagesInStrings[i])));
            //    Image<Bgr, byte> bgrImage = new Image<Bgr, byte>(new Bitmap(image));
            //    var face = _detection.DetectMultiScale(bgrImage, 1.2, 0);

            //    if (face.Length > 0)
            //    {
            //        numberOfImagesWithFace++;
            //}
            //}

            //if (numberOfImagesWithFace >= _faceImagesPerUser)
            //{
            //    return JsonResponse.JsonHttpResponse<Object>("Enough faces");
            //}
            //else
            //{
            //    return JsonResponse.JsonHttpResponse<Object>("Not enough faces");
            //}
        }
    }
}