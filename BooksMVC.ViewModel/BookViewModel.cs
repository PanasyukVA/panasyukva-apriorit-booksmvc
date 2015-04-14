//------------------------------------------------------
// <copyright file="BookViewModel.cs" company="ApriorIT">
//     Copyright (c) ApriorIT. All rights reserved.
// </copyright>
// <author>Vitaliy Panasyuk</author>
//------------------------------------------------------
namespace Books.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a book view model
    /// </summary>
    public class BookViewModel
    {
        /// <summary>
        /// Gets or sets a book id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets a book name
        /// </summary>
        [Required]
        [MaxLength(150)]
        [MinLength(1)]
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets a book authors
        /// </summary>
        [Required]
        public ICollection<AuthorViewModel> Authors { get; set; }

        /// <summary>
        /// Gets or sets a book selected authors
        /// </summary>
        public IEnumerable<string> SelectedAuthors { get; set; } 
    }
}
