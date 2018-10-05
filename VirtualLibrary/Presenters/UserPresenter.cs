using System.Collections.Generic;
using VirtualLibrary.Helpers;
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
            var validator = new InputValidator();
            var newUser = validator.ValidateUserInput(_userView);

            if (newUser != null)
            {
                _mUserRepository.Add(newUser);
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