using Database.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using VILIB.Controllers;
using VILIB.DataSources.Data;
using VILIB.Repositories;
using VirtualLibrary.DataSources.Db;

namespace VirtualLibraryTests.Tests
{
    [TestClass]
    public class BookSerachControllerIntegrationTest
    {

     
        //[TestMethod]
        //public async Task AddEntries()
        //{
        //    var book1 = new DbBook();
        //    book1.Author = "Michail Bulgakov";
        //    book1.Title = "Suns Sirdis";
        //    book1.DaysForBorrowing = 30;
        //    book1.IsTaken = false;

        //    var book2 = new DbBook();
        //    book2.Author = "Michail Bulgakov";
        //    book2.Title = "Meistras ir Margarita";
        //    book2.DaysForBorrowing = 30;
        //    book2.IsTaken = false;

        //    var book3 = new DbBook();
        //    book3.Author = "Herman Hesse";
        //    book3.Title = "Stiklo karoliuku zaidimas";
        //    book3.DaysForBorrowing = 30;
        //    book3.IsTaken = false;

        //    var dbContext = new LibraryDbContext();


        //    dbContext.Books.Add(book1);
        //    dbContext.Books.Add(book2);
        //    dbContext.Books.Add(book3);

        //    await dbContext.SaveChangesAsync();

        //}

        //[TestMethod]
        //public void ShouldGet()
        //{
        //    var dbContext = new LibraryDbContext();
        //    // dbContext.Database.Connection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    var ds = new DbDataSource(dbContext);
        //    var repo = new BookRepository(ds);
        //    var ctrl = new BookSearchController(repo);

        //    var keyword = "Bulg";
        //    var result = ctrl.Get(keyword);
        //    Assert.AreEqual(1, result.Count);

        //}
    }
}
