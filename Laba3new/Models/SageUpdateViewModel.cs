using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laba3new.Models
{
    public class SageUpdateViewModel
    {
        public Sage Sage { get; set; }

        public IList<int> SelectedBooks { get; set; }
    }
}