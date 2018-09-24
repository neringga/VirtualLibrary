using System;
using System.Collections.Generic;
using VirtualLibrary.View;
using VirtualLibrary.Model;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using VirtualLibrary.Repositories;
using VirtualLibrary.DataSources;

namespace VirtualLibrary.Presenters
{
    class UserPresenter
    {
        IUser userView;
        private IRepository<IUser> userRepository;

        public UserPresenter(IUser view)
        {
            userView = view;

            var _dataSource = new LocalDataSource();
            userRepository = new UserRepository(_dataSource);
        }

        public void UserDataInsertUser()
        {

            IUser newUser = new User();
            try
            {
                if (userView.Name == string.Empty)
                    throw new ArgumentNullException("Name");
                newUser.Name = userView.Name;
                if (userView.Surname == string.Empty)
                    throw new ArgumentNullException("Surname");
                newUser.Surname = userView.Surname;
                if (userView.Email == string.Empty)
                    throw new ArgumentNullException("Email");
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(userView.Email);
                if (match.Success)
                    newUser.Email = userView.Email;
                else
                {
                    MessageBox.Show(userView.Email + " is not a correct email format.");
                    return;
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            userRepository.Add(newUser);
            MessageBox.Show("Registered successfully");
        }

        public IList<IUser> GetUserList()
        {
            return userRepository.GetList();
        }
    }
}
