//using Database.Db;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using VirtualLibrary.DataSources.Db;

//namespace VirtualLibraryTests.Tests
//{
//    [TestClass]
//    public class LibraryDbContextTest
//    {
//        private LibraryDbContext m_systemUnderTest;

//        [TestInitialize]
//        public void Initialize()
//        {
//            m_systemUnderTest = new LibraryDbContext();
//            // manually set the localdb connection string
//            m_systemUnderTest.Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//        }     

//        [TestMethod]
//        public void LibraryContext_ShouldCreate()
//        {
//            Assert.IsNotNull(m_systemUnderTest);
//        }

//        [TestMethod]
//        public void LibraryContext_ConnectionShouldBeAlive()
//        {
//            var exists = m_systemUnderTest.Database.Exists();
//            Assert.IsTrue(exists);
//        }

//        [TestMethod]
//        public void LibraryContext_UsersTableShouldBeNotNull()
//        {
//            Assert.IsNotNull(m_systemUnderTest.Users);
//        }

//        [TestMethod]
//        public void LibraryContext_BooksTableShouldBeNotNull()
//        {
//            Assert.IsNotNull(m_systemUnderTest.Books);
//        }

//        [TestMethod]
//        public void LibraryContext_ShouldBeAbleToAddBook()
//        {
//            var book = new DbBook();
//            var result = m_systemUnderTest.Books.Add(book);
//            Assert.IsNotNull(result);
//        }

//        [TestMethod]
//        public void LibraryContext_ShouldBeAbleToAddUser()
//        {
//            var user = new DbUser();
//            var result = m_systemUnderTest.Users.Add(user);
//            Assert.IsNotNull(result);
//        }

//        //[TestMethod]
//        //public void LocalDb()
//        //{
//        //    var dbCreator = new LocalDbCreator();
//        //    dbCreator.CreateLocalDb();
//        //}

//        [TestCleanup]
//        public void Cleanup()
//        {
//            var users = m_systemUnderTest.Users;
//            foreach (var user in users)
//                m_systemUnderTest.Users.Remove(user);

//            var books = m_systemUnderTest.Books;
//            foreach (var book in books)
//                m_systemUnderTest.Books.Remove(book);

//            m_systemUnderTest.SaveChanges();
//        }
//    }
//}
