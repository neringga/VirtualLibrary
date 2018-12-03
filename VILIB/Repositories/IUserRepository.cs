using Shared.View;
using VILIB.Helpers;

namespace VILIB.Repositories
{
    public interface IUserRepository : IRepository<IUser>
    {
        bool Login(object sender, LoginEventArgs e);
    }
}