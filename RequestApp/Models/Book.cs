using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public List<Author> Authors { get; set; }
        public List<int> GenreIds { get; set; }
        public int StatusId { get; set; }
    }
}