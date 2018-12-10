using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VILIB.DataSources;

namespace VILIB.Repositories
{
    public class GenreRepository : IRepository<string>
    {
        private IAsyncDataSource _ds;
        public GenreRepository(IAsyncDataSource ds)
        {
            _ds = ds;
        }
        public Task<int> Add(string item)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetList()
        {
            return _ds.GetGenreList();
        }

        public Task<int> Remove(string item)
        {
            throw new NotImplementedException();
        }
    }
}