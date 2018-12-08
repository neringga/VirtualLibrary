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
using VILIB.DataSources;
using VILIB.DataSources.Data;
using VILIB.FaceRecognision;
using VILIB.Helpers;
using VILIB.View;

namespace VILIB.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FaceRecognitionController : ApiController
    {
        private readonly IAsyncDataSource _dataSource;
        private readonly IEmguCvFaceRecognition _recognition;

        public delegate bool UserActionHandler(object sender, string e);

        //public FaceRecognitionController(IEmguCvFaceRecognition recognition) //recognition should be already trained and up to date
        //{
        //    _recognition = recognition;
        //}

        public FaceRecognitionController(IAsyncDataSource dataSource)
        {
            _dataSource = dataSource;

            _recognition = new EigenFaceRecognition(new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UserInformation/" +
                                                      ConfigurationManager.AppSettings["faceDetectionTrainingFile"]))
                                                      .ToString(), int.Parse(ConfigurationManager.AppSettings["faceImageSize"]));

            _recognition.Train(ReadingLocalImages.getFaceImages().ToArray());

        }

        public event UserActionHandler OnLogin;

        public async Task<HttpResponseMessage> Post()
        {
            var stream = await Request.Content.ReadAsStreamAsync();
            MemoryStream memStr = new MemoryStream();
            try
            {
                stream.CopyTo(memStr);
                stream.Close();
                string nickname = _recognition.Recognize(FaceRecognision.ImageConverter.PhotoToBgrImage(memStr.ToArray()));

                //if (OnLogin(this, nickname))
                //{
                //    var token = JwtManager.GenerateToken(nickname);
                //    return JsonResponse.JsonHttpResponse(token);
                //}
                //return JsonResponse.JsonHttpResponse<Object>(false);
                return JsonResponse.JsonHttpResponse<Object>(nickname);
            }
            catch (Exception e)
            {
                return JsonResponse.JsonHttpResponse<Object>(null);
            }


        }
    }
}