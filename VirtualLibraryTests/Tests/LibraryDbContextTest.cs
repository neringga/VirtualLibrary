using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualLibrary.DataSources.Db;

namespace VirtualLibraryTests.Tests
{
    [TestClass]
    public class LibraryDbContextTest
    {
        [TestMethod]
        public void LibraryContext_ShouldCreate()
        {
            var systemUnderTest = new LibraryDbContext();
            Assert.IsNotNull(systemUnderTest);
        }


        [TestMethod]
        public void LibraryCintext_ConnectionShouldBeAlive()
        {
            var dbContext = new LibraryDbContext();
            var exists = dbContext.Database.Exists();
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void LibraryCintext_UsersTableShouldBeNotNull()
        {
            var dbContext = new LibraryDbContext();
            Assert.IsNotNull(dbContext.Users);
        }
    }
}
