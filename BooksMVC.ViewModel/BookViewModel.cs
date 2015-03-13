using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BooksMVC.ViewModel
{
    public class BookViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int? BookID { get; set; }

        [Required()]
        [MaxLength(150)]
        [MinLength(1)]
        public string BookName { get; set; }

        [Required()]
        public ICollection<AuthorViewModel> Authors { get; set; }

        public IEnumerable<string> SelectedAuthors { get; set; } 
    }
}
