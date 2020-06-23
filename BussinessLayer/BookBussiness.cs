using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BussinessLayer
{
    public class BookBussiness : IBussinessInterface
    {
        IDataInterface _dataInterface = new BookData();
        public int AddBook(BookStore book)
        {
            int res = _dataInterface.AddBook(book);
            return res;
        }

        public int Delete(int id)
        {
            return _dataInterface.Delete(id);
        }

      

        public BookStore GetBookById(int id)
        {
            return _dataInterface.GetBookById(id);
        }

        public List<BookStore> GetDetails()
        {
            List<BookStore> books = _dataInterface.GetDetails();

            return books;
        }

        public List<BookStore> GetFavList()
        {
            return _dataInterface.GetFavList();
        }

        public int PutIntoFavList(int id, BookStore store)
        {
            return _dataInterface.PutIntoFavList(id, store);
        }

        
    }
}
