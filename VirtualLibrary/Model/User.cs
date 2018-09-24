using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;

namespace VirtualLibrary.Model
{
    public class User : IUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        public byte[] Picture { get; set; }

    }
}
