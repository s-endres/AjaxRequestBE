using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RequestApp.Context;
using RequestApp.Models;

namespace RequestApp.Controllers
{
    public class BooksController : Controller
    {
        public static List<Book> tempBooks = new List<Book>()
        {
            new Book
            {
                BookId = 1,
                Title = "Boom title 1",
                Description = "Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.",
                ImageUrl = "MyImage.jpg",
                Publisher = "This is my publisher",
                PublicationYear = 2052,
                Authors = new List<Author>()
                {
                    new Author()
                    {
                        FirstName = "Luis",
                        SecondName = "Diego",
                        FirstLastName = "Rodriguez",
                        SecondLastName = "Gonzales"
                    },
                    new Author()
                    {
                        FirstName = "Alfredo",
                        SecondName = "Papito",
                        FirstLastName = "Valverde",
                        SecondLastName = "Gonzales"
                    }
                }
            },
            new Book
            {
                BookId = 2,
                Title = "Boom title 2",
                Description = "Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.",
                ImageUrl = "MyImage2.jpg",
                Publisher = "Alfredo Valverde",
                PublicationYear = 1024,
                Authors = new List<Author>()
                {
                    new Author()
                    {
                        FirstName = "Luis1",
                        SecondName = "Diego1",
                        FirstLastName = "Rodriguez1",
                        SecondLastName = "Gonzales1"
                    },
                    new Author()
                    {
                        FirstName = "Alfredo2",
                        SecondName = "Papito2",
                        FirstLastName = "Valverde2",
                        SecondLastName = "Gonzales3"
                    }
                }
            },
            new Book
            {
                BookId = 3,
                Title = "The theory of baam",
                Description = "Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.",
                ImageUrl = "MyImage.jpg",
                Publisher = "Oscar Valverde",
                PublicationYear = 592,
                Authors = new List<Author>()
                {
                    new Author()
                    {
                        FirstName = "Luis",
                        SecondName = "Diego",
                        FirstLastName = "Rodriguez",
                        SecondLastName = "Gonzales"
                    },
                    new Author()
                    {
                        FirstName = "Alfredo",
                        SecondName = "Papito",
                        FirstLastName = "Valverde",
                        SecondLastName = "Gonzales"
                    },
                    new Author()
                    {
                        FirstName = "Oscar",
                        SecondName = "El Grande",
                        FirstLastName = "Valverde",
                        SecondLastName = "Gonzales"
                    }
                }
            },
        };

        // GET: Books
        public ActionResult Index()
        {
            return View(tempBooks);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }





         //Metodos importantes a partir de aca 
        [HttpGet]
        public JsonResult GetMyJsonValues()
        {
            return Json(tempBooks, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddNewBook([Bind(Include = "Title,Description,ImageUrl,Publisher,PublicationYear")] Book book, List<Author> authors)
        {
            try
            {
                book.BookId = tempBooks.Count + 1;
                book.Authors = authors;
                tempBooks.Add(book);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpDelete]
        public JsonResult DeleteBook(int? bookId)
        {
            if (bookId != null)
            {
                var foundBook = tempBooks.Where(s => s.BookId == bookId).FirstOrDefault();
                tempBooks.Remove(foundBook);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getSingleBook(int? bookId)
        {
            if (bookId != null)
            {
                var foundBook = tempBooks.Where(s => s.BookId == bookId).FirstOrDefault();
                return Json(foundBook, JsonRequestBehavior.AllowGet);
            }
                return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getBookAuthors(int? bookId)
        {
            if (bookId != null)
            {
                var foundBook = tempBooks.Where(s => s.BookId == bookId).FirstOrDefault();
                return Json(foundBook.Authors, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult UpdateBook([Bind(Include = "BookId,Title,Description,ImageUrl,Publisher,PublicationYear")] Book book, List<Author> authors)
        {
            if (book.BookId != null)
            {
                var foundBook = tempBooks.Where(s => s.BookId == book.BookId).FirstOrDefault();
                foundBook.Title = book.Title;
                foundBook.Description = book.Description;
                foundBook.ImageUrl = book.ImageUrl;
                foundBook.Publisher = book.Publisher;
                foundBook.PublicationYear = book.PublicationYear;
                foundBook.Authors = authors;
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }



    }
}
