using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laba3new.Models
{
    public class Sage
    {
        public int IdSage { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public byte[] Photo { get; set; }
        public string City { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}