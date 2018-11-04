using System.Collections.Generic;

namespace VILIB.Helpers
{
    public interface IInputValidator
    {
        bool UsernameTaken(string username);
        bool EmailTaken(string email);
        bool ValidPassword(string password);
        bool ValidEmail(string email);
        bool ValidString(string value);
        bool ValidateStrings(IList<string> strings);
        bool ValidatetLogin(string username, string password);
    }
}