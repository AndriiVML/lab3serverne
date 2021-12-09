using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laba3new.Models
{
    public class BookUpdateViewModel
    {
        public Book Book { get; set; }

        public IList<int> SelectedSages { get; set; }
    }
}