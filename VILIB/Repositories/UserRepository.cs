using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.View;
using VILIB.DataSources;
using VILIB.Helpers;

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

        public bool Login(object sender, LoginEventArgs e)
        {
            Func<IUser, bool> userMatchingPredicate =
                user => user.Nickname == e.Username && user.Password == e.Password;
            var users = _dataSource.GetUserList();

            return users
                .Where(user => userMatchingPredicate.Invoke(user))
                .Any();
        }

        public bool Login(object sender, string Username)
        {
            Func<IUser, bool> userMatchingPredicate =
                user => user.Nickname == Username;
            var users = _dataSource.GetUserList();

            return users
                .Where(user => userMatchingPredicate.Invoke(user))
                .Any();
        }

        public async Task<int> Remove(IUser item)
        {
            return await _dataSource.RemoveItem(item);
        }
    }
}