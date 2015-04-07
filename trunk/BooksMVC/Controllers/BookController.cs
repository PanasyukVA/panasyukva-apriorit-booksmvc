//--------------------------------------------------------
// <copyright file="BookController.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//--------------------------------------------------------
namespace Books.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Books.DomainModel.Domains;
    using Books.Helpers;
    using Books.ViewModel;

    /// <summary>
    /// Represents a book controller
    /// </summary>
    public class BookController : BooksControllerBase
    {
        /// <summary>
        /// Represents a book domain model
        /// </summary>
        private BookDomainModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController" /> class
        /// </summary>
        public BookController()
            : base()
        {
            ViewBag.webApiGetAuthorPath = (System.Configuration.ConfigurationManager.AppSettings["BooksWebAPIGetAuthor"] ?? string.Empty).ToString();
            ViewBag.webApiCreateAuthorPath = (System.Configuration.ConfigurationManager.AppSettings["BooksWebAPICreateAuthor"] ?? string.Empty).ToString();
            ViewBag.webApiEditAuthorPath = (System.Configuration.ConfigurationManager.AppSettings["BooksWebAPIEditAuthor"] ?? string.Empty).ToString();
        }

        /// <summary>
        /// Gets books
        /// GET: /Book/Index
        /// </summary>
        /// <returns>Books to receive</returns>
        [HttpGet]
        public ActionResult Index()
        {
            using (this.model = new BookDomainModel())
            {
                return this.View("Index", this.model.GetBooks());
            }
        }
        
        /// <summary>
        /// Creates a form to create a book 
        /// GET: /Book/Create
        /// </summary>
        /// <returns>A result of the creation</returns>
        [HttpGet]
        public ActionResult Create()
        {
            using (this.model = new BookDomainModel())
            {
                throw new NotImplementedException("This is test exception");

                ViewBag.AllAuthors = new SelectList(this.model.GetAuthors(), "AuthorId", "AuthorName");
                return this.View("_Edit", new BookViewModel() { SelectedAuthors = new List<string>() });
            }
        }

        /// <summary>
        /// Creates a book
        /// POST: /Book/Create
        /// </summary>
        /// <param name="model">The book to create</param>
        /// <returns>A result of creation</returns>
        [HttpPost]
        public ActionResult Create(BookViewModel model)
        {
            using (this.model = new BookDomainModel())
            {
                this.model.CreateBook(model);
            }

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Creates a form to edit a book
        /// GET: /Book/Edit/5
        /// </summary>
        /// <param name="id">An book id to edit</param>
        /// <returns>A result of creation</returns>
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Edit(int id)
        {
            using (this.model = new BookDomainModel())
            {
                ViewBag.AllAuthors = new SelectList(this.model.GetAuthors(), "AuthorId", "AuthorName");
                return this.View("_Edit", this.model.GetBook(id));
            }
        }

        /// <summary>
        /// Edits a book
        /// POST: /Book/Edit/5
        /// </summary>
        /// <param name="model">The book to edit</param>
        /// <returns>A result of editing</returns>
        [HttpPost]
        public ActionResult Edit(BookViewModel model)
        {
            using (this.model = new BookDomainModel())
            {
                this.model.EditBook(model);
            }

            return this.RedirectToAction("Index");
        }
    }
}
