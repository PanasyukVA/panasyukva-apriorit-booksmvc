using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace panasyukva_apriorit_booksmvc.ViewModel
{
    public class ViewModelBook
    {
        [Required()]
        public int BookID { get; set; }

        [Required()]
        [MaxLength(150)]
        public string BookName { get; set; }
    }
}
