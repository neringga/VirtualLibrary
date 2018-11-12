using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using Emgu.CV;
using Emgu.CV.Structure;
using Newtonsoft.Json;

using VILIB.DataSources.Data;
using VILIB.Helpers;
using VILIB.View;


namespace VILIB.Controllers
{
    public class FaceRecognitionController : ApiController
    {
        IEmguCvFaceRecognition _recognition;

        public FaceRecognitionController(IEmguCvFaceRecognition recognition)
        {
            _recognition = recognition;
        }

        public async Task<HttpResponseMessage> Put()
        {
            Console.WriteLine("/na/na/na/na");

            HttpContent requestContent = Request.Content;
            string jsonContent = await requestContent.ReadAsStringAsync();
            var displayString = JsonConvert.DeserializeObject<string>(jsonContent);

            Image image = Image.FromStream(new MemoryStream(Convert.FromBase64String(displayString)));
            Image<Bgr, byte> bgrImage = new Image<Bgr, byte>(new Bitmap(image));

            string result = _recognition.Recognize(bgrImage);

            if (result == StaticStrings.UnknownUser || result == StaticStrings.FaceNotDetected)
            {
                return JsonResponse.JsonHttpResponse<Object>(result);
            }
            else
            {
                //log in user
                return JsonResponse.JsonHttpResponse<Object>(result);
            }
        }
    }
}