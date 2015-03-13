using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksMVC.DAL;
using BooksMVC.ViewModel;
using BooksMVC.Infrastructure;
using System.Data.Objects.SqlClient;

namespace BooksMVC.DomainModel.Domains
{
    public class BookDomainModel : DomainModelBase 
    {
        SelfEducationEntities context;

        public ICollection<AuthorViewModel> GetAuthors()
        {
            using (context = new SelfEducationEntities())
            {
                return context.Authors.Select(author => new AuthorViewModel() { 
                    AuthorID = author.ID, 
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
                    BookID = book.ID,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorViewModel 
                    {
                        AuthorID = author.ID,
                        AuthorName = author.Name
                    })
                }).ToList();

                return books.Select(book => new BookViewModel()
                {
                    BookID = book.BookID,
                    BookName = book.BookName,
                    Authors = book.Authors.ToList<AuthorViewModel>()
                }).ToList<BookViewModel>();
            }
        }

        public BookViewModel GetBook(int bookId)
        {
            using (context = new SelfEducationEntities())
            {
                var returnBook = context.Books.Where(book => book.ID == bookId).Select(book => new
                {
                    BookID = book.ID,
                    BookName = book.Name,
                    Authors = book.Authors.Select(author => new AuthorViewModel() { AuthorID = author.ID, AuthorName = author.Name }),
                    SelectedAuthors = book.Authors.Select(author => SqlFunctions.StringConvert((double?)author.ID).Trim())
                }).First();

                return new BookViewModel() 
                { 
                    BookID = returnBook.BookID, 
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
                context.Books.Add(new Book() { 
                    Name = vmBook.BookName, 
                    Authors = context.Authors.Where(author => vmBook.SelectedAuthors.Contains(SqlFunctions.StringConvert((double?)author.ID).Trim())).ToList()
                });
                context.SaveChanges();
                return vmBook;
            }
        }

        public BookViewModel EditBook(BookViewModel vmBook)
        {
            using (context = new SelfEducationEntities())
            {
                Book DALBook = context.Books.Where(book => book.ID == vmBook.BookID).First();
                DALBook.Name = vmBook.BookName;
                DALBook.Authors = context.Authors.Where(author => vmBook.SelectedAuthors.Contains(SqlFunctions.StringConvert((double?)author.ID).Trim())).ToList();
                context.SaveChanges();
                return vmBook;
            }
        }

        public void RemoveBook(BookViewModel vmBook)
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
