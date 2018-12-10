using Database.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualLibrary.DataSources.Db;

namespace VirtualLibraryTests.Tools
{
    internal class TestDataPopulator
    {
        public async Task PopulateBooks()
        {
            var dbCtx = new LibraryDbContext();

            var genre1 = new DbGenre() { Genre = "Education" };

            var hashtagAgile = new DbHashtag() { Hastag = "#agile" };
            var hashtagCosmos = new DbHashtag() { Hastag = "#cosmos" };
            var hashtagCoding = new DbHashtag() { Hastag = "#coding" };

            var book1 = new DbBook()
            {
                Title = "Clean Code: A Handbook of Agile Software Craftmanship",
                Author = "Robert C. Martin",
                Hashtags = new List<DbHashtag>()
            };

            var book2 = new DbBook()
            {
                Title = "Cosmos",
                Author = "Carl Sagan",
                Hashtags = new List<DbHashtag>()
            };

            dbCtx.Books.Add(book1);
            dbCtx.Books.Add(book2);
            dbCtx.Genres.Add(genre1);
            dbCtx.Hashtags.Add(hashtagAgile);
            dbCtx.Hashtags.Add(hashtagCosmos);
            dbCtx.Hashtags.Add(hashtagCoding);

            book1.Genre = genre1;
            book1.Hashtags.Add(hashtagAgile);
            book1.Hashtags.Add(hashtagCoding);

            book2.Genre = genre1;
            book1.Hashtags.Add(hashtagCosmos);

            await dbCtx.SaveChangesAsync();
        }
    }

    [TestClass]
    public class PopulateDbTest
    {
        [TestMethod]
        public async Task PopulateBooks()
        {
            var populator = new TestDataPopulator();
            await populator.PopulateBooks();
        }
    }
}
