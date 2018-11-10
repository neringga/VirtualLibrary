using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VILIB.DataSources;
using VILIB.View;

namespace VILIB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IAsyncDataSource _dataSource;

        public UserRepository(IAsyncDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<int> Add(IUser item)
        {
            return await _dataSource.AddUser(item);
        }

        public IList<IUser> GetList()
        {
            return _dataSource.GetUserList();
        }

        public bool Login(string username, string password)
        {
            var users = _dataSource.GetUserList();
            return users.Where(user => user.Nickname == username && user.Password == password)
                       .ToList().Count == 1;
        }

        public async Task<int> Remove(IUser item)
        {
            return await _dataSource.RemoveUser(item);
        }
    }
}