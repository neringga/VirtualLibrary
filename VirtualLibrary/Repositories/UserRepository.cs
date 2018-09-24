using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
