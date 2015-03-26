//-----------------------------------------------------------
// <copyright file="AuthorDomainModel.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//-----------------------------------------------------------
namespace BooksWebApi.DomainModel.Domains
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Books.DataAccessLayer;
    using Books.Infrastructure;
    using Books.ViewModel;

    /// <summary>
    /// Represents an author domain model
    /// </summary>
    public class AuthorDomainModel : DomainModelBase 
    {
        /// <summary>
        /// Represents a database context for the manipulation of entities
        /// </summary>
        private SelfEducationEntities context;

        /// <summary>
        /// Gets an author
        /// </summary>
        /// <param name="id">An author id to receive</param>
        /// <returns>The received author</returns>
        public AuthorViewModel GetAuthor(int id)
        {
            using (this.context = new SelfEducationEntities())
            {
                return this.context.Authors.Where(author => author.Id == id).Select(author => new
                {
                    AuthorId = author.Id,
                    AuthorName = author.Name,
                    Books = author.Books.Select(book => book.Name)
                }).ToList().Select(author => new AuthorViewModel()
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
        public AuthorViewModel CreateAuthor(AuthorViewModel viewModelAuthor)
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
        public AuthorViewModel EditAuthor(AuthorViewModel viewModelAuthor)
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
