namespace VILIB.Repositories
{
    public class LibraryData : ILibraryData
    {
        public LibraryData(IUserRepository userRepository, IBookRepository bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
        }

        public IUserRepository userRepository { get; set; }
        public IBookRepository bookRepository { get; set; }
    }
}