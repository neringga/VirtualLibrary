
using Shared.View;

namespace VILIB.Repositories
{
    public interface IUserRepository : IRepository<IUser>
    {
        bool Login(string username, string password);
    }
}