// -------------------------------------------------------------
// <copyright file="AuthorWcfService.svc.cs" company="ApriorIT">
//      Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
// -------------------------------------------------------------
namespace BooksWcfServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    using Books.DataAccessLayer;

    /// <summary>
    /// Represents a service for an author
    /// </summary>
    public class AuthorWcfService : IAuthorWcfService
    {
        /// <summary>
        /// Represents a database of entity manipulation
        /// </summary>
        private SelfEducationEntities context;

        /// <summary>
        /// Gets an author
        /// </summary>
        /// <param name="authorId">An author id to get</param>
        /// <returns>The received author</returns>
        public AuthorServiceModel GetAuthor(int authorId)
        {
            using (this.context = new SelfEducationEntities())
            {
                return this.context.Authors.Where(author => author.Id == authorId).Select(author => new
                {
                    AuthorId = author.Id,
                    AuthorName = author.Name,
                    Books = author.Books.Select(book => book.Name)
                }).ToList().Select(author => new AuthorServiceModel()
                {
                    AuthorId = author.AuthorId,
                    AuthorName = author.AuthorName,
                    Books = author.Books.Aggregate((currernt, next) => currernt + ", " + next)
                }).First();
            }
        }

        /// <summary>
        /// Creates an author
        /// </summary>
        /// <param name="viewModelAuthor">The author to create</param>
        /// <returns>The created author</returns>
        public AuthorServiceModel CreateAuthor(AuthorServiceModel viewModelAuthor)
        {
            using (this.context = new SelfEducationEntities())
            {
                this.context.Authors.Add(new Author() { Name = viewModelAuthor.AuthorName });
                this.context.SaveChanges();
                return viewModelAuthor;
            }
        }

        /// <summary>
        /// Edits an author
        /// </summary>
        /// <param name="viewModelAuthor">The author to edit</param>
        /// <returns>The edited author</returns>
        public AuthorServiceModel EditAuthor(AuthorServiceModel viewModelAuthor)
        {
            using (this.context = new SelfEducationEntities())
            {
                Author dalAuthor = this.context.Authors.Where(author => author.Id == viewModelAuthor.AuthorId).First();
                dalAuthor.Name = viewModelAuthor.AuthorName;
                this.context.SaveChanges();
                return viewModelAuthor;
            }
        }
    }
}
