using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class BookData : IDataInterface
    {
        DBConnection dbConnection = new DBConnection();
        public int AddBook(BookStore book)
        {
            dbConnection.bookStores.Add(book);
            return dbConnection.SaveChanges();
        }

        public int Delete(int id)
        {
            BookStore book =  dbConnection.bookStores.Find(id);

            dbConnection.bookStores.Remove(book);

            return dbConnection.SaveChanges();
        }

      

        public BookStore GetBookById(int id)
        {
           return dbConnection.bookStores.FirstOrDefault(b => b.BookId == id);
        }

        public List<BookStore> GetDetails()
        {
            return dbConnection.bookStores.ToList();
        }

        public List<BookStore> GetFavList()
        {
            List<BookStore> books = dbConnection.bookStores.Where(c => c.Flag == 1).ToList();
            return books;
        }

        public int PutIntoFavList(int id, BookStore store)
        {
         BookStore book = dbConnection.bookStores.FirstOrDefault(b => b.BookId == id);

            book.Flag = store.Flag;

            return dbConnection.SaveChanges();

        }
    }
}
