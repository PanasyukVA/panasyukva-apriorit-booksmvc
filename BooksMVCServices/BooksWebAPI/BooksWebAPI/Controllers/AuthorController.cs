//----------------------------------------------------------
// <copyright file="AuthorController.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//----------------------------------------------------------
namespace BooksWebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Books.ViewModel;
    using BooksWebApi.DomainModel.Domains;

    /// <summary>
    /// Represents an author controller
    /// </summary>
    public class AuthorController : ApiController
    {
        /// <summary>
        /// Represents an author domain model
        /// </summary>
        private AuthorDomainModel model;

        /// <summary>
        /// Gets an author
        /// </summary>
        /// <param name="id">An author ad to receive</param>
        /// <returns>The received author</returns>
        public AuthorViewModel GetAuthor(int id)
        {
            using (this.model = new AuthorDomainModel())
            {
                return this.model.GetAuthor(id);
            }
        }

        /// <summary>
        /// Creates an author
        /// </summary>
        /// <param name="viewModelAuthor">The author to create</param>
        /// <returns>The created author</returns>
        public AuthorViewModel CreateAuthor([FromBody]AuthorViewModel viewModelAuthor)
        {
            using (this.model = new AuthorDomainModel())
            {
                this.model.CreateAuthor(viewModelAuthor);
                return viewModelAuthor;
            }
        }

        /// <summary>
        /// Edits an author
        /// </summary>
        /// <param name="viewModelAuthor">The author to edit</param>
        /// <returns>The edited author</returns>
        public AuthorViewModel EditAuthor([FromBody]AuthorViewModel viewModelAuthor)
        {
            using (this.model = new AuthorDomainModel())
            {
                this.model.EditAuthor(viewModelAuthor);
                return viewModelAuthor;
            }
        }
    }
}
