using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Shared.View;
using VILIB.DataSources;
using VILIB.Helpers;

namespace VILIB.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IAsyncDataSource _dataSource;

        public ReviewRepository(IAsyncDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<int> Add(Reviews review)
        {
            return await _dataSource.AddReview(review);
        }

        public async Task<int> Remove(Reviews review)
        {
            return await _dataSource.RemoveReview(review);
        }

        public IList<Reviews> GetList()
        {
            return _dataSource.GetReviewList();
        }
    }
}