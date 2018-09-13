using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;

namespace VirtualLibrary.Presenters
{
    class UserPresenter
    {
        IUser userView;

        public UserPresenter(IUser view)
        {
            userView = view;
        }
    }
}
