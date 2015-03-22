using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksMVC.ViewModel;
using BooksMVC.Infrastructure;
using BooksMVC.DomainModel.BookWcfService;
using AutoMapper;

namespace BooksMVC.DomainModel.Domains
{
    public class BookDomainModel : DomainModelBase 
    {
        BookWcfServiceClient service;

        public BookDomainModel(){
            Mapper.CreateMap<AuthorServiceModel, AuthorViewModel>();
            Mapper.CreateMap<BookServiceModel, BookViewModel>();
            Mapper.CreateMap<BookViewModel, BookServiceModel>();
        }

        public ICollection<AuthorViewModel> GetAuthors()
        {
            using (service = new BookWcfServiceClient())
            {
                return service.GetAuthors().Select(author => Mapper.Map<AuthorServiceModel, AuthorViewModel>(author)).ToList<AuthorViewModel>();
            }
        }

        public ICollection<BookViewModel> GetBooks()
        {
            using (service = new BookWcfServiceClient())
            {
                return service.GetBooks().Select(book => Mapper.Map<BookServiceModel, BookViewModel>(book)).ToList<BookViewModel>();
            }
        }

        public BookViewModel GetBook(int bookId)
        {
            using (service = new BookWcfServiceClient())
            {
                return Mapper.Map<BookServiceModel, BookViewModel>(service.GetBook(bookId));
            }
        }

        public BookViewModel CreateBook(BookViewModel vmBook)
        {
            using (service = new BookWcfServiceClient())
            {
                service.CreateBook(Mapper.Map<BookViewModel, BookServiceModel>(vmBook));
            }
            return vmBook;
        }

        public BookViewModel EditBook(BookViewModel vmBook)
        {
            using (service = new BookWcfServiceClient())
            {
                service.EditBook(Mapper.Map<BookViewModel, BookServiceModel>(vmBook));
            }
            return vmBook;
        }

        public void RemoveBook(BookViewModel vmBook)
        {
            using (service = new BookWcfServiceClient())
            {
                service.RemoveBook(Mapper.Map<BookViewModel, BookServiceModel>(vmBook));
            }
        }
    }
}
