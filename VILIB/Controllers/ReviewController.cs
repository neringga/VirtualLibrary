using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using VILIB.Helpers;
using VILIB.Presenters;
using VILIB.Repositories;

namespace VILIB.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ReviewController : ApiController
    {
        private ReviewPresenter _reviewPresenter;
        private IReviewRepository _reviewRepository;

        public ReviewController(ReviewPresenter reviewPresenter, IReviewRepository reviewRepository)
        {
            _reviewPresenter = reviewPresenter;
            _reviewRepository = reviewRepository;
        }

        public async Task<HttpResponseMessage> Post()
        {
            var requestContent = Request.Content;
            var book = await requestContent.ReadAsStringAsync();
            return JsonResponse.JsonHttpResponse<object>
                (_reviewPresenter.GetBookReviews(book));
        }

        public async Task<HttpResponseMessage> Put()
        {
            var requestContent = Request.Content;
            var jsonContent = await requestContent.ReadAsStringAsync();
            var review = JsonConvert.DeserializeObject<Reviews>(jsonContent);

            try
            {
                await _reviewRepository.Add(review);
                return JsonResponse.JsonHttpResponse<object>(true);
            }
            catch (Exception)
            {
                return JsonResponse.JsonHttpResponse<object>(false);
            }

        }
    }
}
