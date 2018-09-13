using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.Model;

namespace VirtualLibrary.Data
{
    class UserData
    {
        List<User> users = new List<User>();

        public void addUser (User user)
        {
            users.Add(user);
        }

    }
}
