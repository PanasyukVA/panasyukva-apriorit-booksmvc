using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksMVC.DomainModel.Domains;
using BooksMVC.ViewModel;
using System.Net.Http;

namespace BooksMVC.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View("_Edit", new AuthorViewModel());
        }

        //
        // GET: /Author/Edit/5

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View("_Edit", new AuthorViewModel());
        }
    }
}
