using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using VILIB.DataSources;
using VILIB.Repositories;

namespace VILIB.Helpers
{
    public class InputValidator : IInputValidator
    {
        private readonly IUserRepository _userRepository;

        public InputValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UsernameTaken(string username)
        {
            if (username == null)
                return true;

            return _userRepository.GetList().Select(user => user.Nickname).Contains(username);
        }

        public bool EmailTaken(string email)
        {
            if (email == null)
                return true;

            return _userRepository.GetList().Select(user => user.Email).Contains(email);
        }

        public bool ValidPassword(string password)
        {
            return password.Length < 6;
        }

        public bool ValidEmail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.Match(email).Success;
        }

        public bool ValidString(string value)
        {
            return value != null && !string.IsNullOrEmpty(value);
        }

        public bool ValidateStrings(IList<string> strings)
        {
            return strings.All(s => ValidString(s));
        }

        public bool ValidateLogin(string username, string password)
        {
            // if (_userRepository.GetList().Where(user => user.Nickname == username && user.Password == password)) == true)
            return _userRepository.Login(username, password).Equals(1) ? true : false;
        }
    }
}