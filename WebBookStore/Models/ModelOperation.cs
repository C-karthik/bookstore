using BussinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookStore.Models
{
    public class ModelOperation
    {
        private IBussinessInterface _bussiness = new BookBussiness();

        public virtual int AddBooks(BookStoreModel bookModel)
        {
            BookStore book = new BookStore();

            book.BookName = bookModel.BookName;
            book.AuthorFirsttName = bookModel.AuthorFirsttName;
            book.AuthorlastName = bookModel.AuthorlastName;
            book.BookPrice = bookModel.BookPrice;
            book.Category = bookModel.Category;
            book.Gender = bookModel.Gender;
            book.PYear = bookModel.PYear;

            int res = _bussiness.AddBook(book);

            return res;
        }

        public virtual BookStoreModel GetBookById(int id)
        {
            BookStoreModel storeModel = new BookStoreModel();
            BookStore store = _bussiness.GetBookById(id);

            storeModel.BookId = store.BookId;
            storeModel.AuthorFirsttName = store.AuthorFirsttName;
            storeModel.AuthorlastName = store.AuthorlastName;
            storeModel.BookName = store.BookName;
            storeModel.BookPrice = store.BookPrice;
            storeModel.Gender = store.Gender;
            storeModel.PYear = store.PYear;
            storeModel.Category = store.Category;

            return storeModel;
        }

        public virtual List<BookStoreModel> GetDetails()
        {
            List<BookStore> books = _bussiness.GetDetails();

            List<BookStoreModel> models = new List<BookStoreModel>();

            foreach (var item in books)
            {
                BookStoreModel storeModel = new BookStoreModel();

                storeModel.BookId = item.BookId;
                storeModel.BookName = item.BookName;
                storeModel.AuthorFirsttName = item.AuthorFirsttName;
                storeModel.AuthorlastName = item.AuthorlastName;
                storeModel.BookPrice = item.BookPrice;
                storeModel.Gender = item.Gender;
                storeModel.PYear = item.PYear;
                storeModel.Flag = item.Flag;
                storeModel.Category = item.Category;

                models.Add(storeModel);
            }

            return models;
        }

        public virtual int Delete(int id)
        {
            return _bussiness.Delete(id);
        }

        public virtual List<BookStoreModel> GetFavList()
        {
            List<BookStore> books = _bussiness.GetFavList();

            List<BookStoreModel> models = new List<BookStoreModel>();

            foreach (var item in books)
            {
                BookStoreModel storeModel = new BookStoreModel();

                storeModel.BookId = item.BookId;
                storeModel.BookName = item.BookName;
                storeModel.AuthorFirsttName = item.AuthorFirsttName;
                storeModel.AuthorlastName = item.AuthorlastName;
                storeModel.BookPrice = item.BookPrice;
                storeModel.Gender = item.Gender;
                storeModel.PYear = item.PYear;
                storeModel.Flag = item.Flag;
                storeModel.Category = item.Category;

                models.Add(storeModel);
            }

            return models;
        }

        public virtual int PutIntoFavList(int id, BookStoreModel bookModel)
        {
            BookStore store = new BookStore();

            store.Flag = bookModel.Flag;

            return _bussiness.PutIntoFavList(id, store);
        }
    }
}