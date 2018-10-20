using System;
using VirtualLibrary.View;

namespace VirtualLibrary.Model
{
    [Serializable]
    public class User : IUser
    {
        public User()
        {

        }

        public User(IUser iuser)
        {
            Name = iuser.Name;
            Surname = iuser.Surname;
            Email = iuser.Email;
            DateOfBirth = iuser.DateOfBirth;
            Password = iuser.Password;
            Nickname = iuser.Nickname;
            Language = iuser.Language;
            Pictures = iuser.Pictures;
        }

        public string PhoneNumber { get; set; }
        public byte[][] Pictures { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Language { get; set; }
    }
}