using System.Collections.Generic;
using VILIB.View;

namespace VILIB.Presenters
{
    public interface IUserPresenter
    {
        bool AddUser();
        void AddUser(IUser userView);
        IUser FindUser();
        IList<IUser> GetUserList();
    }
}
