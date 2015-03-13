using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksMVC.DAL;
using BooksMVC.ViewModel;
using BooksMVC.Infrastructure;

namespace BooksMVC.DomainModel.Domains
{
    public class AuthorDomainModel : DomainModelBase 
    {
        SelfEducationEntities context;

        public AuthorViewModel GetAuthor(int authorId)
        {
            using (context = new SelfEducationEntities())
            {
                return context.Authors.Where(author => author.ID == authorId).Select(author => new
                {
                    AuthorID = author.ID,
                    AuthorName = author.Name,
                    Books = author.Books.Select(book => book.Name)
                }).ToList().Select(author => new AuthorViewModel()
                { 
                    AuthorID = author.AuthorID,
                    AuthorName = author.AuthorName,
                    Books = author.Books.Aggregate((currernt, next) => currernt + ", " + next)
                }).First();
            }
        }

        public AuthorViewModel CreateAuthor(AuthorViewModel vmAuthor)
        {
            using (context = new SelfEducationEntities())
            {
                context.Authors.Add(new Author() { Name = vmAuthor.AuthorName });
                context.SaveChanges();
                return vmAuthor;
            }
        }

        public AuthorViewModel EditAuthor(AuthorViewModel vmAuthor)
        {
            using (context = new SelfEducationEntities())
            {
                Author DALAuthor = context.Authors.Where(author => author.ID == vmAuthor.AuthorID).First();
                DALAuthor.Name = vmAuthor.AuthorName;
                context.SaveChanges();
                return vmAuthor;
            }
        }
    }
}
