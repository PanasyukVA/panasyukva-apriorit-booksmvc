using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using panasyukva_apriorit_booksmvc.DAL;
using panasyukva_apriorit_booksmvc.ViewModel;

namespace panasyukva_apriorit_booksmvc.DomainModel.Domains
{
    public class DomainModelAuthor
    {
        SelfEducationEntities context;

        public DomainModelAuthor() {
            context = new SelfEducationEntities();
        }

        public ViewModelAuthor GetAuthor(int authorId)
        {
            var currentAuthor = (from author in context.Author where author.ID == authorId select author).FirstOrDefault();
            StringBuilder currentAuthorBooks = new StringBuilder();
            foreach (var book in currentAuthor.Book)
                currentAuthorBooks.Append(book.Name);
            return new ViewModelAuthor() { AuthorID = currentAuthor.ID, AuthorName = currentAuthor.Name, Books = currentAuthorBooks.ToString() };
        }

        public int CreateAuthor(string AuthorName)
        {
            return 1;
        }

        public void EditAuthor(int AuthorID, string AuthorName)
        {
        }
    }
}
