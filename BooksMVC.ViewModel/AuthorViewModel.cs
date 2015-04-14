//------------------------------------------------------
// <copyright file="AuthorViewModel.cs" company="ApriorIT">
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
    /// Represents an author view model    
    /// </summary>
    public class AuthorViewModel
    {
        /// <summary>
        /// Gets or sets an author id
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int AuthorId { get; set; }
        
        /// <summary>
        /// Gets or sets an author name
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets an author books
        /// </summary>
        [Editable(false)]
        public string Books { get; set; }
    }
}
