using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using VILIB.Helpers;
using VILIB.Repositories;

namespace VILIB.Presenters
{
    public class ReviewPresenter
    {
        private List<string> _hashtags = new List<string>();
        private IReviewRepository _reviewRepository;

        public ReviewPresenter(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public List<string> GetHashtags(string review)  //Not tested 
        {
            foreach (Match match in Regex.Matches(review, @"(?<!\w)#\w+"))
            {
                _hashtags.Add(match.Value);
            }

            return _hashtags;
        }

        public List<Reviews> GetBookReviews(string book)
        {
            //var list = _reviewRepository.GetList();
            //foreach (var a in list)
            //{
            //    if (a.BookCode == book) {var b = a; }
                
            //}
            return _reviewRepository.GetList().Where(review => review.BookCode == book).ToList();
        }
    }
}