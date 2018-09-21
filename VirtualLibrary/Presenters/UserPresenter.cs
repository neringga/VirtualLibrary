using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;
using VirtualLibrary.Model;
using VirtualLibrary.UData;

namespace VirtualLibrary.Presenters
{
    class UserPresenter
    {
        IUser userView;
        public UserDataList userData = new UserDataList();
        User newUser = new User();

        public UserPresenter(IUser view)
        {
            userView = view;
        }

        public void UserDataInsertUser()
        {
            newUser.Name = userView.NameText;
            newUser.Surname = userView.SurnameText;
            newUser.Email = userView.EmailText;
            newUser.Password = userView.PasswordText;
            UserDataList.users.Add(newUser);                 //SLYKSTYNE nes padariau static
        }

        public List<User> GetUserList()
        {
            return UserDataList.users;
        }
    }
}
