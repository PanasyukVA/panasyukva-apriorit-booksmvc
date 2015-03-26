// -------------------------------------------------------------
// <copyright file="IBookWcfService.cs" company="ApriorIT">
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
    using System.Text;
    using Books.DataAccessLayer;

    /// <summary>
    /// Represents a basis of the book service 
    /// </summary>
    [ServiceContract]
    public interface IBookWcfService
    {
        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>Received authors</returns>
        [OperationContract]
        ICollection<AuthorServiceModel> GetAuthors();

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>Received books</returns>
        [OperationContract]
        ICollection<BookServiceModel> GetBooks();

        /// <summary>
        /// Gets a book
        /// </summary>
        /// <param name="bookId">An book id to receive</param>
        /// <returns>The received book</returns>
        [OperationContract]
        BookServiceModel GetBook(int bookId);

        /// <summary>
        /// Creates a book
        /// </summary>
        /// <param name="viewModelBook">The book to create</param>
        /// <returns>The created book</returns>
        [OperationContract]
        BookServiceModel CreateBook(BookServiceModel viewModelBook);

        /// <summary>
        /// Edits a book
        /// </summary>
        /// <param name="viewModelBook">The book to edit</param>
        /// <returns>The created book</returns>
        [OperationContract]
        BookServiceModel EditBook(BookServiceModel viewModelBook);

        /// <summary>
        /// Removes a book
        /// </summary>
        /// <param name="viewModelBook">The book to remove</param>
        [OperationContract]
        void RemoveBook(BookServiceModel viewModelBook);
    }

    /// <summary>
    /// Represents a book in the book service
    /// </summary>
    [DataContract]
    public class BookServiceModel
    {
        /// <summary>
        /// Gets or sets book id
        /// </summary>
        [DataMember]
        public int? BookId { get; set; }

        /// <summary>
        /// Gets or sets book name
        /// </summary>
        [DataMember(IsRequired = true)]
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets collection book authors
        /// </summary>
        [DataMember(IsRequired = true)]
        public ICollection<AuthorServiceModel> Authors { get; set; }

        /// <summary>
        /// Gets or sets book selected authors
        /// </summary>
        [DataMember(IsRequired = true)]
        public IEnumerable<string> SelectedAuthors { get; set; } 
    }
}
