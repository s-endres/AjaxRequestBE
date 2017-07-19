using RequestApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RequestApp.Context
{
    public class LibraryContext : DbContext
    {
        public List<Book> Books { get; set; }
    }
}