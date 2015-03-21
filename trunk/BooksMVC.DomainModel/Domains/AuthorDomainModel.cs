using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksMVC.ViewModel;
using BooksMVC.Infrastructure;
using BooksMVC.DomainModel.AuthorWcfService;

namespace BooksMVC.DomainModel.Domains
{
    public class AuthorDomainModel : DomainModelBase 
    {
        AuthorWcfServiceClient service;

        public AuthorViewModel GetAuthor(int authorId)
        {
            using (service = new AuthorWcfServiceClient())
            {
                AuthorServiceModel authorService = service.GetAuthor(authorId);
                return new AuthorViewModel() 
                { 
                    AuthorID = authorService.AuthorID, 
                    AuthorName = authorService.AuthorName, 
                    Books = authorService.Books
                };
            }
        }

        public AuthorViewModel CreateAuthor(AuthorViewModel vmAuthor)
        {
            using (service = new AuthorWcfServiceClient())
            {
                service.CreateAuthor(new AuthorServiceModel() 
                { 
                    AuthorID = vmAuthor.AuthorID, 
                    AuthorName = vmAuthor.AuthorName, 
                    Books = vmAuthor.Books 
                });

                return vmAuthor;
            }
        }

        public AuthorViewModel EditAuthor(AuthorViewModel vmAuthor)
        {
            using (service = new AuthorWcfServiceClient())
            {
                service.EditAuthor(new AuthorServiceModel() 
                {
                    AuthorID = vmAuthor.AuthorID,
                    AuthorName = vmAuthor.AuthorName,
                    Books = vmAuthor.Books
                });

                return vmAuthor;
            }
        }
    }
}
