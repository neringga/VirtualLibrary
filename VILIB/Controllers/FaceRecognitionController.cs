using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.FaceRecognision;
using VILIB.Helpers;
using VILIB.View;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FaceRecognitionController : ApiController
    {
        private readonly IEmguCvFaceRecognition _recognition;

        //public FaceRecognitionController(IEmguCvFaceRecognition recognition) //recognition should be already trained and up to date
        //{
        //    _recognition = recognition;
        //}

        public FaceRecognitionController()
        {

        }

        public async Task<HttpResponseMessage> Post()
        {
            var stream = await Request.Content.ReadAsStreamAsync();
            MemoryStream memStr = new MemoryStream();
            try
            {
                stream.CopyTo(memStr);
                stream.Close();
                string userName = _recognition.Recognize(FaceRecognision.ImageConverter.PhotoToBgrImage(memStr.ToArray()));

                //check userName
                return JsonResponse.JsonHttpResponse<Object>(userName); //temp
            }
            catch (Exception e)
            {
                return JsonResponse.JsonHttpResponse<Object>(null);
            }


        }
    }
}