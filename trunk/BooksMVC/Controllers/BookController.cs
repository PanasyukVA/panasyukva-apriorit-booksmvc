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
            return this.View("Index");
        }

        /// <summary>
        /// Gets the list of books in the JSON format
        /// </summary>
        /// <returns>The received list of books in the JSON format</returns>
        [HttpGet]
        public JsonResult GetIndex()
        {
            using (this.model = new BookDomainModel())
            {
                return Json(model.GetBooks(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Creates a form to create a book 
        /// GET: /Book/Create
        /// </summary>
        /// <returns>A result of the creation</returns>
        [HttpGet]
        public JsonResult GetCreate()
        {
            using (this.model = new BookDomainModel())
            {
                return Json(this.model.GetAuthors(), JsonRequestBehavior.AllowGet);
            }
        }

        ///// <summary>
        ///// Creates a book
        ///// POST: /Book/Create
        ///// </summary>
        ///// <param name="model">The book to create</param>
        ///// <returns>A result of creation</returns>
        [HttpPost]
        public JsonResult Create(BookViewModel model)
        {
            using (this.model = new BookDomainModel())
            {
                this.model.CreateBook(model);
            }

            return Json(new { });
        }

        /// <summary>
        /// Creates a form to edit a book
        /// GET: /Book/Edit/5
        /// </summary>
        /// <param name="id">An book id to edit</param>
        /// <returns>A result of creation</returns>
        [HttpGet]
        public JsonResult GetEdit(int id)
        {
            using (this.model = new BookDomainModel())
            {
                return Json(new 
                { 
                    book = this.model.GetBook(id), 
                    allAuthors = this.model.GetAuthors()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Edits a book
        /// POST: /Book/Edit/5
        /// </summary>
        /// <param name="model">The book to edit</param>
        /// <returns>A result of editing</returns>
        [HttpPost]
        public JsonResult Edit(BookViewModel model)
        {
            using (this.model = new BookDomainModel())
            {
                this.model.EditBook(model);
            }

            return Json(new { });
        }
    }
}
