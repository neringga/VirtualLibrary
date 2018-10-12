using System.Collections.Generic;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Presenters
{
    public class UserPresenter
    {
        private readonly IRepository<IUser> _mUserRepository;
        private readonly IUser _userView;

        public UserPresenter(IUser view, IRepository<IUser> userRepository)
        {
            _userView = view;
            _mUserRepository = userRepository;
        }

        public bool AddUser()
        {
            if (_userView != null)
            {
                _mUserRepository.Add(_userView);
                return true;
            }

            return false;
        }

        public IList<IUser> GetUserList()
        {
            return _mUserRepository.GetList();
        }
    }
}