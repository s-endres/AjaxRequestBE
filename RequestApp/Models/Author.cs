using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RequestApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string SecondNAme { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
    }
}