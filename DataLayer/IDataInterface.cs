using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public interface IDataInterface
    {
        int AddBook(BookStore book);
        List<BookStore> GetDetails();
        BookStore GetBookById(int id);
        int PutIntoFavList(int id, BookStore store);
        List<BookStore> GetFavList();
        int Delete(int id);
       // List<BookStore> DetailsView();
    }
}
