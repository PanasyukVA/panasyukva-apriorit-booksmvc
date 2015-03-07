using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace panasyukva_apriorit_booksmvc.ViewModel
{
    public class ViewModelAuthor
    {
        [Required()]
        public int AuthorID { get; set; }
        
        [Required()]
        [MaxLength(150)]
        public string AuthorName { get; set; }
    }
}
