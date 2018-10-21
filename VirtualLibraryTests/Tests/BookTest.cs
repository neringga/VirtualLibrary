using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VirtualLibrary.Model;

namespace VirtualLibraryTests.Helpers
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void Constructor_ShouldCreate()
        {
            var book = new Book();
            Assert.IsNotNull(book);
        }

        [TestMethod]
        public void Equality_NullObjects_ThrowsException()
        {
            Book book1 = null;
            Book book2 = null;
            Assert.ThrowsException<NullReferenceException>(() => book1.Equals(book2));
        }

        [TestMethod]
        public void Equality_ObjectsWithNotInitializedProperties_AreEqual()
        {
            var book1 = new Book();
            var book2 = new Book();
            Assert.IsTrue(book1.Equals(book2));
        }

        [TestMethod]
        public void Equality_ObjectsWithSameCode_AreEqual()
        {
            var book1 = new Book();
            var book2 = new Book();
            book1.Code = book2.Code = "somecode";
            Assert.IsTrue(book1.Equals(book2));
        }

        [TestMethod]
        public void Equality_ObjectsWithSameCodeAndDifferentUser_AreEqual()
        {
            var book1 = new Book();
            var book2 = new Book();
            book1.Code = book2.Code = "somecode";
            book1.TakenByUser = "some username";
            book2.TakenByUser = "some other username";
            Assert.IsTrue(book1.Equals(book2));
        }
    }
}
