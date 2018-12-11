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

            var genre1 = new DbGenre() { Genre = "Computers" };

            var book2 = new DbBook()
            {
                Title = "Even Faster Web Sites",
                Author = "Steve Sounders",
                Hashtags = new List<DbHashtag>()
            };

            dbCtx.Books.Add(book2);
            dbCtx.Genres.Add(genre1);

            book2.Genre = genre1;

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
