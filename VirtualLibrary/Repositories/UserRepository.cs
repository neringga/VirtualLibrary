using System.Collections.Generic;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IDataSource _dataSource;

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

        public bool Login(IUser user)
        {
            return _dataSource.GetUserList().Contains(user);
        }

        public void Remove(IUser item)
        {
            _dataSource.RemoveUser(item);
        }
    }
}
