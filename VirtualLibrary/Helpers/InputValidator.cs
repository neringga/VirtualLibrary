using System.Linq;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Model;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    public class InputValidator
    {
        public IUser ValidateUserInput(IUser userView)
        {
            IUser newUser = new User
            {
                Password = userView.Password,
                DateOfBirth = userView.DateOfBirth,
                Nickname = userView.Nickname,
                Name = userView.Name,
                Surname = userView.Surname,
                Email = userView.Email,
                Language = userView.Language
            };
            return newUser;
        }

        public bool ValidUsername(string username, string defaultUsername = "default")
        {
            if (username == null) username = defaultUsername;
            var userRepository = new UserRepository(StaticDataSource.DataSource);
            var users = userRepository.GetList();

            return users.Select(user => user.Nickname).Contains(username);
        }
    }
}