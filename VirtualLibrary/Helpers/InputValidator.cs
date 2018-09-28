using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using VirtualLibrary.DataSources;
using VirtualLibrary.Model;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    public class InputValidator
    {
        public IUser ValidateUserInput(IUser userView)
        {
            IUser newUser = new User();
            try
            {
                newUser.Password = userView.Password;
                newUser.DateOfBirth = userView.DateOfBirth;
                if (userView.Nickname == string.Empty || userView.Nickname == null)
                    throw new ArgumentNullException("Nickname");
                newUser.Nickname = userView.Nickname;

                if (userView.Name == string.Empty || userView.Name == null)
                    throw new ArgumentNullException("Name");
                newUser.Name = userView.Name;

                if (userView.Surname == string.Empty || userView.Surname == null)
                    throw new ArgumentNullException("Surname");
                newUser.Surname = userView.Surname;

                if (userView.Email == string.Empty || userView.Email == null)
                    throw new ArgumentNullException("Email");
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(userView.Email);
                if (match.Success)
                    newUser.Email = userView.Email;

                
                else
                {
                    MessageBox.Show(userView.Email + " is not a correct email format.");
                    return null;
                }

                return newUser;
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }

        public bool ValidUsername (string username)
        {
            var userRepository = new UserRepository(DataSources.Data.StaticDataSource._dataSource);
            var users = userRepository.GetList();

            return users.Select(user => user.Nickname).Contains(username);
        }
    }
}
