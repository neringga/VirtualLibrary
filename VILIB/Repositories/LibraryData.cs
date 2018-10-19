using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VILIB.Repositories
{
    public class LibraryData : ILibraryData
    {
        public IUserRepository userRepository { get; set; }
        public IBookRepository bookRepository { get; set; }

        public LibraryData(IUserRepository userRepository, IBookRepository bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;
        }
    }
}
