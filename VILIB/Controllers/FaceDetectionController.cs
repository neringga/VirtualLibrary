using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

using VILIB.Helpers;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FaceDetectionController : ApiController
    {
        private readonly int _grayFaceImageSize;
        private readonly double _cascadePrecision;

        private readonly CascadeClassifier _detection;

        public FaceDetectionController()
        {
            _detection = new CascadeClassifier(
                new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UserInformation/" +
                                  ConfigurationManager.AppSettings["faceDetectionTrainingFile"]))
                                  .ToString());

            _grayFaceImageSize = int.Parse(ConfigurationManager.AppSettings["faceImageSize"]);
            _cascadePrecision = double.Parse(ConfigurationManager.AppSettings["cascadePrecision"]);
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
                var face = _detection.DetectMultiScale(currentFrame, _cascadePrecision, 0);

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