using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BooksMVC.ViewModel;
using BooksWebAPI.DomainModel.Domains;

namespace BooksWebAPI.Controllers
{
    public class AuthorController : ApiController
    {
        AuthorDomainModel model;

        public AuthorViewModel GetAuthor(int id)
        {
            using (model = new AuthorDomainModel())
            {
                return model.GetAuthor(id);
            }
        }

        public AuthorViewModel CreateAuthor([FromBody]AuthorViewModel vmAuthor)
        {
            using (model = new AuthorDomainModel())
            {
                model.CreateAuthor(vmAuthor);
                return vmAuthor;
            }
        }

        public AuthorViewModel EditAuthor([FromBody]AuthorViewModel vmAuthor)
        {
            using (model = new AuthorDomainModel())
            {
                model.EditAuthor(vmAuthor);
                return vmAuthor;
            }
        }
    }
}
