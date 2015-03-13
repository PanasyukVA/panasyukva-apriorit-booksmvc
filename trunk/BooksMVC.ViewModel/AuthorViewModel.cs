using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BooksMVC.ViewModel
{
    public class AuthorViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int? AuthorID { get; set; }
        
        [Required()]
        [MaxLength(150)]
        public string AuthorName { get; set; }

        [Editable(false)]
        public string Books { get; set; }
    }
}
