using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace panasyukva_apriorit_booksmvc.ViewModel
{
    public class ViewModelBook
    {
        [HiddenInput(DisplayValue = false)]
        public int? BookID { get; set; }

        [Required()]
        [MaxLength(150)]
        public string BookName { get; set; }

        [Required()]
        public ICollection<ViewModelAuthor> Authors { get; set; }
    }
}
