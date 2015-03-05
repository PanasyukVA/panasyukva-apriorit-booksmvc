using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panasyukva_apriorit_booksmvc.DomainModel
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public List<Author> Authors { get; }
    }
}
