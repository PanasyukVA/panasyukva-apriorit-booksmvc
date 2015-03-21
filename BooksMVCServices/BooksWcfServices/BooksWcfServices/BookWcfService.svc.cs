using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BooksMVC.DAL;
using System.Data.Objects.SqlClient;

namespace BooksWcfServices
{
    public class BookWcfService : IBookWcfService
    {
        SelfEducationEntities context;

        public ICollection<AuthorServiceModel> GetAuthors()
        {
            using (context = new SelfEducationEntities())
            {
                return context.Authors.Select(author => new AuthorServiceModel()
                {
                    AuthorID = author.ID,
                    AuthorName = author.Name
                }).ToList<AuthorServiceModel>();
            }
        }

        public ICollection<BookServiceModel> GetBooks()
        {
            using (context = new SelfEducationEntities())
            {
                var books = context.Books.Select(book => new
                {
                    BookID = book.ID,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorServiceModel
                    {
                        AuthorID = author.ID,
                        AuthorName = author.Name
                    })
                }).ToList();

                return books.Select(book => new BookServiceModel()
                {
                    BookID = book.BookID,
                    BookName = book.BookName,
                    Authors = book.Authors.ToList<AuthorServiceModel>()
                }).ToList<BookServiceModel>();
            }
        }

        public BookServiceModel GetBook(int bookId)
        {
            using (context = new SelfEducationEntities())
            {
                var returnBook = context.Books.Where(book => book.ID == bookId).Select(book => new
                {
                    BookID = book.ID,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorServiceModel() { AuthorID = author.ID, AuthorName = author.Name }),
                    SelectedAuthors = book.Authors.Select(author => SqlFunctions.StringConvert((double?)author.ID).Trim())
                }).First();

                return new BookServiceModel()
                {
                    BookID = returnBook.BookID,
                    BookName = returnBook.BookName,
                    Authors = returnBook.Authors.ToList<AuthorServiceModel>(),
                    SelectedAuthors = returnBook.SelectedAuthors
                };
            }
        }

        public BookServiceModel CreateBook(BookServiceModel vmBook)
        {
            using (context = new SelfEducationEntities())
            {
                context.Books.Add(new Book()
                {
                    Name = vmBook.BookName,
                    Authors = context.Authors.Where(author => vmBook.SelectedAuthors.Contains(SqlFunctions.StringConvert((double?)author.ID).Trim())).ToList()
                });
                context.SaveChanges();
                return vmBook;
            }
        }

        public BookServiceModel EditBook(BookServiceModel vmBook)
        {
            using (context = new SelfEducationEntities())
            {
                Book DALBook = context.Books.Where(book => book.ID == vmBook.BookID).First();
                DALBook.Name = vmBook.BookName;
                context.SaveChanges();

                // Delete
                IEnumerable<string> authorsDelete = DALBook.Authors.Where(
                    author => !vmBook.SelectedAuthors.Contains(author.ID.ToString())).Select(
                        author => author.ID.ToString()).AsEnumerable<string>();
                foreach (var author in authorsDelete)
                    context.Database.ExecuteSqlCommand("DELETE dbo.BookAuthor WHERE BookID = {0} AND AuthorID = {1}", DALBook.ID, author);

                // Insert
                IEnumerable<string> authorsInsert = vmBook.SelectedAuthors.Where(
                    author => !DALBook.Authors.Select(
                        dalauthor => dalauthor.ID).AsEnumerable<int>().Contains(Convert.ToInt32(author))
                        );
                foreach (var author in authorsInsert)
                    context.Database.ExecuteSqlCommand("INSERT INTO dbo.BookAuthor(BookID, AuthorID) VALUES({0}, {1})", DALBook.ID, author);

                return vmBook;
            }
        }

        public void RemoveBook(BookServiceModel vmBook)
        {
            using (context = new SelfEducationEntities())
            {
                Book DALBook = context.Books.Where(book => book.ID == vmBook.BookID).First();
                context.Books.Remove(DALBook);
                context.SaveChanges();
            }
        }
    }
}
