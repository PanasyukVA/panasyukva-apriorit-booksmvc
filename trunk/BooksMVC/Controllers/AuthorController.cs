using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksMVC.DomainModel.Domains;
using BooksMVC.ViewModel;
using panasyukva_apriorit_booksmvc.AuthorWcfService;
using System.Net.Http;

namespace BooksMVC.Controllers
{
    public class AuthorController : Controller
    {
        AuthorWcfServiceClient service;
        HttpClient serviceClient;

        //
        // GET: /Author/Create

        public ActionResult Create()
        {
            return View("_Edit", new AuthorViewModel());
        }

        //
        // POST: /Author/Create

        [HttpPost]
        public ActionResult Create(AuthorViewModel Model)
        {
            try
            {
                using (service = new AuthorWcfServiceClient())
                {
                    service.CreateAuthor(new AuthorServiceModel() { AuthorID = Model.AuthorID, AuthorName = Model.AuthorName, Books = Model.Books });
                }
                return RedirectToAction("Index", "Book");
            }
            catch(Exception err)
            {
                return View("_Error", err);
            }
        }

        //
        // GET: /Author/Edit/5

        public ActionResult Edit(int id)
        {
            AuthorServiceModel authorService;

            using (serviceClient = new HttpClient())
            {
                serviceClient.BaseAddress = new Uri("http://localhost/");
                serviceClient.DefaultRequestHeaders.Accept.Clear();
                var response = serviceClient.GetAsync(String.Format("BooksWebAPI/api/Author/GetAuthor/{0}", id));

                authorService = response.Result.Content.ReadAsAsync<AuthorServiceModel>().Result;
            }

            return View("_Edit", new AuthorViewModel() { AuthorID = authorService.AuthorID, AuthorName = authorService.AuthorName, Books = authorService.Books });
        }

        //
        // POST: /Author/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, AuthorViewModel Model)
        {
            try
            {
                using (service = new AuthorWcfServiceClient())
                {
                    service.EditAuthor(new AuthorServiceModel() { AuthorID = Model.AuthorID, AuthorName = Model.AuthorName, Books = Model.Books });
                }
                return RedirectToAction("Index", "Book");
            }
            catch(Exception err)
            {
                return View("_Error", err);
            }
        }
    }
}
