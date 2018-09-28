using System.Collections.Generic;
using VirtualLibrary.View;
using System.Windows.Forms;
using VirtualLibrary.Repositories;
using VirtualLibrary.DataSources;
using VirtualLibrary.Helpers;

namespace VirtualLibrary.Presenters
{
    public class UserPresenter
    {
        IUser userView;
        private IRepository<IUser> m_userRepository;

        public UserPresenter(IUser view, IRepository<IUser> userRepository)
        {
            userView = view;
            m_userRepository = userRepository;
        }

        public bool AddUser()
        {
            var validator = new InputValidator();
            IUser newUser = validator.ValidateUserInput(userView);

            if (newUser != null)
            {
                m_userRepository.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IList<IUser> GetUserList()
        {
            return m_userRepository.GetList();
        }

       
    }
}
