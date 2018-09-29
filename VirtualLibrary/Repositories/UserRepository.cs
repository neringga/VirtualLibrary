using System.Collections.Generic;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public class UserRepository : IRepository<IUser>
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

        public void Remove(IUser item)
        {
            _dataSource.RemoveUser(item);
        }
    }
}
