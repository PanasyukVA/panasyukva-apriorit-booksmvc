using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using panasyukva_apriorit_booksmvc.DAL;
using panasyukva_apriorit_booksmvc.ViewModel;

namespace panasyukva_apriorit_booksmvc.DomainModel.Domains
{
    public class DomainModelBooks
    {
        SelfEducationEntities context;
        public ICollection<ViewModelBook> Books {
            get {
                List<ViewModelBook> listBook = new List<ViewModelBook>();
                //foreach (Book book in context.Books)
                //    listBook.Add(new ViewModelBook() { BookID = book.ID, BookName = book.Name });

                return listBook;
            }
        }

        DomainModelBooks() {
            context = new SelfEducationEntities();
        }
    }
}
