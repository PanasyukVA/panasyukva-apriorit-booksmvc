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

                foreach (var book in context.Book)
                {
                    List<ViewModelAuthor> listAuthor = new List<ViewModelAuthor>();
                    foreach (var author in book.Author)
                        listAuthor.Add(new ViewModelAuthor() { AuthorID = author.ID, AuthorName = author.Name });

                    listBook.Add(new ViewModelBook() { BookID = book.ID, BookName = book.Name, Authors = listAuthor });
                }
                
                return listBook;
            }
        }

        public DomainModelBooks() {
            context = new SelfEducationEntities();
        }
    }
}
