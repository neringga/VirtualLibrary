using Shared.View;

namespace VILIB.Model
{
    public class User : IUser
    {
        public string PhoneNumber { get; set; }
        public byte[] Picture { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Language { get; set; }
    }
}