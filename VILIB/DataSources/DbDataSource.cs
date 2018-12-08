using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.View;
using VirtualLibrary.DataSources.Db;
using VILIB.Helpers;
using VILIB.Model;
using Database.Db;

namespace VILIB.DataSources.Data
{
    public class DbDataSource : IAsyncDataSource
    {
        private readonly LibraryDbContext _dbContext;

        public DbDataSource(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CurrUser { get; set; }

        public async Task<int> AddReview(Reviews review)
        {
            _dbContext.Reviews.Add(ConvertToDbReviews(review));
            return await _dbContext.SaveChangesAsync();
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
            // TODO: remove and add a check in context initialization
            try
            {
                _dbContext.Users.Add(ConvertToDbUser(user));
            }
            catch (InvalidOperationException e)
            {
                e.Data.Add("Dev message", "Database has pending model changes. Apply those first.");
                throw;
            }

            return await _dbContext.SaveChangesAsync();
        }

        public IList<Reviews> GetReviewList()
        {
            var reviews = _dbContext.Reviews.ToList();
            return reviews.Select(review => ConvertToReviews(review)).ToList();
        }

        public IList<IBook> GetBookList()
        {
            var books = _dbContext.Books.ToList();
            return books.Select(book => ConvertToBook(book)).ToList();
        }

        public IList<IBook> GetTakenBookList()
        {
            var books = _dbContext.Books.ToList();
            return books.Select(book => ConvertToBook(book)).Where(book => book.IsTaken).ToList();
        }

        public IList<IUser> GetUserList()
        {
            // TODO: remove and add a check in context initialization
            try
            {
                var users = _dbContext.Users.ToList();
                return users.Select(user => ConvertToUser(user)).ToList();
            }
            catch (InvalidOperationException e)
            {
                // "Unable to update database to match the current model because there are pending changes and automatic migration is disabled"
                if (e.Message.Contains("database") && e.Message.Contains("pending changes"))
                    e.Data.Add("Dev message", "Database has pending model changes. Apply those first.");

                throw;
            }
        }

        public async Task<int> RemoveBook(IBook book)
        {
            _dbContext.Books.Remove(ConvertToDbBook(book));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveReview(Reviews review)
        {
            _dbContext.Reviews.Remove(ConvertToDbReviews(review));
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


        public IList<string> GetHashtagList()
        {
            return _dbContext.Hashtags.Select(g => g.Hastag).ToList();
        }

        public IList<string> GetGenreList()
        {
            return _dbContext.Genres.Select(g => g.Genre).ToList();
        }

        public async Task<int> RemoveItem<T>(T item)
        {
            if (item is IUser)
            {
                _dbContext.Users.Remove(ConvertToDbUser((IUser)item));
                return await _dbContext.SaveChangesAsync();
            }

            if (item is IBook)
            {
                _dbContext.Books.Remove(ConvertToDbBook((IBook)item));
                return await _dbContext.SaveChangesAsync();
            }

            throw new NotSupportedException("Object type is not supported");
        }

        public async Task<bool> ReturnBook(string isbnCode, string username)
        {
            var books = _dbContext.Books.ToList().Where(b => b.IsTaken && b.Code == isbnCode && b.TakenByUser == username).ToList();
            if (books.Count == 0 || books.Count != 1)
                throw new InvalidOperationException("Book has not been taken by this user or multiple books match this criteria");

            var book = books.First();
            book.IsTaken = false;
            book.TakenByUser = "";

            return (await _dbContext.SaveChangesAsync() == 1);
        }

        public async Task<bool> TakeBook(string isbnCode, string username)
        {
            var books = _dbContext.Books.ToList().Where(b => !b.IsTaken && b.Code == isbnCode).ToList();
            if (books.Count == 0 || books.Count != 1)
                throw new InvalidOperationException("Book has not been found or has been taken");

            var book = books.First();
            book.IsTaken = true;
            book.TakenByUser = username;
            book.HasToBeReturned = DateTime.UtcNow.AddDays(30);

            return (await _dbContext.SaveChangesAsync() == 1);
        }

        private DbBook ConvertToDbBook(IBook book)
        {
            var hashtaglist = book.Hashtags.Select(h => new DbHashtag() { Hastag = h });
            return new DbBook
            {
                Title = book.Title,
                Author = book.Author,
                Code = book.Code,
                DaysForBorrowing = book.DaysForBorrowing,
                IsTaken = book.IsTaken,
                TakenByUser = book.TakenByUser,
                TakenWhen = book.TakenWhen,
                HasToBeReturned = book.HasToBeReturned,
                Genre = new DbGenre() { Genre = book.Genre },
                Hashtags = book.Hashtags.Select(h => new DbHashtag() { Hastag = h }).ToList()
            };
        }

        private DbReview ConvertToDbReviews(Reviews review)
        {
            return new DbReview
            {
                BookCode = review.BookCode,
                User = review.User,
                Review = review.Review
            };
        }

        private DbUser ConvertToDbUser(IUser user)
        {
            return new DbUser
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
            return new Book
            {
                Title = book.Title,
                Author = book.Author,
                Code = book.Code,
                DaysForBorrowing = book.DaysForBorrowing,
                IsTaken = book.IsTaken,
                TakenByUser = book.TakenByUser,
                TakenWhen = book.TakenWhen,
                HasToBeReturned = book.HasToBeReturned,
                Genre = book.Genre?.Genre,
                Hashtags = book.Hashtags?.Select(h => h.Hastag).ToList()
            };
        }

        private IUser ConvertToUser(DbUser user)
        {
            return new User
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

        private Reviews ConvertToReviews(DbReview review)
        {
            return new Reviews
            {
                BookCode = review.BookCode,
                User = review.User,
                Review = review.Review
            };
        }
    }
}