//----------------------------------------------------------
// <copyright file="AuthorsEditorFor.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//----------------------------------------------------------
namespace Books.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    /// <summary>
    /// Represents the AuthorsEditorFor class
    /// </summary>
    public class AuthorsEditorFor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsEditorFor"/> class
        /// </summary>
        /// <param name="selectedAuthors">Selected authors of the author entity</param>
        /// <param name="allAuthors">The list of all authors</param>
        public AuthorsEditorFor(ICollection<string> selectedAuthors, ICollection<AuthorViewModel> allAuthors)
        {
            SelectedAuthors = selectedAuthors;
            AllAuthors = allAuthors;
        }

        /// <summary>
        /// Gets or sets selected authors
        /// </summary>
        public ICollection<string> SelectedAuthors { get; set; }

        /// <summary>
        /// Gets or sets all authors
        /// </summary>
        public ICollection<AuthorViewModel> AllAuthors { get; set; }
    }
}