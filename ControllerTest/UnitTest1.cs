using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using EntityLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebBookStore.Controllers;
using WebBookStore.Models;

namespace ControllerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddBook()
        {
            Mock<ModelOperation> mock = new Mock<ModelOperation>();
            BookStoreModel bookStoreModel = new BookStoreModel();
            //BookStore store = new BookStore();

            mock.Setup(m => m.AddBooks(bookStoreModel)).Returns(1);
            var controller = new BookStoreController(mock.Object);
            IHttpActionResult http = controller.Post(bookStoreModel);
            var actual = http as OkNegotiatedContentResult<string>;
            Assert.AreEqual("Success inserted book", actual.Content);
        }

        [TestMethod]
        //teskbook
        public void TestGetBook()
        {
            Mock<ModelOperation> moc = new Mock<ModelOperation>();

            List<BookStore> bookModel = new List<BookStore>()
            {
                new BookStore
                {
                    BookId = 1,
                    BookName="LifeStory",
                    AuthorFirsttName="Arvindh",
                    AuthorlastName="Gosam",
                    Gender="M",
                    PYear=2013,
                    BookPrice=353,
                    Flag=1
                }
            };
            moc.Setup(m => m.GetDetails()).Returns(new List<BookStoreModel>());
            var controller = new BookStoreController(moc.Object);
            IHttpActionResult http = controller.Get();
            var actual = http as OkNegotiatedContentResult<List<BookStoreModel>>;
            CollectionAssert.Equals(actual, bookModel);
        }

        [TestMethod]
        public void TestGetFavBook()
        {
            Mock<ModelOperation> moc = new Mock<ModelOperation>();

            List<BookStore> bookModel = new List<BookStore>()
            {
                new BookStore
                {
                    BookId = 1,
                    BookName="LifeStory",
                    AuthorFirsttName="Arvindh",
                    AuthorlastName="Gosam",
                    Gender="M",
                    PYear=2013,
                    BookPrice=353,
                    Flag=1
                }
            };
            moc.Setup(m => m.GetFavList()).Returns(new List<BookStoreModel>());
            var controller = new BookStoreController(moc.Object);
            IHttpActionResult http = controller.GetFavList();
            var actual = http as OkNegotiatedContentResult<List<BookStoreModel>>;
            CollectionAssert.Equals(actual, bookModel);
        }

        [TestMethod]
        [DataRow(3)]
        public void TestDelete(int id)
        {
            Mock<ModelOperation> moc = new Mock<ModelOperation>();

            moc.Setup(m => m.Delete(id)).Returns(1);
            var controller = new BookStoreController(moc.Object);
            IHttpActionResult http = controller.Delete(id);
            var actual = http as OkNegotiatedContentResult<string>;
            Assert.AreEqual("Deleted Success", actual);
        }

        [TestMethod]
        [DataRow(1)]
        public void TestGetBookByID(int id)
        {
            Mock<ModelOperation> moc = new Mock<ModelOperation>();

            BookStore bookModel = new BookStore()
            {
                BookId = 1,
                BookName = "LifeStory",
                AuthorFirsttName = "Arvindh",
                AuthorlastName = "Gosam",
                Gender = "M",
                PYear = 2013,
                BookPrice = 353,
                Flag = 1
            };
            moc.Setup(m => m.GetBookById(id)).Returns(new BookStoreModel());
            var controller = new BookStoreController(moc.Object);
            IHttpActionResult http = controller.Getbookcon(id);
            var actual = http as OkNegotiatedContentResult<BookStoreModel>;
            CollectionAssert.Equals(actual, bookModel);
        }
    }
}