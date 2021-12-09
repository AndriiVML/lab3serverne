using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laba3new.Models
{
    public class BookOrder
    {
        public int BookOrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public Book Book { get; set; }
    }
}