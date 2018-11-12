using Shared.View;
using System.Collections.Generic;

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
