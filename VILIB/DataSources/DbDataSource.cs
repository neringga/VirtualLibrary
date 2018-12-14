using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.View;
using VILIB.Helpers;
using VILIB.Model;
using Database.Db;
using VILIB.FaceRecognision;
using VirtualLibrary.DataSources.Db;
using System.Text.RegularExpressions;

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

            var reviewedBook = _dbContext.Books.FirstOrDefault(book => book.Code == review.BookCode);

            foreach (Match match in Regex.Matches(review.Review, @"(?<!\w)#\w+"))
            {
                var hashtag = match.Value;
                var newHashtag = new DbHashtag() { Hastag = hashtag };
                _dbContext.Hashtags.Add(newHashtag);
                reviewedBook.Hashtags.Add(newHashtag);
            }

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddBook(IBook book)
        {
            _dbContext.Books.Add(ConvertToDbBook(book));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddUser(IUser user)
        {
            // DB Insert
            _dbContext.Users.Add(ConvertToDbUser(user));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> AddFaceImage(FaceImage faceImage)
        {
            _dbContext.FaceImages.Add(ConvertToDbFaceImage(faceImage));
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
            // DB Select
            var books = _dbContext.Books.ToList();
            return books.Select(book => ConvertToBook(book)).Where(book => book.IsTaken).ToList();
        }

        public IList<IUser> GetUserList()
        {
            var users = _dbContext.Users.ToList();
            return users.Select(user => ConvertToUser(user)).ToList();
        }

        public IList<IBook> GetHistoryBookList()
        {
            var books = _dbContext.BookTakingHistory.ToList();
            return books.Select(book => ConvertToBookHistory(book)).ToList();
        }

        public List<FaceImage> GetFaceImageList()
        {
            var faceImages = _dbContext.FaceImages.ToList();
            return faceImages.Select(faceImage => ConvertToFaceImage(faceImage)).ToList();
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
            // DB Delete
            _dbContext.Users.Remove(ConvertToDbUser(user));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveFaceImages(string nickname)
        {
            //TODO
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
            book.TakenByUser = null;
            book.HasToBeReturned = null;

            return (await _dbContext.SaveChangesAsync() == 1);
        }

        public async Task<bool> TakeBook(string isbnCode, string username)
        {
            var book = _dbContext.Books.SingleOrDefault(b => !b.IsTaken && b.Code == isbnCode);
            if (book == null)
                throw new InvalidOperationException("Book has not been found or has been taken");

            // DB Update
            book.IsTaken = true;
            book.TakenByUser = username;
            book.HasToBeReturned = DateTime.UtcNow.AddDays(30);

            _dbContext.BookTakingHistory.Add(ConvertToDbBookHistory(ConvertToBook(book)));

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
                Hashtags = GetHashtags(book)
            };
        }

        private DbBookTakingHistory ConvertToDbBookHistory(IBook book)
        {
            return new DbBookTakingHistory
            {
                BookCode = book.Code,
                TakenByUser = book.TakenByUser
            };
        }

        private IList<DbHashtag> GetHashtags(IBook book)
        {
            var res = new List<DbHashtag>();

            foreach (var h in book.Hashtags)
                res.Add(new DbHashtag() { Hastag = h });

            return res;
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

        private IBook ConvertToBookHistory(DbBookTakingHistory book)
        {
            return new Book
            {
                Code = book.BookCode,
                TakenByUser = book.TakenByUser,
                Title = null,
                Author = null,
                DaysForBorrowing = 30,
                IsTaken = false,
                TakenWhen = null,
                HasToBeReturned = null,
                Genre = null,
                Hashtags = null
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


        private DbFaceImage ConvertToDbFaceImage(FaceImage faceImage)
        {
            return new DbFaceImage
            {
                Nickname = faceImage.Nickname,
                Bytes = faceImage.Bytes
            };
        }

        private FaceImage ConvertToFaceImage(DbFaceImage faceImage)
        {
            return new FaceImage
            {
                Nickname = faceImage.Nickname,
                Bytes = faceImage.Bytes
            };
        }


        // LINQ usage: Join, Group, Skip and Take, Agregate function.

        // LINQ Group
        public IDictionary<string, IEnumerable<IBook>> GetBooksByGenre()
        {
            var booksByGenre = new Dictionary<string, IEnumerable<IBook>>();

            foreach (var group in _dbContext.Books.GroupBy(book => book.Genre).ToList())
                booksByGenre.Add(group.Key.Genre, group.Select(b => ConvertToBook(b)).ToList());

            return booksByGenre;
        }

        // Linq Join
        public IEnumerable<IBook> GetBooksTakenByUser(string username)
        {
            return _dbContext.Books
                .Join(
                    _dbContext.Users,
                    book => book.TakenByUser,
                    user => user.Nickname,
                    (book, user) => new { DbBook = book, DbUser = user })
                .Where(bookAndUser => bookAndUser.DbUser.Nickname == username)
                .ToList()
                .Select(bookAndUser => ConvertToBook(bookAndUser.DbBook));
        }

        // Linq Skip and Take
        public IEnumerable<IUser> GetFirstFiveUsersOlderThan18Years()
        {
            try
            {
                var dbUsers = _dbContext.Users.ToList();
                var userIndex = dbUsers
                    .Select((value, idx) => new { value, idx })
                    .Where(valueIdxPair => DateTime.Now.Year - DateTime.Parse(valueIdxPair.value.DateOfBirth).Year >= 18)
                    .Select(valueIdxPair => valueIdxPair.idx)
                    .First();

                return dbUsers.Skip(userIndex).Take(5);
            }
            catch (InvalidOperationException e)
            {
                if (e.Message.Contains("Sequence contains no elements"))
                    return new List<IUser>();

                throw;
            }
        }

        // Linq Aggregate
        public string GetGenreWithTheMostBooks()
        {
            var genreBookGroups = GetBooksByGenre();
            var firstGenre = genreBookGroups.First();

            return genreBookGroups
                .Aggregate(
                    firstGenre,
                    (mostPopular, next) => next.Value.ToList().Count > mostPopular.Value.ToList().Count ? next : mostPopular,
                    value => value.Key);
        }

    }
}