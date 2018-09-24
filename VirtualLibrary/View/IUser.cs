using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.View
{
    public interface IUser
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        string DateOfBirth{ get; set; }
        string Password { get; set; }
    }
}
