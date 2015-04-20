//----------------------------------------------------------------
// <copyright file="BookViewModelEditroFor.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//----------------------------------------------------------------
namespace Books.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    /// <summary>
    /// Represents the book view model by using "EditroFor"
    /// </summary>
    public class BookViewModelEditroFor : BookViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookViewModelEditroFor"/> class
        /// </summary>
        /// <param name="viewModel">The book view model</param>
        /// <param name="allAuthors">The list of all authors</param>
        public BookViewModelEditroFor(BookViewModel viewModel, ICollection<AuthorViewModel> allAuthors)
        {
            this.BookId = viewModel.BookId;
            this.BookName = viewModel.BookName;
            this.Authors = new AuthorsEditorFor(viewModel.SelectedAuthors.ToArray(), allAuthors);
        }

        /// <summary>
        /// Gets or sets authors
        /// </summary>
        public AuthorsEditorFor Authors { get; set; }
    }
}