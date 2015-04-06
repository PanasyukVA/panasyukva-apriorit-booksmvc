//-----------------------------------------------------------
// <copyright file="AuthorDomainModelTests.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//-----------------------------------------------------------
namespace BooksWebApi.DomainModel.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Books.ViewModel;
    using BooksWebApi.DomainModel.Domains;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents author domain model tests
    /// </summary>
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AuthorDomainModelTests : BaseDomainModelTests
    {
        /// <summary>
        /// Checks the amount of author's books
        /// </summary>
        [DataSource("AuthorDataSource")]
        [TestMethod]
        public void GetAuthorBooks_CheckingAmountOfBooks()
        {
            // Arrange
            int authorId = Convert.ToInt32(TestContext.DataRow["AuthorId"]);
            int expectedCount = Convert.ToInt32(TestContext.DataRow["BooksAmount"]);
            int actualCount;
            AuthorDomainModel model;

            // Act
            using (model = new AuthorDomainModel())
            {
                actualCount = model.GetAuthorBooks(id: authorId).Count;
            }

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "The books amount is not correct");
        }

        /// <summary>
        /// Checks the fullness of author's books
        /// </summary>
        [DataSource("AuthorDataSource")]
        [TestMethod]
        public void GetAuthorBooks_CheckingFullnessOfBooks()
        {
            // Arrange
            int authorId = Convert.ToInt32(TestContext.DataRow["AuthorId"]);
            ICollection<BookViewModel> actualBooks;
            AuthorDomainModel model;
            
            // Act
            using (model = new AuthorDomainModel())
            {
                actualBooks = model.GetAuthorBooks(id: authorId);
            }

            // Assert
            CollectionAssert.AllItemsAreNotNull(actualBooks.ToList<BookViewModel>(), string.Format("Books of author # {0} are not full", authorId));
        }
    }
}
