using System.Collections.Generic;
using System.Linq;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataSource _dataSource;

        public UserRepository(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Add(IUser item)
        {
            _dataSource.AddUser(item);
        }

        public IList<IUser> GetList()
        {
            return _dataSource.GetUserList();
        }

        public bool Login(string username, string password)
        {
            return _dataSource.GetUserList().Where(user => user.Nickname == username && user.Password == password)
                       .ToList().Count == 1;
        }

        public void Remove(IUser item)
        {
            _dataSource.RemoveUser(item);
        }
    }
}