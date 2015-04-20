using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Books.DataAccessLayer;
using Books.ViewModel;
using System.Data.Objects.SqlClient;

namespace BooksWebServices
{
    /// <summary>
    /// Summary description for BookWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class BookWebService : System.Web.Services.WebService
    {    
        SelfEducationEntities context;

        [WebMethod]
        public ICollection<AuthorViewModel> GetAuthors()
        {
            using (context = new SelfEducationEntities())
            {
                return context.Authors.Select(author => new AuthorViewModel()
                {
                    AuthorId = author.Id,
                    AuthorName = author.Name
                }).ToList<AuthorViewModel>();
            }
        }

        public ICollection<BookViewModel> GetBooks()
        {
            using (context = new SelfEducationEntities())
            {
                var books = context.Books.Select(book => new
                {
                    BookID = book.Id,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorViewModel
                    {
                        AuthorId = author.Id,
                        AuthorName = author.Name
                    })
                }).ToList();

                return books.Select(book => new BookViewModel()
                {
                    BookId = book.BookID,
                    BookName = book.BookName,
                    Authors = book.Authors.ToList<AuthorViewModel>()
                }).ToList<BookViewModel>();
            }
        }

        public BookViewModel GetBook(int bookId)
        {
            using (context = new SelfEducationEntities())
            {
                var returnBook = context.Books.Where(book => book.Id == bookId).Select(book => new
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

        public BookViewModel CreateBook(BookViewModel vmBook)
        {
            using (context = new SelfEducationEntities())
            {
                context.Books.Add(new Book()
                {
                    Name = vmBook.BookName,
                    Authors = context.Authors.Where(author => vmBook.SelectedAuthors.Contains(SqlFunctions.StringConvert((double?)author.Id).Trim())).ToList()
                });
                context.SaveChanges();
                return vmBook;
            }
        }

        public BookViewModel EditBook(BookViewModel vmBook)
        {
            using (context = new SelfEducationEntities())
            {
                Book DALBook = context.Books.Where(book => book.Id == vmBook.BookId).First();
                DALBook.Name = vmBook.BookName;
                context.SaveChanges();

                // Delete
                IEnumerable<string> authorsDelete = DALBook.Authors.Where(
                    author => !vmBook.SelectedAuthors.Contains(author.Id.ToString())).Select(
                        author => author.Id.ToString()).AsEnumerable<string>();
                foreach (var author in authorsDelete)
                    context.Database.ExecuteSqlCommand("DELETE dbo.BookAuthor WHERE BookID = {0} AND AuthorID = {1}", DALBook.Id, author);

                // Insert
                IEnumerable<string> authorsInsert = vmBook.SelectedAuthors.Where(
                    author => !DALBook.Authors.Select(
                        dalauthor => dalauthor.Id).AsEnumerable<int>().Contains(Convert.ToInt32(author))
                        );
                foreach (var author in authorsInsert)
                    context.Database.ExecuteSqlCommand("INSERT INTO dbo.BookAuthor(BookID, AuthorID) VALUES({0}, {1})", DALBook.Id, author);

                return vmBook;
            }
        }

        public void RemoveBook(BookViewModel vmBook)
        {
            using (context = new SelfEducationEntities())
            {
                Book DALBook = context.Books.Where(book => book.Id == vmBook.BookId).First();
                context.Books.Remove(DALBook);
                context.SaveChanges();
            }
        }
    }
}
