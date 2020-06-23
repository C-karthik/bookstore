using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class DBConnection : DbContext
    {

        public DBConnection() : base("conn")
        {

        }

        public DbSet<BookStore> bookStores { get; set; }
    }
}
