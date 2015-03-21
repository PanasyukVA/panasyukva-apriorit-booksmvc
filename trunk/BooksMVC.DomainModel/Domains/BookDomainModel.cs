using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksMVC.ViewModel;
using BooksMVC.Infrastructure;
using BooksMVC.DomainModel.BookWcfService;

namespace BooksMVC.DomainModel.Domains
{
    public class BookDomainModel : DomainModelBase 
    {
        BookWcfServiceClient service;

        public ICollection<AuthorViewModel> GetAuthors()
        {
            using (service = new BookWcfServiceClient())
            {
                return service.GetAuthors().Select(author => new AuthorViewModel() 
                { 
                    AuthorID = author.AuthorID, 
                    AuthorName = author.AuthorName 
                }).ToList<AuthorViewModel>();
            }
        }

        public ICollection<BookViewModel> GetBooks()
        {
            using (service = new BookWcfServiceClient())
            {
                var books = service.GetBooks().Select(book => new
                {
                    BookID = book.BookID,
                    BookName = book.BookName,
                    Authors = book.Authors.Select(author => new AuthorViewModel()
                    {
                        AuthorID = author.AuthorID,
                        AuthorName = author.AuthorName
                    }),
                    SelectedAuthors = book.SelectedAuthors
                }).ToList();

                return books.Select(book => new BookViewModel()
                {
                    BookID = book.BookID,
                    BookName = book.BookName,
                    Authors = book.Authors.ToList<AuthorViewModel>(),
                    SelectedAuthors = book.SelectedAuthors
                }).ToList<BookViewModel>();
            }
        }

        public BookViewModel GetBook(int bookId)
        {
            using (service = new BookWcfServiceClient())
            {
                BookServiceModel bookService = service.GetBook(bookId);
                return new BookViewModel() 
                { 
                    BookID = bookService.BookID, 
                    BookName = bookService.BookName, 
                    SelectedAuthors = bookService.SelectedAuthors 
                };
            }
        }

        public BookViewModel CreateBook(BookViewModel vmBook)
        {
            using (service = new BookWcfServiceClient())
            {
                service.CreateBook(new BookServiceModel()
                {
                    BookID = vmBook.BookID,
                    BookName = vmBook.BookName,
                    SelectedAuthors = vmBook.SelectedAuthors.ToArray<string>()
                });
            }

            return vmBook;
        }

        public BookViewModel EditBook(BookViewModel vmBook)
        {
            using (service = new BookWcfServiceClient())
            {
                service.EditBook(new BookServiceModel()
                {
                    BookID = vmBook.BookID,
                    BookName = vmBook.BookName,
                    SelectedAuthors = vmBook.SelectedAuthors.ToArray<string>()
                });

                return vmBook;
            }
        }

        public void RemoveBook(BookViewModel vmBook)
        {
            using (service = new BookWcfServiceClient())
            {
                service.RemoveBook(new BookServiceModel() 
                { 
                    BookID = vmBook.BookID, 
                    BookName = vmBook.BookName 
                });
            }
        }
    }
}
