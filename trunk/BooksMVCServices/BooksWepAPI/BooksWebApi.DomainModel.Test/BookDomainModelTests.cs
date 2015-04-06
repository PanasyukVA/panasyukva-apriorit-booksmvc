//--------------------------------------------------------------
// <copyright file="BookDomainModelTests.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//--------------------------------------------------------------
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
    /// Represents book domain model tests
    /// </summary>
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BookDomainModelTests : BaseDomainModelTests
    {
        /// <summary>
        /// Checks the amount of book's authors
        /// </summary>
        [DataSource("BookDataSource")]
        [TestMethod]
        public void GetBookAuthors_CheckingAmountOfAuthors()
        {
            // Arrange
            int bookId = Convert.ToInt32(TestContext.DataRow["BookId"]);
            int expectedCount = Convert.ToInt32(TestContext.DataRow["AuthorsAmount"]);
            int actualCount;
            BookDomainModel model;

            // Act
            using (model = new BookDomainModel())
            {
                actualCount = model.GetBookAuthors(id: bookId).Count;
            }

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "The authors amount is not correct");
        }

        /// <summary>
        /// Checks the fullness book's authors
        /// </summary>
        [DataSource("BookDataSource")]
        [TestMethod]
        public void GetBookAuthors_CheckingFullnessOfAuthors()
        {
            // Arrange
            int bookId = Convert.ToInt32(TestContext.DataRow["BookId"]);
            ICollection<AuthorViewModel> actualAuthors;
            BookDomainModel model;

            // Act
            using (model = new BookDomainModel())
            {
                actualAuthors = model.GetBookAuthors(id: bookId);
            }

            // Assert
            CollectionAssert.AllItemsAreNotNull(actualAuthors.ToList<AuthorViewModel>(), string.Format("Authors of book # {0} are not full", bookId));
        }

        /// <summary>
        /// Checks the amount of all books
        /// </summary>
        [TestMethod]
        public void GetBooks_CheckingAmount()
        {
            // Arrange
            int expectedCount = 3;
            int actualCount;
            BookDomainModel model;

            // Act
            using (model = new BookDomainModel())
            {
                actualCount = model.GetBooks().Count;
            }

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "The books amount is not correct");
        }

        /// <summary>
        /// Checks the fullness of books
        /// </summary>
        [TestMethod]
        public void GetBooks_CheckingFullness()
        {
            // Arrange
            ICollection<BookViewModel> actualBooks;
            BookDomainModel model;

            // Act
            using (model = new BookDomainModel())
            {
                actualBooks = model.GetBooks();
            }

            // Assert
            CollectionAssert.AllItemsAreNotNull(actualBooks.ToList<BookViewModel>(), "Books of all authors are not full");
        }

        /// <summary>
        /// Checks the amount of books that is filtered by publish date
        /// </summary>
        [TestMethod]
        public void GetBooksByPublishDateRange_CheckingAmount()
        {
            // Arrange
            int expectedCount = 3;
            int actualCount;
            BookDomainModel model;

            // Act
            using (model = new BookDomainModel())
            {
                actualCount = model.GetBooksByPublishDateRange(beginDate: new DateTime(1900, 1, 1), endDate: new DateTime(2015, 12, 31)).Count;
            }

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "The books amount is not correct");
        }

        /// <summary>
        /// Checks the range values
        /// </summary>
        [DataSource("BookDataSource")]
        [TestMethod]
        public void GetBooksByPublishDateRange_CheckingRangeValues()
        {
            // Arrange
            int? expectedBookId = Convert.ToInt32(TestContext.DataRow["BookId"]);
            DateTime bookPublishDate = Convert.ToDateTime(TestContext.DataRow["PublishDate"]);
            int? actualBookId;
            BookDomainModel model;

            // Act
            using (model = new BookDomainModel())
            {
                actualBookId = model.GetBooksByPublishDateRange(beginDate: bookPublishDate, endDate: bookPublishDate).First().BookId;
            }

            // Assert
            Assert.AreEqual(expectedBookId, actualBookId, "The range value is not correct");
        }
    }
}
