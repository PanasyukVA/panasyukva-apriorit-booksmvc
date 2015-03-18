using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BooksMVC.DAL;
using BooksMVC.ViewModel;

namespace BooksWebServices
{
    /// <summary>
    /// Summary description for AuthorWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class AuthorWebService : System.Web.Services.WebService
    {
        SelfEducationEntities context;

        [WebMethod]
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

        [WebMethod]
        public AuthorViewModel CreateAuthor(AuthorViewModel vmAuthor)
        {
            using (context = new SelfEducationEntities())
            {
                context.Authors.Add(new Author() { Name = vmAuthor.AuthorName });
                context.SaveChanges();
                return vmAuthor;
            }
        }

        [WebMethod]
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
