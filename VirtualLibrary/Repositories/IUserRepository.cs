using VirtualLibrary.View;

namespace VirtualLibrary.Repositories
{
    public interface IUserRepository : IRepository<IUser>
    {
        bool Login(string username, string password);
    }
}