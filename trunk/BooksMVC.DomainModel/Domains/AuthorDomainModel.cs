using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksMVC.ViewModel;
using BooksMVC.Infrastructure;
using BooksMVC.DomainModel.AuthorWcfService;
using AutoMapper;

namespace BooksMVC.DomainModel.Domains
{
    public class AuthorDomainModel : DomainModelBase 
    {
        AuthorWcfServiceClient service;

        public AuthorDomainModel() 
        {
            Mapper.CreateMap<AuthorServiceModel, AuthorViewModel>();
            Mapper.CreateMap<AuthorViewModel, AuthorServiceModel>();
        }

        public AuthorViewModel GetAuthor(int authorId)
        {
            using (service = new AuthorWcfServiceClient())
            {
                return Mapper.Map<AuthorServiceModel, AuthorViewModel>(service.GetAuthor(authorId));
            }
        }

        public AuthorViewModel CreateAuthor(AuthorViewModel vmAuthor)
        {
            using (service = new AuthorWcfServiceClient())
            {
                service.CreateAuthor(Mapper.Map<AuthorViewModel, AuthorServiceModel>(vmAuthor));
                return vmAuthor;
            }
        }

        public AuthorViewModel EditAuthor(AuthorViewModel vmAuthor)
        {
            using (service = new AuthorWcfServiceClient())
            {
                service.EditAuthor(Mapper.Map<AuthorViewModel, AuthorServiceModel>(vmAuthor));
                return vmAuthor;
            }
        }
    }
}
