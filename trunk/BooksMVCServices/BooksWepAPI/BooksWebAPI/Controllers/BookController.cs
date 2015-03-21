using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BooksMVC.ViewModel;
using BooksWebAPI.DomainModel.Domains;

namespace BooksWebAPI.Controllers
{
    public class BookController : ApiController
    {
        BookDomainModel model;

        public ICollection<AuthorViewModel> GetAuthors()
        {
            using (model = new BookDomainModel())
            {
                return model.GetAuthors();
            }
        }

        public ICollection<BookViewModel> GetBooks()
        {
            using (model = new BookDomainModel())
            {
                return model.GetBooks();
            }
        }

        public BookViewModel GetBook(int Id)
        {
            using (model = new BookDomainModel())
            {
                return model.GetBook(Id);
            }
        }

        public BookViewModel CreateBook(BookViewModel vmBook)
        {
            using (model = new BookDomainModel())
            {
                model.CreateBook(vmBook);
                return vmBook;
            }
        }

        public BookViewModel EditBook(BookViewModel vmBook)
        {
            using (model = new BookDomainModel())
            {
                model.EditBook(vmBook);
                return vmBook;
            }
        }

        public void RemoveBook(BookViewModel vmBook)
        {
            using (model = new BookDomainModel())
            {
                model.RemoveBook(vmBook);
            }
        }
    }
}
