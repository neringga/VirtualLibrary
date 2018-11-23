using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Text;
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
        private const int _grayFaceImageSize = 100;
        private const double _cascadePrecision = 1.1;

        private readonly CascadeClassifier _detection;

        public FaceDetectionController(string faceDetectionTrainingFileName)
        {
            _detection = new CascadeClassifier(
                new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UserInformation/" +
                                  System.Configuration
                                   .ConfigurationManager.AppSettings["faceDetectionTrainingFile"]))
                                  .ToString());
        }

        public async Task<HttpResponseMessage> Post()
        {
            var stream = await Request.Content.ReadAsStreamAsync();
            MemoryStream memStr = new MemoryStream();
            try
            {
                stream.CopyTo(memStr);
                stream.Close();
                var bitmap = new Bitmap(memStr);
                var currentFrame = new Image<Bgr, Byte>(bitmap);
                var face = _detection.DetectMultiScale(currentFrame, 1.1, 0);

                if (face.Length > 0)
                {
                    Image<Gray, byte> grayFaceImage = currentFrame.Convert<Gray, byte>().Copy(face[0]).Resize(_grayFaceImageSize, _grayFaceImageSize, Inter.Cubic);
                    grayFaceImage.ToBitmap().Save(memStr, ImageFormat.Png);
                    return JsonResponse.JsonHttpResponse<Object>(memStr.ToArray());
                }
                else
                    return JsonResponse.JsonHttpResponse<Object>(false);
            }
            catch (Exception e)
            {
                return JsonResponse.JsonHttpResponse<Object>(null);
            }


        }
    }
}