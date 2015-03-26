// -------------------------------------------------------------
// <copyright file="BookWcfService.svc.cs" company="ApriorIT">
//      Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
// -------------------------------------------------------------
namespace BooksWcfServices
{
    using System;
    using System.Collections.Generic;
    using System.Data.Objects.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using Books.DataAccessLayer;

    /// <summary>
    /// Represents a service for author for a book
    /// </summary>
    public class BookWcfService : IBookWcfService
    {
        /// <summary>
        /// Represents a database context of entity manipulation
        /// </summary>
        private SelfEducationEntities context;

        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>Received authors</returns>
        public ICollection<AuthorServiceModel> GetAuthors()
        {
            using (this.context = new SelfEducationEntities())
            {
                return this.context.Authors.Select(author => new AuthorServiceModel()
                {
                    AuthorId = author.Id,
                    AuthorName = author.Name
                }).ToList<AuthorServiceModel>();
            }
        }

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>Received books</returns>
        public ICollection<BookServiceModel> GetBooks()
        {
            using (this.context = new SelfEducationEntities())
            {
                var books = this.context.Books.Select(book => new
                {
                    BookID = book.Id,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorServiceModel
                    {
                        AuthorId = author.Id,
                        AuthorName = author.Name
                    })
                }).ToList();

                return books.Select(book => new BookServiceModel()
                {
                    BookId = book.BookID,
                    BookName = book.BookName,
                    Authors = book.Authors.ToList<AuthorServiceModel>()
                }).ToList<BookServiceModel>();
            }
        }

        /// <summary>
        /// Gets a book
        /// </summary>
        /// <param name="bookId">A book id to receive</param>
        /// <returns>The received book</returns>
        public BookServiceModel GetBook(int bookId)
        {
            using (this.context = new SelfEducationEntities())
            {
                var returnBook = this.context.Books.Where(book => book.Id == bookId).Select(book => new
                {
                    BookID = book.Id,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorServiceModel() { AuthorId = author.Id, AuthorName = author.Name }),
                    SelectedAuthors = book.Authors.Select(author => SqlFunctions.StringConvert((double?)author.Id).Trim())
                }).First();

                return new BookServiceModel()
                {
                    BookId = returnBook.BookID,
                    BookName = returnBook.BookName,
                    Authors = returnBook.Authors.ToList<AuthorServiceModel>(),
                    SelectedAuthors = returnBook.SelectedAuthors
                };
            }
        }

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="viewModelBook">The book to create</param>
        /// <returns>The created book</returns>
        public BookServiceModel CreateBook(BookServiceModel viewModelBook)
        {
            using (this.context = new SelfEducationEntities())
            {
                this.context.Books.Add(new Book()
                {
                    Name = viewModelBook.BookName,
                    Authors = this.context.Authors.Where(author => viewModelBook.SelectedAuthors.Contains(SqlFunctions.StringConvert((double?)author.Id).Trim())).ToList()
                });
                this.context.SaveChanges();
                return viewModelBook;
            }
        }

        /// <summary>
        /// Edits a book
        /// </summary>
        /// <param name="viewModelBook">The book to edit</param>
        /// <returns>The edited book</returns>
        public BookServiceModel EditBook(BookServiceModel viewModelBook)
        {
            using (this.context = new SelfEducationEntities())
            {
                Book dalBook = this.context.Books.Where(book => book.Id == viewModelBook.BookId).First();
                dalBook.Name = viewModelBook.BookName;
                this.context.SaveChanges();

                // Delete
                IEnumerable<string> authorsDelete = dalBook.Authors.Where(
                    author => !viewModelBook.SelectedAuthors.Contains(author.Id.ToString(CultureInfo.CurrentCulture))).Select(
                        author => author.Id.ToString(CultureInfo.CurrentCulture)).AsEnumerable<string>();
                foreach (var author in authorsDelete)
                {
                    this.context.Database.ExecuteSqlCommand("DELETE dbo.BookAuthor WHERE BookID = {0} AND AuthorID = {1}", dalBook.Id, author);
                }

                // Insert
                IEnumerable<string> authorsInsert = viewModelBook.SelectedAuthors.Where(
                    author => !dalBook.Authors.Select(
                        dalauthor => dalauthor.Id).AsEnumerable<int>().Contains(Convert.ToInt32(author, CultureInfo.CurrentCulture)));
                foreach (var author in authorsInsert)
                {
                    this.context.Database.ExecuteSqlCommand("INSERT INTO dbo.BookAuthor(BookID, AuthorID) VALUES({0}, {1})", dalBook.Id, author);
                }

                return viewModelBook;
            }
        }

        /// <summary>
        /// Removes a book
        /// </summary>
        /// <param name="viewModelBook">The book to remove</param>
        public void RemoveBook(BookServiceModel viewModelBook)
        {
            using (this.context = new SelfEducationEntities())
            {
                Book dalBook = this.context.Books.Where(book => book.Id == viewModelBook.BookId).First();
                this.context.Books.Remove(dalBook);
                this.context.SaveChanges();
            }
        }
    }
}
