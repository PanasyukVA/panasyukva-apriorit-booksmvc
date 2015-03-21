using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksMVC.DomainModel.Domains;
using BooksMVC.ViewModel;

namespace BooksMVC.Controllers
{
    public class BookController : Controller
    {
        BookDomainModel model;
        
        //
        // GET: /Book/Index

        public ActionResult Index()
        {
            using (model = new BookDomainModel())
            {
                return View("Index", model.GetBooks());
            }
        }
        
        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            using (model = new BookDomainModel())
            {
                ViewBag.AllAuthors = new SelectList(model.GetAuthors(), "AuthorID", "AuthorName");
                return View("_Edit", new BookViewModel() { SelectedAuthors = new List<string>() });
            }
        }

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(BookViewModel Model)
        {
            try
            {
                using (model = new BookDomainModel())
                {
                    model.CreateBook(Model);
                }

                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                return View("_Error", err);
            }
        }

        //
        // GET: /Book/Edit/5

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Edit(int id)
        {
            using (model = new BookDomainModel())
            {
                ViewBag.AllAuthors = new SelectList(model.GetAuthors(), "AuthorID", "AuthorName");
                return View("_Edit", model.GetBook(id));
            }
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, BookViewModel Model)
        {
            try
            {
                using (model = new BookDomainModel())
                {
                    model.EditBook(Model);
                }

                return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                return View("_Error", err);
            }
        }
    }
}
