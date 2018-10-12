using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;

namespace VirtualLibrary.Helpers
{
    public interface IInputValidator
    {
        bool UsernameTaken(string username, string defaultUsername = "default");
        bool ValidPassword(string password);
        bool ValidEmail(string email);
        bool ValidString(string value);
        bool ValidateStrings(IList<string> strings);
    }
}
