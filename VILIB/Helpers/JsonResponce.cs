using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace VILIB.Helpers
{
    public static class JsonResponse
    {
        public static HttpResponseMessage JsonHttpResponse<T>(T objectToSendAsJson)
        {
            return new HttpResponseMessage()
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