using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace VILIB.Helpers
{
    public static class JsonResponse
    {
        public static HttpResponseMessage JsonHttpResponse<T>(T objectToSendAsJson)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(objectToSendAsJson),
                    Encoding.UTF8,
                    "text/html"
                )
            };
        }
    }
}