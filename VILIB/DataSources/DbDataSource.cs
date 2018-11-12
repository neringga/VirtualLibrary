using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VILIB.Model;
using VILIB.View;
using VirtualLibrary.DataSources.Db;

namespace VILIB.DataSources.Data
{
    public class DbDataSource : IAsyncDataSource
    {
        public string CurrUser { get; set; }
        private readonly LibraryDbContext _dbContext;

        public DbDataSource(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddBook(IBook book)
        {
            _dbContext.Books.Add(ConvertToDbBook(book));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddTakenBook(IBook takenBook)
        {
            _dbContext.Books.Add(ConvertToDbBook(takenBook));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddUser(IUser user)
        {
            _dbContext.Users.Add(ConvertToDbUser(user));
            return await _dbContext.SaveChangesAsync();
        }

        public IList<IBook> GetBookList()
        {
            return _dbContext.Books.Select(book => ConvertToBook(book)).ToList();
        }

        public IList<IBook> GetTakenBookList()
        {
            var books = _dbContext.Books.ToList();
            return books.Select(book => ConvertToBook(book)).Where(book => book.IsTaken).ToList();
        }

        public IList<IUser> GetUserList()
        {
            var users = _dbContext.Users.ToList();
            return users.Select(user => ConvertToUser(user)).ToList();
        }

        public async Task<int> RemoveBook(IBook book)
        {
            _dbContext.Books.Remove(ConvertToDbBook(book));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveTakenBook(IBook takenBook)
        {
            _dbContext.Books.Remove(ConvertToDbBook(takenBook));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveUser(IUser user)
        {
            _dbContext.Users.Remove(ConvertToDbUser(user));
            return await _dbContext.SaveChangesAsync();
        }

        private DbBook ConvertToDbBook(IBook book)
        {
            return new DbBook()
            {
                Title = book.Title,
                Author = book.Author,
                Code = book.Code,
                DaysForBorrowing = book.DaysForBorrowing,
                IsTaken = book.IsTaken,
                TakenByUser = book.TakenByUser,
                TakenWhen = book.TakenWhen,
                HasToBeReturned = book.HasToBeReturned
            };
        }

        private DbUser ConvertToDbUser(IUser user)
        {
            return new DbUser()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Password = user.Password,
                Nickname = user.Nickname,
                Language = user.Language
            };
        }

        private IBook ConvertToBook(DbBook book)
        {
            return new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Code = book.Code,
                DaysForBorrowing = book.DaysForBorrowing,
                IsTaken = book.IsTaken,
                TakenByUser = book.TakenByUser,
                TakenWhen = (DateTime)book.TakenWhen,
                HasToBeReturned = (DateTime)book.HasToBeReturned
            };
        }

        private IUser ConvertToUser(DbUser user)
        {
            return new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Password = user.Password,
                Nickname = user.Nickname,
                Language = user.Language
            };
        }


    }
}