using System.Collections.Generic;
using System.Linq;
using Shared.View;
using VILIB.DataSources.Data;
using VILIB.Repositories;

namespace VILIB.Presenters
{
    public class UserPresenter : IUserPresenter
    {
        private readonly IUserRepository _mUserRepository;
        private readonly IUser _userView;

        //public UserPresenter(IUser view, IRepository<IUser> userRepository)
        //{
        //    _userView = view;
        //    _mUserRepository = userRepository;
        //}

        public UserPresenter(IUserRepository userRepository)
        {
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

        public void AddUser(IUser userView)
        {
            _mUserRepository.Add(userView);
        }

        public IList<IUser> GetUserList()
        {
            return _mUserRepository.GetList();
        }

        public IUser FindUser()
        {
            return _mUserRepository.GetList().FirstOrDefault(user => user.Nickname == StaticDataSource.CurrUser);
        }

        public string GetUserEmail(string username)
        {
            return _mUserRepository.GetList().FirstOrDefault(user => user.Nickname == username).Email;
        }
    }
}