//------------------------------------------------------------------
// <copyright file="BookDomainModelEditorFor.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------------------
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
    /// Represents the book domain model by using "EditotFor"
    /// </summary>
    public class BookDomainModelEditorFor : DomainModelBase 
    {
        /// <summary>
        /// Represents a service of the book
        /// </summary>
        private BookWcfServiceClient service;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookDomainModel" /> class 
        /// </summary>
        public BookDomainModelEditorFor()
        {
            Mapper.CreateMap<AuthorViewModel, AuthorServiceModel>();
            Mapper.CreateMap<AuthorServiceModel, AuthorViewModel>();
            Mapper.CreateMap<BookServiceModel, BookViewModel>();
            Mapper.CreateMap<BookViewModel, BookServiceModel>();
        }

        /// <summary>
        /// Gets a book
        /// </summary>
        /// <param name="bookId">The book id to receive</param>
        /// <returns>The received book</returns>
        public BookViewModelEditroFor GetBook(int bookId)
        {
            using (this.service = new BookWcfServiceClient())
            {
                return new BookViewModelEditroFor(
                    Mapper.Map<BookServiceModel, BookViewModel>(this.service.GetBook(bookId)), 
                    this.service.GetAuthors().Select(author => Mapper.Map<AuthorServiceModel, AuthorViewModel>(author)).ToList<AuthorViewModel>());
            }
        }
    }
}
