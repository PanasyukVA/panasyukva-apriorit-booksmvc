//------------------------------------------------------
// <copyright file="BookDomainModel.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------
namespace Books.DomainModel.Domains
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Books.DomainModel.BookWcfService;
    using Books.Infrastructure;
    using Books.ViewModel;
    
    /// <summary>
    /// Represents a book domain model
    /// </summary>
    public class BookDomainModel : DomainModelBase 
    {
        /// <summary>
        /// Represents a service of the book
        /// </summary>
        private BookWcfServiceClient service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookDomainModel" /> class 
        /// </summary>
        public BookDomainModel()
        {
            Mapper.CreateMap<AuthorServiceModel, AuthorViewModel>();
            Mapper.CreateMap<BookServiceModel, BookViewModel>();
            Mapper.CreateMap<BookViewModel, BookServiceModel>();
        }

        /// <summary>
        /// Gets authors
        /// </summary>
        /// <returns>Received authors</returns>
        public ICollection<AuthorViewModel> GetAuthors()
        {
            using (this.service = new BookWcfServiceClient())
            {
                return this.service.GetAuthors().Select(author => Mapper.Map<AuthorServiceModel, AuthorViewModel>(author)).ToList<AuthorViewModel>();
            }
        }

        /// <summary>
        /// Gets books
        /// </summary>
        /// <returns>Received books</returns>
        public ICollection<BookViewModel> GetBooks()
        {
            using (this.service = new BookWcfServiceClient())
            {
                return this.service.GetBooks().Select(book => Mapper.Map<BookServiceModel, BookViewModel>(book)).ToList<BookViewModel>();
            }
        }

        /// <summary>
        /// Gets a book
        /// </summary>
        /// <param name="bookId">An book id to receive</param>
        /// <returns>The received book</returns>
        public BookViewModel GetBook(int bookId)
        {
            using (this.service = new BookWcfServiceClient())
            {
                return Mapper.Map<BookServiceModel, BookViewModel>(this.service.GetBook(bookId));
            }
        }

        /// <summary>
        /// Creates book
        /// </summary>
        /// <param name="viewModelBook">The book to create</param>
        /// <returns>The created book</returns>
        public BookViewModel CreateBook(BookViewModel viewModelBook)
        {
            using (this.service = new BookWcfServiceClient())
            {
                this.service.CreateBook(Mapper.Map<BookViewModel, BookServiceModel>(viewModelBook));
            }

            return viewModelBook;
        }

        /// <summary>
        /// Edits a book
        /// </summary>
        /// <param name="viewModelBook">The book to edit</param>
        /// <returns>The edited book</returns>
        public BookViewModel EditBook(BookViewModel viewModelBook)
        {
            using (this.service = new BookWcfServiceClient())
            {
                this.service.EditBook(Mapper.Map<BookViewModel, BookServiceModel>(viewModelBook));
            }

            return viewModelBook;
        }

        /// <summary>
        /// Removes a book
        /// </summary>
        /// <param name="viewModelBook">The book to remove</param>
        public void RemoveBook(BookViewModel viewModelBook)
        {
            using (this.service = new BookWcfServiceClient())
            {
                this.service.RemoveBook(Mapper.Map<BookViewModel, BookServiceModel>(viewModelBook));
            }
        }
    }
}
