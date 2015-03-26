//------------------------------------------------------
// <copyright file="AuthorDomainModel.cs" company="ApriorIT">
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
    using Books.DomainModel.AuthorWcfService;
    using Books.Infrastructure;
    using Books.ViewModel;

    /// <summary>
    /// Represents an author domain model
    /// </summary>
    public class AuthorDomainModel : DomainModelBase 
    {
        /// <summary>
        /// Represents a service of the author
        /// </summary>
        private AuthorWcfServiceClient service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorDomainModel" /> class 
        /// </summary>
        public AuthorDomainModel() 
        {
            Mapper.CreateMap<AuthorServiceModel, AuthorViewModel>();
            Mapper.CreateMap<AuthorViewModel, AuthorServiceModel>();
        }

        /// <summary>
        /// Gets an author
        /// </summary>
        /// <param name="authorId">An author id to receive</param>
        /// <returns>The received author</returns>
        public AuthorViewModel GetAuthor(int authorId)
        {
            using (this.service = new AuthorWcfServiceClient())
            {
                return Mapper.Map<AuthorServiceModel, AuthorViewModel>(this.service.GetAuthor(authorId));
            }
        }

        /// <summary>
        /// Creates na author
        /// </summary>
        /// <param name="viewModelAuthor">The author to create</param>
        /// <returns>The created author</returns>
        public AuthorViewModel CreateAuthor(AuthorViewModel viewModelAuthor)
        {
            using (this.service = new AuthorWcfServiceClient())
            {
                this.service.CreateAuthor(Mapper.Map<AuthorViewModel, AuthorServiceModel>(viewModelAuthor));
                return viewModelAuthor;
            }
        }

        /// <summary>
        /// Edits an author
        /// </summary>
        /// <param name="viewModelAuthor">The author to edit</param>
        /// <returns>The edited author</returns>
        public AuthorViewModel EditAuthor(AuthorViewModel viewModelAuthor)
        {
            using (this.service = new AuthorWcfServiceClient())
            {
                this.service.EditAuthor(Mapper.Map<AuthorViewModel, AuthorServiceModel>(viewModelAuthor));
                return viewModelAuthor;
            }
        }
    }
}
