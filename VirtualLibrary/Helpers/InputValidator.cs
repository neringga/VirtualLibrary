using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Model;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    public class InputValidator : IInputValidator
    {
        private IUserRepository _userRepository;

        public InputValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
     
        public bool UsernameTaken(string username, string defaultUsername = "default")
        {
            if (username == null)
                username = defaultUsername;

            return _userRepository.GetList().Select(user => user.Nickname).Contains(username);
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
    }
}