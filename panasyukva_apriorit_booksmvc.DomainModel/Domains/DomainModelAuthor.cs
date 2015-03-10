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
            Author DALAuthor = context.Author.Where(author => author.ID == authorId).FirstOrDefault();
            StringBuilder vmAuthorBooks = new StringBuilder();
            foreach (var book in DALAuthor.Book)
                vmAuthorBooks.Append(book.Name);
            return new ViewModelAuthor() { AuthorID = DALAuthor.ID, AuthorName = DALAuthor.Name, Books = vmAuthorBooks.ToString() };
        }

        public ViewModelAuthor CreateAuthor(ViewModelAuthor vmAuthor)
        {
            context.Author.Add(new Author() { Name = vmAuthor.AuthorName });
            context.SaveChanges();
            return vmAuthor;
        }

        public ViewModelAuthor EditAuthor(ViewModelAuthor vmAuthor)
        {
            Author DALAuthor = context.Author.Where(author => author.ID == vmAuthor.AuthorID).FirstOrDefault();
            DALAuthor.Name = vmAuthor.AuthorName;
            context.SaveChanges();
            return vmAuthor;
        }
    }
}
