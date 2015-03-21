using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BooksMVC.DAL;

namespace BooksWcfServices
{
    public class AuthorWcfService : IAuthorWcfService
    {
        SelfEducationEntities context;

        public AuthorServiceModel GetAuthor(int authorId)
        {
            using (context = new SelfEducationEntities())
            {
                return context.Authors.Where(author => author.ID == authorId).Select(author => new
                {
                    AuthorID = author.ID,
                    AuthorName = author.Name,
                    Books = author.Books.Select(book => book.Name)
                }).ToList().Select(author => new AuthorServiceModel()
                {
                    AuthorID = author.AuthorID,
                    AuthorName = author.AuthorName,
                    Books = author.Books.Aggregate((currernt, next) => currernt + ", " + next)
                }).First();
            }
        }

        public AuthorServiceModel CreateAuthor(AuthorServiceModel vmAuthor)
        {
            using (context = new SelfEducationEntities())
            {
                context.Authors.Add(new Author() { Name = vmAuthor.AuthorName });
                context.SaveChanges();
                return vmAuthor;
            }
        }

        public AuthorServiceModel EditAuthor(AuthorServiceModel vmAuthor)
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
