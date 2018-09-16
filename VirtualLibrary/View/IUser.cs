using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.View
{
    interface IUser
    {
            string NameText { get; set; }
            string SurnameText { get; set; }
            string EmailText { get; set; }
            string DateOfBirthText { get; set; }
    }
}
