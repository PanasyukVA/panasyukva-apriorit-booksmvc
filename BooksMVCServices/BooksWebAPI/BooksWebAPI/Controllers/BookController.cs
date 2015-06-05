//--------------------------------------------------------
// <copyright file="BookController.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//--------------------------------------------------------
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
    /// Represents a book controller
    /// </summary>
    public class BookController : ApiController
    {
        /// <summary>
        /// Represents a book domain model
        /// </summary>
        private BookDomainModel model;

        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>Received authors</returns>
        public ICollection<AuthorViewModel> GetAuthors()
        {
            using (this.model = new BookDomainModel())
            {
                return this.model.GetAuthors();
            }
        }

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>Received books</returns>
        public ICollection<BookViewModel> GetBooks()
        {
            using (this.model = new BookDomainModel())
            {
                return this.model.GetBooks();
            }
        }

        /// <summary>
        /// Gets a book
        /// </summary>
        /// <param name="id">An book id to receive</param>
        /// <returns>The received book</returns>
        public BookViewModel GetBook(int id)
        {
            using (this.model = new BookDomainModel())
            {
                return this.model.GetBook(id);
            }
        }

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="viewModelBook">The book to create</param>
        /// <returns>The created book</returns>
        public BookViewModel CreateBook(BookViewModel viewModelBook)
        {
            using (this.model = new BookDomainModel())
            {
                this.model.CreateBook(viewModelBook);
                return viewModelBook;
            }
        }

        /// <summary>
        /// Edits a book
        /// </summary>
        /// <param name="viewModelBook">The book to edit</param>
        /// <returns>The edited book</returns>
        public BookViewModel EditBook(BookViewModel viewModelBook)
        {
            using (this.model = new BookDomainModel())
            {
                this.model.EditBook(viewModelBook);
                return viewModelBook;
            }
        }

        /// <summary>
        /// Removes a book
        /// </summary>
        /// <param name="viewModelBook">The book to remove</param>
        public void RemoveBook(BookViewModel viewModelBook)
        {
            using (this.model = new BookDomainModel())
            {
                this.model.RemoveBook(viewModelBook);
            }
        }
    }
}
