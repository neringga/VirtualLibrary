using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;
using VirtualLibrary.Model;
using VirtualLibrary.UData;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace VirtualLibrary.Presenters
{
    class UserPresenter
    {
        IUser userView;
        public UserData userData = new UserData();
        User newUser = new User();

        public UserPresenter(IUser view)
        {
            userView = view;
        }

        public void UserDataInsertUser()
        {
            try
            {
                if (userView.NameText== string.Empty)
                    throw new ArgumentNullException("Name");
                newUser.Name = userView.NameText;
                if (userView.SurnameText == string.Empty)
                    throw new ArgumentNullException("Surname");
                newUser.Surname = userView.SurnameText;
                if (userView.EmailText == string.Empty)
                    throw new ArgumentNullException("Email");
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");        //Regex for email *@*.*
                Match match = regex.Match(userView.EmailText);
                if (match.Success)
                    newUser.Email = userView.EmailText;
                else
                {
                    MessageBox.Show(userView.EmailText + " is not a correct email.");
                    return;
                }
            }
            catch (ArgumentNullException e) {
                MessageBox.Show(e.Message);
                return;
            }

            UserData.users.Add(newUser);                 //SLYKSTYNE nes padariau static
            MessageBox.Show("Registered successfully");
        }

        public List<User> GetUserList()
        {
            return UserData.users;
        }
    }
}
