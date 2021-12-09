using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laba3new.Models
{
    public class Book
    {
        public int IdBook { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Sage> Sages { get; set; }
        public ICollection<BookOrder> BookOrders { get; set; }
    }
} 