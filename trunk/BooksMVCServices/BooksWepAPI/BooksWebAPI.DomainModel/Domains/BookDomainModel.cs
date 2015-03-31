//----------------------------------------------------------
// <copyright file="BookDomainModel.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//----------------------------------------------------------
namespace BooksWebApi.DomainModel.Domains
{
    using System;
    using System.Collections.Generic;
    using System.Data.Objects.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Books.DataAccessLayer;
    using Books.Infrastructure;
    using Books.ViewModel;

    /// <summary>
    /// Represents a book domain model
    /// </summary>
    public class BookDomainModel : DomainModelBase
    {
        /// <summary>
        /// Represents a database context for the manipulation of entities
        /// </summary>
        private SelfEducationEntities context;

        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>Received authors</returns>
        public ICollection<AuthorViewModel> GetAuthors()
        {
            using (this.context = new SelfEducationEntities())
            {
                return this.context.Authors.Select(author => new AuthorViewModel()
                {
                    AuthorId = author.Id,
                    AuthorName = author.Name
                }).ToList<AuthorViewModel>();
            }
        }

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>Received books</returns>
        public ICollection<BookViewModel> GetBooks()
        {
            using (this.context = new SelfEducationEntities())
            {
                var books = this.context.Books.Select(book => new
                {
                    BookId = book.Id,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorViewModel
                    {
                        AuthorId = author.Id,
                        AuthorName = author.Name
                    })
                }).ToList();

                return books.Select(book => new BookViewModel()
                {
                    BookId = book.BookId,
                    BookName = book.BookName,
                    Authors = book.Authors.ToList<AuthorViewModel>()
                }).ToList<BookViewModel>();
            }
        }

        /// <summary>
        /// Gets a book
        /// </summary>
        /// <param name="id">An book id to receive</param>
        /// <returns>The received book</returns>
        public BookViewModel GetBook(int id)
        {
            using (this.context = new SelfEducationEntities())
            {
                var returnBook = this.context.Books.Where(book => book.Id == id).Select(book => new
                {
                    BookId = book.Id,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorViewModel() { AuthorId = author.Id, AuthorName = author.Name }),
                    SelectedAuthors = book.Authors.Select(author => SqlFunctions.StringConvert((double?)author.Id).Trim())
                }).First();

                return new BookViewModel()
                {
                    BookId = returnBook.BookId,
                    BookName = returnBook.BookName,
                    Authors = returnBook.Authors.ToList<AuthorViewModel>(),
                    SelectedAuthors = returnBook.SelectedAuthors
                };
            }
        }

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="viewModelBook">The book to create</param>
        /// <returns>The created book</returns>
        public BookViewModel CreateBook(BookViewModel viewModelBook)
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
        public BookViewModel EditBook(BookViewModel viewModelBook)
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
        public void RemoveBook(BookViewModel viewModelBook)
        {
            using (this.context = new SelfEducationEntities())
            {
                Book dalBook = this.context.Books.Where(book => book.Id == viewModelBook.BookId).First();
                this.context.Books.Remove(dalBook);
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets authors of the book
        /// </summary>
        /// <param name="id">The book id to receive authors</param>
        /// <returns>Received authors</returns>
        public ICollection<AuthorViewModel> GetBookAuthors(int id)
        {
            return this.context.Books.Where(book => book.Id == id).First().Authors.Select(author => new AuthorViewModel()
            {
                AuthorId = author.Id,
                AuthorName = author.Name,
                Books = author.Books.Select(book => book.Name).Aggregate((currernt, next) => currernt + ", " + next)
            }).ToList<AuthorViewModel>();
        }

        /// <summary>
        /// Gets books by publish date
        /// </summary>
        /// <param name="beginDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <returns>Received books</returns>
        public ICollection<BookViewModel> GetBooksByPublishDateRange(DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException("This functionality is not implemented");
        }
    }
}
