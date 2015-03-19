using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksMVC.DomainModel.Domains;
using BooksMVC.ViewModel;
using panasyukva_apriorit_booksmvc.BookWcfService;

namespace BooksMVC.Controllers
{
    public class BookController : Controller
    {
        BookWcfServiceClient service;
        
        //
        // GET: /Book/Index

        public ActionResult Index()
        {
            using (service = new BookWcfServiceClient())
            {
                var books = service.GetBooks().Select(book => new
                {
                    BookID = book.BookID,
                    BookName = book.BookName,
                    Authors = book.Authors.Select(author => new AuthorViewModel()
                    {
                        AuthorID = author.AuthorID,
                        AuthorName = author.AuthorName
                    }),
                    SelectedAuthors = book.SelectedAuthors
                }).ToList();

                return View("Index", books.Select(book => new BookViewModel()
                {
                    BookID = book.BookID,
                    BookName = book.BookName,
                    Authors = book.Authors.ToList<AuthorViewModel>(),
                    SelectedAuthors = book.SelectedAuthors
                }));
            }
        }
        
        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            using (service = new BookWcfServiceClient())
            {
                ViewBag.AllAuthors = new SelectList(service.GetAuthors(), "AuthorID", "AuthorName");
                return View("_Edit", new BookViewModel() { SelectedAuthors = new List<string>() });
            }
        }

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(BookViewModel Model)
        {
            try
            {
                using (service = new BookWcfServiceClient())
                {
                    service.CreateBook(new BookServiceModel() { 
                        BookID = Model.BookID,
                        BookName = Model.BookName,
                        SelectedAuthors = Model.SelectedAuthors.ToArray<string>()
                    });
                }
                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                return View("_Error", err);
            }
        }

        //
        // GET: /Book/Edit/5

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Edit(int id)
        {
            BookServiceModel bookService;
            using (service = new BookWcfServiceClient())
            {
                ViewBag.AllAuthors = new SelectList(service.GetAuthors().Select(author => new AuthorViewModel() 
                { 
                    AuthorID = author.AuthorID, 
                    AuthorName = author.AuthorName 
                }), "AuthorID", "AuthorName");

                bookService = service.GetBook(id);
            }

            return View("_Edit", new BookViewModel() { BookID = bookService.BookID, BookName = bookService.BookName, SelectedAuthors = bookService.SelectedAuthors });
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, BookViewModel Model)
        {
            try
            {
                using (service = new BookWcfServiceClient())
                {
                    service.EditBook(new BookServiceModel() { 
                        BookID = Model.BookID, 
                        BookName = Model.BookName, 
                        SelectedAuthors = Model.SelectedAuthors.ToArray<string>()
                    });
                }
                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                return View("_Error", err);
            }
        }
    }
}
