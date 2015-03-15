using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksMVC.DomainModel.Domains;
using BooksMVC.ViewModel;

namespace BooksMVC.Controllers
{
    public class AuthorController : Controller
    {
        AuthorDomainModel model;

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
                using (model = new AuthorDomainModel())
                {
                    model.CreateAuthor(Model);
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
            model = new AuthorDomainModel();
            return View("_Edit", model.GetAuthor(id));
        }

        //
        // POST: /Author/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, AuthorViewModel Model)
        {
            try
            {
                using (model = new AuthorDomainModel())
                {
                    model.EditAuthor(Model);
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
