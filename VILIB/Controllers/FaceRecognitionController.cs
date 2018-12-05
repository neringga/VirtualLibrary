using Shared.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using VILIB.DataSources.Data;
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
            _recognition = new EigenFaceRecognition(new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UserInformation/" +
                                                      ConfigurationManager.AppSettings["faceDetectionTrainingFile"]))
                                                      .ToString(), int.Parse(ConfigurationManager.AppSettings["faceImageSize"]));

            _recognition.Train(ReadingLocalImages.getFaceImages().ToArray());
        }

        public async Task<HttpResponseMessage> Post()
        {
            var stream = await Request.Content.ReadAsStreamAsync();
            MemoryStream memStr = new MemoryStream();
            try
            {
                stream.CopyTo(memStr);
                stream.Close();
                string nickname = _recognition.Recognize(FaceRecognision.ImageConverter.PhotoToBgrImage(memStr.ToArray()));

                //check userName
                return JsonResponse.JsonHttpResponse<Object>(nickname); //temp
            }
            catch (Exception e)
            {
                return JsonResponse.JsonHttpResponse<Object>(null);
            }


}
    }
}