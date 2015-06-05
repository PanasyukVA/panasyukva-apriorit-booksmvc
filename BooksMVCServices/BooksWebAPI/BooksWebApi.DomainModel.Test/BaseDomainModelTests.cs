//--------------------------------------------------------------
// <copyright file="BaseDomainModelTests.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//--------------------------------------------------------------
namespace BooksWebApi.DomainModel.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents the base domain model tests
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class BaseDomainModelTests
    {
        /// <summary>
        /// Represents the test context
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }

            set
            {
                this.testContextInstance = value;
            }
        }
    }
}
