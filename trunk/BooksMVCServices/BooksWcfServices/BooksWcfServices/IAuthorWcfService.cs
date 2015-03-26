// -------------------------------------------------------------
// <copyright file="IAuthorWcfService.cs" company="ApriorIT">
//      Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
// -------------------------------------------------------------
namespace BooksWcfServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    using Books.DataAccessLayer;

    /// <summary>
    /// Represents a basis of the author service
    /// </summary>
    [ServiceContract]
    public interface IAuthorWcfService
    {
        /// <summary>
        /// Gets an author
        /// </summary>
        /// <param name="authorId">An author id to receive</param>
        /// <returns>The received author</returns>
        [OperationContract]
        AuthorServiceModel GetAuthor(int authorId);

        /// <summary>
        /// Creates an author
        /// </summary>
        /// <param name="viewModelAuthor">The author to create</param>
        /// <returns>The created author</returns>
        [OperationContract]
        AuthorServiceModel CreateAuthor(AuthorServiceModel viewModelAuthor);

        /// <summary>
        /// Edits an author
        /// </summary>
        /// <param name="viewModelAuthor">The author to edit</param>
        /// <returns>The edited author</returns>
        [OperationContract]
        AuthorServiceModel EditAuthor(AuthorServiceModel viewModelAuthor);
    }

    /// <summary>
    /// Represents an author in the author service
    /// </summary>
    [DataContract]
    public class AuthorServiceModel
    {
        /// <summary>
        /// Gets or sets author id
        /// </summary>
        [DataMember]
        public int? AuthorId { get; set; }
        
        /// <summary>
        /// Gets or sets author name
        /// </summary>
        [DataMember(IsRequired = true)]
        public string AuthorName { get; set; }
        
        /// <summary>
        /// Gets or sets author books
        /// </summary>
        [DataMember]
        public string Books { get; set; }
    }
}
