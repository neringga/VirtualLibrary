using System.Collections.Generic;

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