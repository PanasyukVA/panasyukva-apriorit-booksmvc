//------------------------------------------------------
// <copyright file="AuthorController.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------
namespace Books.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using System.Web.Mvc;
    using Books.DomainModel.Domains;
    using Books.ViewModel;

    /// <summary>
    /// Represents an author controller
    /// </summary>
    public class AuthorController : BooksControllerBase
    {
        /// <summary>
        /// Creates a form to create an author 
        /// GET: /Author/Create
        /// </summary>
        /// <returns>A result of the creation</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return this.View("_Edit", new AuthorViewModel());
        }

        /// <summary>
        /// Creates a form to edit an author 
        /// GET: /Author/Edit/5
        /// </summary>
        /// <returns>A result of the creation</returns>
        [HttpGet]
        public ActionResult Edit()
        {
            return this.View("_Edit", new AuthorViewModel());
        }
    }
}
