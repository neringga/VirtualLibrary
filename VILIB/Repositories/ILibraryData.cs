namespace VILIB.Repositories
{
    public interface ILibraryData
    {
        IUserRepository userRepository { get; set; }
        IBookRepository bookRepository { get; set; }
    }
}