using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookStore.Models
{
    public class BookStoreModel
    {
        [Key]
 
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string AuthorFirsttName { get; set; }

        public string AuthorlastName { get; set; }

        public string Gender { get; set; }
        public int PYear { get; set; }

        public decimal BookPrice { get; set; }

        public string Category { get; set; }

        public int Flag { get; set; }
    }
}